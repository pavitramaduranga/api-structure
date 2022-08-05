using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkdayCalender.Core.Models;

namespace WorkdayCalender.Core.Interfaces.Repositories
{
    public interface IWorkdayCalenderRepository
    {
        Task<IEnumerable<Holiday>> GetHolidays();
        Task<Holiday> GetHolidayById(int id);
        Task<bool> CreateHoliday(Holiday holiday);
        Task<bool> DeleteHoliday(int id);

    }
}
