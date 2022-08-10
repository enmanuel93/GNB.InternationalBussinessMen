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

        [Test]
        public async Task GetRates_IfResultIsNotNull_ReturnOk()
        {
            //var rates = new List<RateModel>()
            //{
            //    new RateModel(){ From ="EUR", To="USD", Rate = 1.359m},
            //    new RateModel(){ From ="CAD", To ="EUR", Rate = 0.732m},
            //};

            //_mockupService.Setup(m => m.GetAllRatesFromProv()).Returns(Task.FromResult(rates));
            //RateController rateController = new RateController(_mockupService.Object);

            //IActionResult response = await rateController.GetRates();
            //ObjectResult controllerResponse = response as ObjectResult;

            //Assert.IsNotNull(controllerResponse);
        }
    }
}
