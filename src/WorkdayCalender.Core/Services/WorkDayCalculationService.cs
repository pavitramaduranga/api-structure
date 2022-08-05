using System;
using System.Linq;
using System.Threading.Tasks;
using WorkdayCalender.Core.Interfaces.Services;
using WorkdayCalender.Core.Models;

namespace WorkdayCalender.Core.Services
{
    public class WorkDayCalculationService : IWorkDayCalculationService
    {

        //public readonly IHolidayService _holidayService;
        public WorkDayCalculationService()//(IHolidayService holidayService)
        {
           // _holidayService = holidayService ?? throw new ArgumentNullException(nameof(holidayService));
        }

        public async Task<CalculationResponse> CalculateWorkDay(CalculationRequest calculationRequest)
        {

            //var holidaysfromDb = _holidayService.GetHolidays();
            DateTime[] recurringHolidays = new DateTime[]
            {
                new DateTime(2004, 5, 17)
            };

            DateTime[] holidays = new DateTime[]
            {
                new DateTime(2004, 5, 27)
            };

            DateTime startDate = calculationRequest.StartDate;
            double numberOfWorkDays = Math.Truncate(calculationRequest.Workdays);

            double numberOfWorkDayFractionals = calculationRequest.Workdays - numberOfWorkDays;
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
            double WorkHoursInMinutes = numberOfWorkDayFractionals * (calculationRequest.WorkdayEndHour - calculationRequest.WorkdayStartHour) * 60;

            if (isMinusWorkDays)
            {

                if (calculationRequest.WorkdayStartHour <= startDate.Hour && calculationRequest.WorkdayEndHour >= startDate.Hour)
                {
                    startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, calculationRequest.WorkdayEndHour, startDate.Minute, 0);
                }
                else
                {
                    startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, calculationRequest.WorkdayEndHour, 0, 0);
                }
                startDate = startDate.AddMinutes(WorkHoursInMinutes);
            }
            else
            {
                if (calculationRequest.WorkdayStartHour <= startDate.Hour && calculationRequest.WorkdayEndHour >= startDate.Hour)
                {
                    startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, calculationRequest.WorkdayStartHour, startDate.Minute, 0);
                }
                else
                {
                    startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, calculationRequest.WorkdayStartHour, 0, 0);
                }
                startDate = startDate.AddMinutes(WorkHoursInMinutes);
            }

            CalculationResponse calculationResponse = new() { WorkDay = startDate.ToString("dd-MM-yyyy HH:mm") };
            return calculationResponse;
        }
    }
}
