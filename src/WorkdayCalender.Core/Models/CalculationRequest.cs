using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
