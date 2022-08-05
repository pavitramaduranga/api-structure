using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkdayCalender.Core.Interfaces.Services;
using WorkdayCalender.Core.Models;

namespace WorkdayCalender.Api.Tests
{
    public class WorkDayCalculationServiceFake : IWorkDayCalculationService
    {
        readonly CalculationResponse calculationResponse = new CalculationResponse();
        public WorkDayCalculationServiceFake()
        {
           calculationResponse = new() { WorkDay = DateTime.Now.ToString() };
        }
        public async Task<CalculationResponse> CalculateWorkDay(CalculationRequest calculationRequest)
        {
            return calculationResponse;
        }
    }
}
