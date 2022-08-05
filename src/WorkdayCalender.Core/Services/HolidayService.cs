using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkdayCalender.Core.Interfaces.Repositories;
using WorkdayCalender.Core.Interfaces.Services;
using WorkdayCalender.Core.Models;

namespace WorkdayCalender.Core.Services
{
    public class HolidayService : IHolidayService
    {
        public readonly IWorkdayCalenderRepository _workdayCalenderRepository;
        public HolidayService(IWorkdayCalenderRepository workdayCalenderRepository)
        {
            _workdayCalenderRepository = workdayCalenderRepository ?? throw new ArgumentNullException(nameof(workdayCalenderRepository));
        }
        public async Task<bool> CreateHoliday(Holiday holiday)
        {
            try
            {
                return await _workdayCalenderRepository.CreateHoliday(holiday).ConfigureAwait(false);
            }
            catch (Exception)
            {
                //log exception
                throw;
            }
        }

        public async Task<bool> DeleteHoliday(int id)
        {
            try
            {
                return await _workdayCalenderRepository.DeleteHoliday(id);
            }
            catch (Exception)
            {
                //log exception
                throw;
            }
        }

        public async Task<Holiday> GetHolidayById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Holiday>> GetHolidays()
        {
            return await _workdayCalenderRepository.GetHolidays();
        }
    }
}
