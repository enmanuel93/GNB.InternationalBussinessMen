using GNB.Application.application.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public RateController(IRateService rateService)
        {
            this._rateService = rateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRates()
        {
            try
            {
                var result = await _rateService.GetAllRatesFromProv();
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
