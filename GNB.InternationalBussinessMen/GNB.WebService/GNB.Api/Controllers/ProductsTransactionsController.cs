using GNB.Api.Helpers;
using GNB.Application.application.services;
using GNB.Domain.Entities.DTOs;
using GNB.Domain.Entities.Enums;
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
    public class ProductsTransactionsController : Controller
    {
        private readonly IRateService _rateService;
        private readonly ITransactionService _transactionService; 
        private readonly IProductService _productService;
        private readonly ILogger<ProductsTransactionsController> _logger;

        public ProductsTransactionsController(
            IRateService rateService, 
            ITransactionService transactionService, 
            IProductService productService,
            ILogger<ProductsTransactionsController> logger)
        {
            this._rateService = rateService;
            this._transactionService = transactionService;
            this._productService = productService;
            this._logger = logger;
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
        public async Task<IActionResult> GetProductsTransactions(string uskId)
        {
            ProductDto productsDto = new ProductDto();

            if (uskId == "") return BadRequest();

            try
            {
                var _transactions = await _transactionService.FilterTransactionsByUskId(uskId);
                var _rates = await _rateService.GetAllRatesFromDb();

                string descriptionEnum = Target.EUR.GetEnumDescription(); 

                productsDto = await _productService.GetTransactionsInTargetCurrency(descriptionEnum, _transactions, _rates.ToList());
                return Ok(productsDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }            
        }
    }
}
