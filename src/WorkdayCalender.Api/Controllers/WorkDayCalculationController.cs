using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkdayCalender.Core.Interfaces.Services;
using WorkdayCalender.Core.Models;

namespace WorkdayCalender.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkDayCalculationController : ControllerBase
    {
        private readonly IWorkDayCalculationService _workDayCalculationService;

        public WorkDayCalculationController(IWorkDayCalculationService workDayCalculationService)
        {
            _workDayCalculationService = workDayCalculationService ?? throw new ArgumentNullException(nameof(workDayCalculationService));
        }

        [HttpPost]
        [Route("calculate")]
        public async Task<ActionResult<CalculationResponse>> CalculateWorkDays(CalculationRequest calculationRequest)
        {
            var response = await _workDayCalculationService.CalculateWorkDay(calculationRequest).ConfigureAwait(false);
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }
    }
}
