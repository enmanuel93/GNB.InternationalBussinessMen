using GNB.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Application.application.services
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetAllTransactionsFromProv();
    }
}
