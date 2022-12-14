using GNB.Api.Controllers;
using GNB.Application.application.services;
using GNB.Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Tests.Transactions.tests
{
    public class TransactionControllerTests
    {
        private readonly Mock<ITransactionService> _mockupService;
        private readonly Mock<ILogger<TransactionController>> _mLogger;

        public TransactionControllerTests()
        {
            _mockupService = new Mock<ITransactionService>();
            _mLogger = new Mock<ILogger<TransactionController>>();
        }

        [Test]
        public async Task GetTransactions_IfResultIsNotNull_ReturnOk()
        {
            var transactions = new List<Transaction>()
            {
                new Transaction(){ Sku ="EUR", Currency="USD", Amount = 1.359m},
                new Transaction(){ Sku ="CAD", Currency ="EUR", Amount = 0.732m},
            };

            _mockupService.Setup(m => m.GetAllTransactionsFromProv()).Returns(Task.FromResult(transactions));
            TransactionController rateController = new TransactionController(_mockupService.Object, _mLogger.Object);

            IActionResult response = await rateController.GetTransactions();
            ObjectResult controllerResponse = response as ObjectResult;

            Assert.IsNotNull(controllerResponse);
        }
    }
}
