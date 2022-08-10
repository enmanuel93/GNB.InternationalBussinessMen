using GNB.Api.Controllers;
using GNB.Api.Helpers;
using GNB.Application.application.services;
using GNB.Domain.Entities.DTOs;
using GNB.Domain.Entities.Enums;
using GNB.Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Tests.Products.tests
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductService> _mockupService;
        private readonly Mock<IRateService> _mRateService;
        private readonly Mock<ITransactionService> _mTransactionService;

        public ProductsControllerTests()
        {
            _mockupService = new Mock<IProductService>();
            _mRateService = new Mock<IRateService>();
            _mTransactionService = new Mock<ITransactionService>();
    }

        [Test]
        public async Task GetProductsTransactions_IfResultIsNotNull_ReturnOk()
        {
            string target = Target.EUR.GetEnumDescription();
            string skuId = "N5608";

            var transactions = new List<Transaction>()
            {
                new Transaction(){ Sku ="N5608", Currency="EUR", Amount = 29.7000m},
                new Transaction(){ Sku ="L4810", Currency ="AUD", Amount = 34.9000m},
                new Transaction(){ Sku ="L4810", Currency="CAD", Amount = 19.6000m},
                new Transaction(){ Sku ="N5608", Currency ="EUR", Amount = 22.7000m},
                new Transaction(){ Sku ="C7138", Currency="USD", Amount = 21.0000m},
                new Transaction(){ Sku ="L4810", Currency ="CAD", Amount = 26.4000m},
                new Transaction(){ Sku ="C7138", Currency="USD", Amount = 34.2000m},
                new Transaction(){ Sku ="N5608", Currency ="AUD", Amount = 16.0000m},
            };

            var rates = new List<RateModel>()
            {
                new RateModel(){ From ="USD", To="EUR", Rate = 1.4400m},
                new RateModel(){ From ="USD", To ="CAD", Rate = 0.6900m},
                new RateModel(){ From ="CAD", To="USD", Rate = 0.9900m},
                new RateModel(){ From ="AUD", To ="EUR", Rate = 1.0100m},
            };                   


            _mockupService.Setup(m => m.GetTransactionsInTargetCurrency(target, transactions, rates)).Returns(GetProductDto(transactions, skuId));
            ProductsTransactionsController rateController = new ProductsTransactionsController(_mRateService.Object, _mTransactionService.Object, _mockupService.Object);
            
            IActionResult response = await rateController.GetProductsTransactions(skuId);
            ObjectResult controllerResponse = response as ObjectResult;

            Assert.IsNotNull(controllerResponse);
        }

        private async Task<ProductDto> GetProductDto(List<Transaction> transactions, string skuId)
        {
            var transactionsBySkuId = transactions.Where(x => x.Sku == skuId);

            var productDto = new ProductDto();

            productDto.transactions = transactions.Select(p => new Transaction
            {
                Amount = p.Amount,
                Currency = p.Currency,
                Sku = p.Sku
            }).ToList();

            productDto.TotalAmount = productDto.transactions.Sum(t => t.Amount);

            return productDto;
        }
    }
}
