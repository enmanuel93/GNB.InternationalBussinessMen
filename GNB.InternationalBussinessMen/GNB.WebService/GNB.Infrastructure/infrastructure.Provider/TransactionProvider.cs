using GNB.Domain.Entities;
using GNB.Domain.Entities.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Infrastructure.infrastructure.Provider
{
    public class TransactionProvider
    {
        public static async Task<IEnumerable<Transaction>> GetTransactions()
        {
            var jsonData = RestService.For<ITransactionProvider>(Constants.Herokuapp);
            return await jsonData.GetTransactions();
        }
    }
}
