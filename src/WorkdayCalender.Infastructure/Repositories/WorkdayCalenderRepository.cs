using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkdayCalender.Core.Interfaces.Repositories;
using WorkdayCalender.Core.Models;
using WorkdayCalender.Infastructure.Context;

namespace WorkdayCalender.Infastructure.Repositories
{
    public class WorkdayCalenderRepository : IWorkdayCalenderRepository
    {
        private readonly IMapper _mapper;
        private readonly WorkdayCalenderDbContext _dbContext;
        public WorkdayCalenderRepository(WorkdayCalenderDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> CreateHoliday(Holiday holiday)
        {
            var dbHoliday = _mapper.Map<Entities.Holiday>(holiday);
            await _dbContext.Holidays.AddAsync(dbHoliday);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteHoliday(int id)
        {
            var holiday = await _dbContext.Holidays.FindAsync(id);
            if (holiday!= null)
            {
                _dbContext.Holidays.Remove(holiday);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Holiday>> GetHolidays()
        {
            var dbHolidays = await _dbContext.Holidays.ToListAsync().ConfigureAwait(false);
            if (dbHolidays != null)
            {
                return _mapper.Map<IEnumerable<Holiday>>(dbHolidays);
            }
            return null;
        }
    }
}
