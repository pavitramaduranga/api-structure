using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkdayCalender.Api.Controllers;
using WorkdayCalender.Core.Interfaces.Services;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using WorkdayCalender.Core.Models;

namespace WorkdayCalender.Api.Tests
{
    public class WorkDayCalculationControllerTest
    {
        private readonly WorkDayCalculationController _controller;
        private readonly IWorkDayCalculationService _service;
        private readonly CalculationRequest calculationRequest = new();
        public WorkDayCalculationControllerTest()
        {
            _service = new WorkDayCalculationServiceFake();
            _controller = new WorkDayCalculationController(_service);
        }

        [Fact]
        public async void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.CalculateWorkDays(calculationRequest) as Task<ActionResult<CalculationResponse>>;

            // Assert
            Assert.IsType<NoContentResult>(okResult);
        }

    }
}
