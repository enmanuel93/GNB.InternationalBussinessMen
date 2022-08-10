using GNB.Domain.Entities.DTOs;
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
        private List<RateModel> currencyExchangeRatesThatNotMatchTarget;

        private Transaction exchangeCurrencyTransaction = new Transaction();

        public ProductDomainService()
        {
        }

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="target"></param>
        /// <param name="transactions"></param>
        /// <param name="rates"></param>
        /// <returns></returns>
        public ProductDto ConvertToCurrencyTarget(string target, List<Transaction> transactions, List<RateModel> rates)
        {
            //gets the currencies which don't need to be converted
            var transactionsInCurrentTarget = transactions.Where(x => x.Currency == target).ToList();

            //gets the currencies which need to be converted
            var transactionsToCarryToTargetCurrency = transactions.Where(x => x.Currency != target).OrderBy(o => o.Currency).ToList();

            //gets the rates which match with the currency target
            currencyExchangeRatesThatMatchTarget = rates.Where(x => x.To == target).OrderBy(o => o.From).ToList();


            var transactionsContainedInRateTarget = GetTransactionsWhichAreContainedInTheRateTarget(transactionsToCarryToTargetCurrency);


            //we are going to work with the transactions which need more than one currency exchange to get the target
            var transactionsNotContainedInRateTarget = GetTransactionsWhichAreNotContainedInTheRateTarget(transactionsToCarryToTargetCurrency);

            currencyExchangeRatesThatNotMatchTarget = GetRatesWhichAreNotContainedInTheRateTarget(rates, target).Where(t => t.From != target).ToList();


            foreach (var transaction in transactionsNotContainedInRateTarget)
            {
                ExchangeCurrenyToRatesThatMatchTarget(transaction, currencyExchangeRatesThatNotMatchTarget);
                if (exchangeCurrencyTransaction is not null)
                    transactionsContainedInRateTarget.Add(exchangeCurrencyTransaction);
            }


            var currenciesExchanged = ConvertFromCurrencyRateToCurrencyTarget(transactionsContainedInRateTarget);

            var totalTransactions = currenciesExchanged.Concat(transactionsInCurrentTarget).ToList();
            decimal totalAmountCalculated = CalculateTotalAmountOfProducts(totalTransactions);

            return new ProductDto
            {
                TotalAmount = totalAmountCalculated,
                transactions = totalTransactions
            };
        }

        private decimal CalculateTotalAmountOfProducts(List<Transaction> transactions) => RoundAmount(transactions.Sum(x => x.Amount));

        private decimal RoundAmount(decimal amount) => Math.Round(amount, 2);

        private void ExchangeCurrenyToRatesThatMatchTarget(Transaction transaction, List<RateModel> rates)
        { 
            var ratesItems = rates.Where(x => x.From == transaction.Currency).ToList();

            foreach (var item in ratesItems)
            {
                exchangeCurrencyTransaction = ExchangeCurrency(transaction, item);

                if (exchangeCurrencyTransaction == null)
                    continue;

                if (currencyExchangeRatesThatMatchTarget.Any(x => x.From == exchangeCurrencyTransaction.Currency))
                    break;

                ExchangeCurrenyToRatesThatMatchTarget(exchangeCurrencyTransaction, rates);
            }
        }

        private Transaction ExchangeCurrency(Transaction transaction, RateModel rate)
        {
            if (currencyExchangeRatesThatMatchTarget.Any(x => x.From == rate.To))
                return new Transaction { Id = transaction.Id, Sku = transaction.Sku, Currency = rate.To, Amount = transaction.Amount / rate.Rate };
            
            var rateWhichMatchedWithRateTarget = currencyExchangeRatesThatNotMatchTarget.Where(r => r.From == rate.To).ToList();

            //verify if there are any rate which matched
            var isRateFromMatchedWithAny = rateWhichMatchedWithRateTarget.Any(r => currencyExchangeRatesThatMatchTarget.Any(c => c.From == r.To));

            if (isRateFromMatchedWithAny)
                return new Transaction {Id = transaction.Id, Sku = transaction.Sku, Currency = rate.To, Amount = transaction.Amount / rate.Rate};

            return null;
        }

        private List<Transaction> GetTransactionsWhichAreContainedInTheRateTarget(List<Transaction> transactions) =>
            transactions.Where(t => currencyExchangeRatesThatMatchTarget.Any(c => c.From == t.Currency)).ToList();

        private List<Transaction> GetTransactionsWhichAreNotContainedInTheRateTarget(List<Transaction> transactions) =>
            transactions.Where(t => !currencyExchangeRatesThatMatchTarget.Any(c => c.From == t.Currency)).ToList();

        private List<RateModel> GetRatesWhichAreNotContainedInTheRateTarget(List<RateModel> rates, string target) =>
            rates.Where(t => !currencyExchangeRatesThatMatchTarget.Any(c => c.From == t.From)).ToList();


        private List<Transaction> ConvertFromCurrencyRateToCurrencyTarget(List<Transaction> transactions)
        {
            List<Transaction> currenciesExchanged = new List<Transaction>();

            foreach (var tr in transactions)
            {
                foreach (var mRates in currencyExchangeRatesThatMatchTarget)
                    if (tr.Currency == mRates.From)
                        currenciesExchanged.Add(new Transaction
                        {
                            Id = tr.Id,
                            Sku = tr.Sku,
                            Currency = mRates.To,
                            Amount = RoundAmount(tr.Amount / mRates.Rate)
                        });
            }

            return currenciesExchanged;
        }
    }
}
