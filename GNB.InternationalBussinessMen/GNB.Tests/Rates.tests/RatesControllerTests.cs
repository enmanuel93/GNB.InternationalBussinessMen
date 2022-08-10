using GNB.Api.Controllers;
using GNB.Application.application.services;
using GNB.Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.Extensions.Logging;

namespace GNB.Tests.Rates.tests
{

    [TestFixture]
    public class RatesControllerTests
    {
        private readonly Mock<IRateService> _mockupService;
        private readonly Mock<ILogger<RateController>> _mLogger;

        public RatesControllerTests()
        {
            _mockupService = new Mock<IRateService>();
            _mLogger = new Mock<ILogger<RateController>>();

        }

        [Test]
        public async Task GetRates_IfResultIsNotNull_ReturnOk()
        {
            var rates = new List<RateModel>()
            {
                new RateModel(){ From ="USD", To="EUR", Rate = 1.4400m},
                new RateModel(){ From ="USD", To ="CAD", Rate = 0.6900m},
                new RateModel(){ From ="CAD", To="USD", Rate = 0.9900m},
                new RateModel(){ From ="AUD", To ="EUR", Rate = 1.0100m},
            };

            _mockupService.Setup(m => m.GetAllRatesFromProv()).Returns(Task.FromResult(rates));
            RateController rateController = new RateController(_mockupService.Object, _mLogger.Object);

            IActionResult response = await rateController.GetRates();
            ObjectResult controllerResponse = response as ObjectResult;

            Assert.IsNotNull(controllerResponse);
        }
    }
}
