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
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly ILogger<TransactionController> _logger;


        public TransactionController(ITransactionService transactionService, ILogger<TransactionController> logger)
        {
            this._transactionService = transactionService;
            this._logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            try
            {
                var result = await _transactionService.GetAllTransactionsFromProv();
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
