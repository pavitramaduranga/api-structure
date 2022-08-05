using System.Collections.Generic;
using System.Threading.Tasks;
using WorkdayCalender.Core.Models;

namespace WorkdayCalender.Core.Interfaces.Services
{
    public interface IHolidayService
    {
        Task<IEnumerable<Holiday>> GetHolidays();
        Task<Holiday> GetHolidayById(int id);
        Task<bool> CreateHoliday(Holiday holiday);
        Task<bool> DeleteHoliday(int id);
    }
}
