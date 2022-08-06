using GNB.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using GNB.Domain.Entities;
using System.Net.Http;
using Newtonsoft.Json;

namespace GNB.Infrastructure.infrastructure.Provider
{
    public class RateProvider
    { 
        public static async Task<IEnumerable<RateModel>> GetRates()
        {
            var jsonData = RestService.For<IRateProvider>(Constants.Herokuapp);
            HttpResponseMessage response = await jsonData.GetRates();

            var strResponse = await response.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<RateModel>>(strResponse));
        }
    }
}
