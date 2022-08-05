using System;
using WorkdayCalender.Core.Interfaces.Services;
using WorkdayCalender.Core.Models;
using WorkdayCalender.Core.Services;
using Xunit;

namespace WorkdayCalender.Core.Tests
{
    public class WorkDayCalculationServiceTest
    {
        private readonly IWorkDayCalculationService _service;
        private readonly CalculationRequest calculationRequest = new()
        {
            WorkdayStartHour = 8,
            WorkdayEndHour = 16,
        };
        public WorkDayCalculationServiceTest()
        {
            _service = new WorkDayCalculationService();
        }

        [Fact]
        public async void CalculateWorkDay_Case_1()
        {
            calculationRequest.StartDate = new DateTime(2004, 5, 24, 18, 05, 00);
            calculationRequest.Workdays = -5.5;
            var response = await _service.CalculateWorkDay(calculationRequest).ConfigureAwait(false);
            Assert.Equal("14-05-2004 12:00", response.WorkDay);
        }

        [Fact]
        public async void CalculateWorkDay_Case_2()
        {
            calculationRequest.StartDate = new DateTime(2004, 05, 24, 19, 03, 00);
            calculationRequest.Workdays = 44.723656;
            var response = await _service.CalculateWorkDay(calculationRequest).ConfigureAwait(false);
            Assert.Equal("26-07-2004 13:47", response.WorkDay);
        }

        [Fact]
        public async void CalculateWorkDay_Case_3()
        {
            calculationRequest.StartDate = new DateTime(2004, 05, 24, 18, 03, 00);
            calculationRequest.Workdays = -6.7470217;
            var response = await _service.CalculateWorkDay(calculationRequest).ConfigureAwait(false);
            Assert.Equal("13-05-2004 10:02", response.WorkDay);
        }

        [Fact]
        public async void CalculateWorkDay_Case_4()
        {

            calculationRequest.StartDate = new DateTime(2004, 05, 24, 8, 3, 00);
            calculationRequest.Workdays = 12.782709;
            var response = await _service.CalculateWorkDay(calculationRequest).ConfigureAwait(false);
            Assert.Equal("10-06-2004 14:18", response.WorkDay);
        }

        [Fact]
        public async void CalculateWorkDay_Case_5()
        {
            calculationRequest.StartDate = new DateTime(2004, 05, 24, 07, 03, 00);
            calculationRequest.Workdays = 8.276628;
            var response = await _service.CalculateWorkDay(calculationRequest).ConfigureAwait(false);
            Assert.Equal("04-06-2004 10:12", response.WorkDay);
        }

    }
}
