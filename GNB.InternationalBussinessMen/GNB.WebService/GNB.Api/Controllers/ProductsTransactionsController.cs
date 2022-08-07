using GNB.Api.DTOs;
using GNB.Api.Helpers;
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
    public class ProductsTransactionsController : Controller
    {
        private readonly IRateService _rateService;
        private readonly ITransactionService _transactionService;

        public ProductsTransactionsController(IRateService rateService, ITransactionService transactionService)
        {
            this._rateService = rateService;
            this._transactionService = transactionService;
        }

        [HttpGet("{uskId}")]
        public async Task<IActionResult> Index(string uskId)
        {
            ApiResponse<ProductDto> response = new ApiResponse<ProductDto>();

            try
            {
                var _transactions = await _transactionService.FilterTransactionsByUskId(uskId);
                var _rates = await _rateService.GetAllRatesFromProv();
                response.Data = new ProductDto { TotalAmount = 0, transactions = _transactions };
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.ErrorMessage = null;
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }            
        }
    }
}
