﻿using Microsoft.AspNetCore.Http;
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
    public class HolidaysController : ControllerBase
    {
        private readonly IHolidayService _holidayService;

        public HolidaysController(IHolidayService holidayService)
        {
            _holidayService = holidayService ?? throw new ArgumentNullException(nameof(holidayService));
        }

        /// <summary>
        /// Gell all the Holidays
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getholidays")]
        public async Task<ActionResult<IEnumerable<Holiday>>> GetHolidays()
        {
            var response = await _holidayService.GetHolidays().ConfigureAwait(false);
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }

        /// <summary>
        /// Delete Holiday
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("createHoliday")]
        public async Task<ActionResult<bool>> CreateHoliday(Holiday holiday)
        {
            var response = await _holidayService.CreateHoliday(holiday).ConfigureAwait(false);
            if (!response)
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Delete Holiday
        /// </summary>
        /// <returns>true/false</returns>
        [HttpDelete]
        [Route("deleteHoliday")]
        public async Task<ActionResult<bool>> DeleteHoliday(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var response = await _holidayService.DeleteHoliday(id).ConfigureAwait(false);
            if (!response)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}