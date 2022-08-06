using GNB.Domain.Entities;
using GNB.Domain.Entities.Models;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Infrastructure.infrastructure.Provider
{
    public class TransactionProvider
    {
        public static async Task<IEnumerable<Transaction>> GetTransactions()
        {
            var jsonData = RestService.For<ITransactionProvider>(Constants.Herokuapp);
            HttpResponseMessage response = await jsonData.GetTransactions();

            var strResponse = await response.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Transaction>>(strResponse));
        }
    }
}
