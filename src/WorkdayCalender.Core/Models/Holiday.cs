using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WorkdayCalender.Core.Models
{
    public class Holiday
    {
        [JsonIgnore]
        public int Id { get; set; }
        public DateTime HolidayDate { get; set; }
        public bool IsRecurringLeave { get; set; }
    }
}
