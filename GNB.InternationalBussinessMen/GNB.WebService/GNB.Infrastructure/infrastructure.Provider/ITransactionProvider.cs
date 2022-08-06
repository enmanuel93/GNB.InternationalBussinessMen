using GNB.Domain.Entities.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Infrastructure.infrastructure.Provider
{
    public interface ITransactionProvider
    {
        [Get("/transactions.json")]
        Task<IEnumerable<Transaction>> GetTransactions();
    }
}
