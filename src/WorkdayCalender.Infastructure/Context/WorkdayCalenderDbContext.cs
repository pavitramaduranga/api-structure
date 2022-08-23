using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WorkdayCalender.Infastructure.Entities;

namespace WorkdayCalender.Infastructure.Context
{
    public class WorkdayCalenderDbContext : DbContext
    {
        public WorkdayCalenderDbContext(DbContextOptions<WorkdayCalenderDbContext> option) : base(option)
        {
            SeedData();
        }

        public virtual DbSet<Holiday> Holidays { get; set; }

        private void SeedData()
        {
            if (!Holidays.Any())
            {
                var holidays = new List<Holiday>() {
                    new Holiday() { HolidayDate=new DateTime(2004, 5, 17), IsRecurringLeave = true },
                    new Holiday() { HolidayDate=new DateTime(2004, 5, 27), IsRecurringLeave = false }
                };

                Holidays.AddRange(holidays);
                SaveChanges();
            }
        }
    }
}
