using System;
using System.Linq;
using System.Threading.Tasks;
using WorkdayCalender.Core.Interfaces.Services;
using WorkdayCalender.Core.Models;

namespace WorkdayCalender.Core.Services
{
    public class WorkDayCalculationService : IWorkDayCalculationService
    {

        public readonly IHolidayService _holidayService;
        public readonly ICalculationService _calculationService;

        public WorkDayCalculationService(IHolidayService holidayService, ICalculationService calculationService)
        {
            _holidayService = holidayService ?? throw new ArgumentNullException(nameof(holidayService));
            _calculationService = calculationService ?? throw new ArgumentNullException(nameof(calculationService));
        }

        public async Task<CalculationResponse> CalculateWorkDay(CalculationRequest calculationRequest)
        {

            var holidaysfromDb = await _holidayService.GetHolidays();
            var calculationResponse = await _calculationService.GetLastWorkDay(calculationRequest, holidaysfromDb.ToList());

            return calculationResponse;
        }
    }
}
