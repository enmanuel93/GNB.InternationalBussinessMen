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

        private List<RateModel> matchedCurrencyTargeRates;
        private List<RateModel> matchedTargetRates;

        public ProductDomainService()
        {
            //this.matchedCurrencyTargetTransactions = new List<Transaction>();
            //this.unmatchedCurrencyTargetTransactions = new List<Transaction>();
            //this.matchedCurrencyTargetRates = new List<RateModel>();
        }

        public void ConvertToCurrencyTarget(string target, List<Transaction> transactions, List<RateModel> rates)
        {
            //gets the currencies which don't need to be converted
            var matchedCurrencyTargetTransactions = transactions.Where(x => x.Currency == target).ToList();

            //gets the currencies which need to be converted
            var unmatchedCurrencyTargetTransactions = transactions.Where(x => x.Currency != target).OrderBy(o => o.Currency).ToList();

            matchedCurrencyTargeRates = rates.Where(x => x.To == target).ToList();

            var unmatchedCurrencyTargetRates = rates.Where(r => r.From != target).ToList();

            //ejemplo
            var example = unmatchedCurrencyTargetTransactions.Where(u => u.Currency == "CAD").ToList();
            ConvertCurrenyToRateTarget(example, unmatchedCurrencyTargetRates);
        }

        /// <summary>
        /// this method is going to work with the convertion of the currency 
        /// </summary>
        /// <returns></returns>
        private List<Transaction> ConvertCurrenyToRateTarget(List<Transaction> unmatchedTransactions, List<RateModel> matchedTargetRates)
        {
            int count = 0;
            matchedTargetRates = new List<RateModel>();

            foreach (var rt in matchedTargetRates)
            {
                foreach (var rtT in matchedCurrencyTargeRates)
                {
                    if (rt.To == rtT.From)
                        matchedTargetRates.Add(rt);
                }
            }
            return null;
        }
    }
}
