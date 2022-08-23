using System;

namespace WorkdayCalender.Core.Models
{
    public class CalculationRequest
    {
        public int WorkdayStartHour { get; set; }

        public int WorkdayEndHour { get; set; }

        public DateTime StartDate { get; set; }

        public double Workdays { get; set; }
    }
}
