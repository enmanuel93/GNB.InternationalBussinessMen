using GNB.Api.DTOs;
using GNB.Api.Helpers;
using GNB.Application.application.services;
using GNB.Domain.Entities.Enums;
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
        private readonly IProductService _productService;

        public ProductsTransactionsController(IRateService rateService, ITransactionService transactionService, IProductService productService)
        {
            this._rateService = rateService;
            this._transactionService = transactionService;
            this._productService = productService;
        }

        /// <summary>
        /// conversion de monedas ejemplo
        /// 10 USD A EURO
        /// 10 / 1.359 = 7.35
        /// 7.35 + 7.63 = 14.98
        /// </summary>
        /// <param name="uskId"></param>
        /// <returns></returns>

        [HttpGet("{uskId}")]
        public async Task<IActionResult> Index(string uskId)
        {
            ApiResponse<ProductDto> response = new ApiResponse<ProductDto>();

            try
            {
                var _transactions = await _transactionService.FilterTransactionsByUskId(uskId);
                //var _rates = await _rateService.GetAllRatesFromProv();

                var _rates = await _rateService.GetAllRatesFromDb();

                string descriptionEnum = Target.EUR.GetEnumDescription(); 

                var products = await _productService.GetTransactionsInTargetCurrency(descriptionEnum, _transactions, _rates.ToList());

                response.Data = null;
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
