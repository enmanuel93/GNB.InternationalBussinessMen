using GNB.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using GNB.Domain.Entities;

namespace GNB.Infrastructure.infrastructure.Provider
{
    public class RateProvider
    { 
        public static async Task<IEnumerable<Rate>> GetRates()
        {
            var jsonData = RestService.For<IRateProvider>(Constants.Herokuapp);
            return await jsonData.GetRates();
        }
    }
}
