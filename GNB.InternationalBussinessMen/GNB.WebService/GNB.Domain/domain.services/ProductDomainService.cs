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
        private List<RateModel> currencyExchangeRatesThatMatchTarget;

        public ProductDomainService()
        {
        }

        public void ConvertToCurrencyTarget(string target, List<Transaction> transactions, List<RateModel> rates)
        {
            //gets the currencies which don't need to be converted
            var transactionsInCurrentTarget = transactions.Where(x => x.Currency == target).ToList();

            //gets the currencies which need to be converted
            var transactionsToCarryToTargetCurrency = transactions.Where(x => x.Currency != target).OrderBy(o => o.Currency).ToList();

            //gets the rates which match with the currency target
            currencyExchangeRatesThatMatchTarget = rates.Where(x => x.To == target).ToList();


            var transactionsContainedInRateTarget = GetTransactionsWhichAreContainedInTheRateTarget(transactionsToCarryToTargetCurrency);


            //we are going to work with the transactions which need more than one currency exchange to get the target
            var transactionsNotContainedInRateTarget = GetTransactionsWhichAreNotContainedInTheRateTarget(transactionsToCarryToTargetCurrency);
            var currencyExchangeRatesThatNotMatchTarget = GetRatesWhichAreNotContainedInTheRateTarget(rates, target);



            //ejemplo            
            //List<string> unmatchedRatesCurrenciesNames = transactionsToCarryToTargetCurrency.Select(x => x.Currency).Distinct().ToList();

            var transaction2 = transactionsNotContainedInRateTarget.Where(u => u.Currency == "CAD").ToList();
            foreach (var transaction in transaction2)
            {
                var result1 = ExchangeCurrenyToRatesThatMatchTarget(transaction, currencyExchangeRatesThatNotMatchTarget);
                transactionsContainedInRateTarget.Add(result1);
            }           

            var example = transactionsContainedInRateTarget.Where(u => u.Currency == "AUD").ToList();
            var result2 = ConvertFromCurrencyRateToCurrencyTarget(example);
        }


        private Transaction ExchangeCurrenyToRatesThatMatchTarget(Transaction transaction, List<RateModel> rates)
        {
            //List<Transaction> transactions1 = new List<Transaction>();

            //var transaction2 = transactions.Where(u => u.Currency == "CAD").ToList();

            //foreach (var tr in transaction2)
            //{
            //    var rates2 = rates.Where(r => r.From == tr.Currency).ToList();

            //    var rates3 = rates2.Where(r2 => currencyExchangeRatesThatMatchTarget.Any(c => c.From == r2.To)).ToList();

            //    if (rates3.Any())
            //        foreach (var matchedRate in rates3)
            //        {
            //            transactions1.Add(new Transaction
            //            {
            //                Sku = tr.Sku,
            //                Currency = matchedRate.To,
            //                Amount = tr.Amount / matchedRate.Rate
            //            });

            //            break;
            //        }

            //}
            foreach (var item in rates)
            {
                if (transaction.Currency == item.From)
                {

                }
            }


            return null;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //private List<Transaction> ExchangeCurrenyToRatesThatMatchTarget(List<Transaction> transactions, List<RateModel> rates)
        //{
        //    List<Transaction> transactions1 = new List<Transaction>();

        //    var transaction2 = transactions.Where(u => u.Currency == "CAD").ToList();

        //    foreach (var tr in transaction2)
        //    {
        //        var rates2 = rates.Where(r => r.From == tr.Currency).ToList();

        //        var rates3 = rates2.Where(r2 => currencyExchangeRatesThatMatchTarget.Any(c => c.From == r2.To)).ToList();

        //        if (rates3.Any())
        //            foreach (var matchedRate in rates3)
        //            {
        //                transactions1.Add(new Transaction
        //                {
        //                    Sku = tr.Sku,
        //                    Currency = matchedRate.To,
        //                    Amount = tr.Amount / matchedRate.Rate
        //                });

        //                break;
        //            }

        //    }

        //    return transactions1;
        //}

        private List<Transaction> GetTransactionsWhichAreContainedInTheRateTarget(List<Transaction> transactions) =>
            transactions.Where(t => currencyExchangeRatesThatMatchTarget.Any(c => c.From == t.Currency)).ToList();

        private List<Transaction> GetTransactionsWhichAreNotContainedInTheRateTarget(List<Transaction> transactions) =>
            transactions.Where(t => currencyExchangeRatesThatMatchTarget.Any(c => c.From != t.Currency)).ToList();

        private List<RateModel> GetRatesWhichAreNotContainedInTheRateTarget(List<RateModel> rates, string target) =>
            rates.Where(t => currencyExchangeRatesThatMatchTarget.Any(c => c.From != t.From && t.From != target)).ToList();

        private List<Transaction> ConvertFromCurrencyRateToCurrencyTarget(List<Transaction> transactions)
        {
            List<Transaction> currenciesExchanged = new List<Transaction>();

            foreach (var tr in transactions)
            {
                foreach (var mRates in currencyExchangeRatesThatMatchTarget)
                    if (tr.Currency == mRates.From)
                        currenciesExchanged.Add(new Transaction
                        {
                            Sku = tr.Sku,
                            Currency = mRates.To,
                            Amount = tr.Amount / mRates.Rate
                        });
            }

            return currenciesExchanged;
        }
    }
}
