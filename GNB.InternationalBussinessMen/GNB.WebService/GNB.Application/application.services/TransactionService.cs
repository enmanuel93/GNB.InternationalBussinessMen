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
            IEnumerable<Transaction> result = new List<Transaction>();

            try
            {
                result = await _transactioRepository.GetAllTransactionsFromProvider();
                var transactions = result.ToList();

                await ResetDataFromTransactionTable(transactions);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }

            result = await GetAllTransactionsFromDb();
            return result.ToList();
        }

        public async Task ResetDataFromTransactionTable(List<Transaction> transactions)
        {
            try
            {
                var result = await GetAllTransactionsFromDb();
                if (result.Any())
                    await _transactioRepository.DeleteRange(result.ToList());
                await _transactioRepository.AddRage(transactions);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Transaction>> FilterTransactionsByUskId(string uskId)
        {
            try
            {
                //var transactions = await GetAllTransactionsFromProv();
                //string us = transactions.FirstOrDefault().Sku;
                var transactions = await _transactioRepository.GetAll();
                return transactions.Where(x => x.Sku == uskId).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsFromDb() => await _transactioRepository.GetAll();
    }
}
