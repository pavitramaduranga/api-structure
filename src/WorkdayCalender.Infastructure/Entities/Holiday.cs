using System;
using System.ComponentModel.DataAnnotations;

namespace WorkdayCalender.Infastructure.Entities
{
    public class Holiday
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime HolidayDate { get; set; }

        public bool IsRecurringLeave { get; set; }
    }
}
