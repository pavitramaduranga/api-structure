using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkdayCalender.Core.Models;

namespace WorkdayCalender.Core.Interfaces.Services
{
    public interface IWorkDayCalculationService
    {
        Task<CalculationResponse> CalculateWorkDay(CalculationRequest calculationRequest);
    }
}
