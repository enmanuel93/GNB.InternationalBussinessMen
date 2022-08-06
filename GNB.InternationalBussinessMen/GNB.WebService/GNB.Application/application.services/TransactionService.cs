using AutoMapper;
using GNB.Domain.Entities.Models;
using GNB.Domain.repositories.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Application.application.services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactioRepository;

        public TransactionService(ITransactionRepository transactioRepository)
        {
            this._transactioRepository = transactioRepository;
        }

        public async Task<List<Transaction>> GetAllTransactionsFromProv()
        {
            var result = await _transactioRepository.GetAllTransactionsFromProvider();
            return result.ToList();
        }
    }
}
