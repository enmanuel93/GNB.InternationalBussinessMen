using GNB.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Domain.repositories.contracts
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllTransactionsFromProvider();
        Task<IEnumerable<Transaction>> GetAll();
        Task DeleteRange(List<Transaction> transactions);
        Task AddRage(List<Transaction> transactions);
    }
}
