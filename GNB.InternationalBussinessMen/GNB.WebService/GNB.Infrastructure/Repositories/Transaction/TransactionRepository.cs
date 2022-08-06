using GNB.Domain.repositories.contracts;
using GNB.Infrastructure.Data;
using GNB.Infrastructure.infrastructure.Provider;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Infrastructure.Repositories.Transaction
{
    public class TransactionRepository : ITransactionRepository
    {
        private GNBContext gNBContext;

        public TransactionRepository(GNBContext _gNBContext)
        {
            gNBContext = _gNBContext;
        }

        public async Task AddRage(List<Domain.Entities.Models.Transaction> transactions)
        {
            await gNBContext.Transactions.AddRangeAsync(transactions);
            await gNBContext.SaveChangesAsync();
        }

        public async Task DeleteRange(List<Domain.Entities.Models.Transaction> transactions)
        {
            gNBContext.Transactions.RemoveRange(transactions);
            await gNBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Models.Transaction>> GetAll() => await gNBContext.Transactions.ToListAsync();

        public async Task<IEnumerable<Domain.Entities.Models.Transaction>> GetAllTransactionsFromProvider() => await TransactionProvider.GetTransactions();
        
    }
}
