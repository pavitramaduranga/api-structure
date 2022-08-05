using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkdayCalender.Core.Interfaces.Services;
using WorkdayCalender.Core.Models;

namespace WorkdayCalender.Core.Services
{
    public class WorkDayCalculationService : IWorkDayCalculationService
    {

        //public readonly IHolidayService _holidayService;
        //public WorkDayCalculationService(IHolidayService holidayService)
        //{
        //    holidayService = holidayService ?? throw new ArgumentNullException(nameof(holidayService));
        //}

        public WorkDayCalculationService()
        {
            //holidayService = holidayService ?? throw new ArgumentNullException(nameof(holidayService));
        }

        public async Task<CalculationResponse> CalculateWorkDay(CalculationRequest calculationRequest)
        {

            //var holidaysfromDb = await _holidayService.GetHolidays();

            var holidaysfromDb = new List<Holiday>() {
                new Holiday() { HolidayDate=new DateTime(2004, 5, 17), IsRecurringLeave = true },
                new Holiday() { HolidayDate=new DateTime(2004, 5, 27), IsRecurringLeave = false }
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
                bool isHoliday = IsGivenDateHoliday(startDate, holidaysfromDb);
                if ((startDate.DayOfWeek != DayOfWeek.Saturday) && (startDate.DayOfWeek != DayOfWeek.Sunday) && !isHoliday)
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

        private bool IsGivenDateHoliday(DateTime startDate, IEnumerable<Holiday> holidaysfromDb)
        {
            bool isRecurringHoliday = holidaysfromDb.Any(d => d.HolidayDate.Month == startDate.Month && d.HolidayDate.Day == startDate.Day && d.IsRecurringLeave);
            bool isHoliday = holidaysfromDb.Any(d => d.HolidayDate.ToShortDateString() == startDate.ToShortDateString() && !d.IsRecurringLeave);
           
            return isRecurringHoliday || isHoliday;
        }
    }
}
