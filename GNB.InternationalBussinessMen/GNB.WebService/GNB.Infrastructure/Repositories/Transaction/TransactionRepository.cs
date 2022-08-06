using GNB.Domain.Contracts;
using GNB.Infrastructure.Data;
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

        public TransactionRepository()
        {
            gNBContext = new GNBContext();
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

        public async Task<IEnumerable<Domain.Entities.Models.Transaction>> GetAll()
        {
            return await gNBContext.Transactions.ToListAsync();
        }
    }
}
