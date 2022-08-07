using System.Collections.Generic;
using System.Threading.Tasks;
using WorkdayCalender.Core.Models;

namespace WorkdayCalender.Core.Interfaces.Services
{
    public interface ICalculationService
    {
        public Task<CalculationResponse> GetLastWorkDay(CalculationRequest calculationRequest, IList<Holiday> holidays);
    }
}
