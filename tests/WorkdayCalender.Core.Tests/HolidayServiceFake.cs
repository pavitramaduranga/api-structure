using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkdayCalender.Core.Interfaces.Services;
using WorkdayCalender.Core.Models;
using WorkdayCalender.Core.Services;
using Xunit;

namespace WorkdayCalender.Core.Tests
{
    public class HolidayServiceFake : IHolidayService, IClassFixture<HolidayService>
    {
        public Task<bool> CreateHoliday(Holiday holiday)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteHoliday(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Holiday> GetHolidayById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Holiday>> GetHolidays()
        {
            var holidays = new List<Holiday>() {
                new Holiday() { HolidayDate=new DateTime(2004, 5, 17), IsRecurringLeave = true },
                new Holiday() { HolidayDate=new DateTime(2004, 5, 27), IsRecurringLeave = false }
            };
            return (Task<IEnumerable<Holiday>>)(holidays as IEnumerable<Holiday>);
        }
    }
}
