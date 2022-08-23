using System.Threading.Tasks;
using WorkdayCalender.Core.Models;

namespace WorkdayCalender.Core.Interfaces.Services
{
    public interface IWorkDayCalculationService
    {
        Task<CalculationResponse> CalculateWorkDay(CalculationRequest calculationRequest);
    }
}
