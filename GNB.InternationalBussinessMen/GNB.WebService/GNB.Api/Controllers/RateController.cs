using GNB.Application.application.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNB.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : Controller
    {
        private readonly IRateService _rateService;
        private readonly ILogger<RateController> _logger;

        public RateController(IRateService rateService, ILogger<RateController> logger)
        {
            this._rateService = rateService;
            this._logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> GetRates()
        {
            try
            {
                var result = await _rateService.GetAllRatesFromProv();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: ", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }            
        }
    }
}
