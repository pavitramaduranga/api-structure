using System;
using System.Linq;
using System.Threading.Tasks;
using WorkdayCalender.Core.Interfaces.Services;
using WorkdayCalender.Core.Models;

namespace WorkdayCalender.Core.Services
{
    public class WorkDayCalculationService : IWorkDayCalculationService
    {

        public readonly IHolidayService _holidayService;
        public WorkDayCalculationService(IHolidayService holidayService)
        {
            _holidayService = holidayService ?? throw new ArgumentNullException(nameof(holidayService));
        }

        public async Task<CalculationResponse> CalculateWorkDay(CalculationRequest calculationRequest)
        {
            var holidaysfromDb = _holidayService.GetHolidays();
            //Meta data
            DateTime[] recurringHolidays = new DateTime[]
            {
                    //new DateTime(DateTime.Now.Year, 8, 1),
                    new DateTime(2004, 5, 17)
                    //new DateTime(DateTime.Now.Year, 12, 8)
            };

            DateTime[] holidays = new DateTime[]
            {
                   // new DateTime(DateTime.Now.Year, 12, 25),
                    new DateTime(2004, 5, 27)
                    //new DateTime(DateTime.Now.Year, 5, 9)
            };


            //Calculation Data

            int workdayStart = 8;
            int workdayEnd = 16;

            //Case 1 - ok
            //DateTime startDate = new DateTime(2004, 5, 24, 18, 5, 0);
            //double workdays = -5.5;

            //Case 2 - error 1 day diference
            //DateTime startDate = new DateTime(2004, 05, 24, 19, 03, 0);
            //double workdays = 44.723656;

            //Case 3 - ok 1sec diference
            DateTime startDate = new DateTime(2004, 05, 24, 18, 03, 0);
            double workdays = -6.7470217;

            //Case 4 - ok
            //DateTime startDate = new DateTime(2004, 05, 24, 08, 03, 0);
            //double workdays = 12.782709;

            //Case 5 - ok
            //DateTime startDate = new DateTime(2004, 05, 24, 07, 03, 0);
            //double workdays = 8.276628;


            //Calculation
            double numberOfWorkDateParts = workdays % 1;
            double numberOfWorkDays = workdays - numberOfWorkDateParts;
            bool isMinusWorkDays = false;
            if (numberOfWorkDays < 0)
            {
                isMinusWorkDays = true;
                numberOfWorkDays *= -1;

            }

            for (int i = 0; i <= numberOfWorkDays;)
            {
                bool isRecurringHoliday = recurringHolidays.Any(d => d.Month == startDate.Month && d.Day == startDate.Day);
                bool isHoliday = holidays.Any(d => d.Year == startDate.Year && d.Month == startDate.Month && d.Day == startDate.Day);
                if ((startDate.DayOfWeek != DayOfWeek.Saturday) && (startDate.DayOfWeek != DayOfWeek.Sunday) && !isRecurringHoliday && !isHoliday)
                {
                    i++;
                }

                if (i <= numberOfWorkDays)
                {
                    if (isMinusWorkDays)
                    {
                        startDate = startDate.AddDays(-1);
                    }
                    else
                    {
                        startDate = startDate.AddDays(1);
                    }
                }
            }

            //Calculate Time
            
            double WorkHoursInMinutes = numberOfWorkDateParts * (workdayEnd - workdayStart) * 60;

            if (isMinusWorkDays)
            {
                startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, workdayEnd, 00, 00);
                startDate = startDate.AddMinutes(WorkHoursInMinutes);
            }
            else
            {
                startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, workdayStart, 00, 00);
                startDate = startDate.AddMinutes(WorkHoursInMinutes);
            }

            CalculationResponse calculationResponse = new() { WorkDay = startDate };
            return calculationResponse;
        }
    }
}
