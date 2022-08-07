using GNB.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Domain.domain.services
{
    public class ProductDomainService : IProductDomainService
    {
        //private List<Transaction> matchedCurrencyTargetTransactions;
        //private List<Transaction> unmatchedCurrencyTargetTransactions;
        //private List<>

        private List<RateModel> matchedCurrencyTargetRates;

        public ProductDomainService()
        {
            //this.matchedCurrencyTargetTransactions = new List<Transaction>();
            //this.unmatchedCurrencyTargetTransactions = new List<Transaction>();
            //this.matchedCurrencyTargetRates = new List<RateModel>();
        }

        public void ConvertToCurrencyTarget(string target, List<Transaction> transactions, List<RateModel> rates)
        {
            var matchedCurrencyTargetTransactions = transactions.Where(x => x.Currency == target).ToList();
            var unmatchedCurrencyTargetTransactions = transactions.Where(x => x.Currency != target).ToList();
            matchedCurrencyTargetRates = rates.Where(x => x.To == target).ToList();

            //ejemplo
            var example = unmatchedCurrencyTargetTransactions.Where(u => u.Currency == "CAD").ToList();
            ConvertCurrenyToRateTarget(example);
        }

        /// <summary>
        /// this method is going to work with the convertion of the currency 
        /// </summary>
        /// <returns></returns>
        private List<Transaction> ConvertCurrenyToRateTarget(List<Transaction> unmatchedTransactions)
        {
            //unmatchedTransactions

            return null;
        }
    }
}
