using GNB.Domain.domain.services;
using GNB.Domain.Entities.DTOs;
using GNB.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Application.application.services
{
    public class ProductService : IProductService
    {
        private readonly IProductDomainService _productDomainService;


        public ProductService(IProductDomainService productDomainService)
        {
            this._productDomainService = productDomainService;
        }

        public async Task<ProductDto> GetTransactionsInTargetCurrency(string target, List<Transaction> transactions, List<RateModel> rates)
        {
            _productDomainService.ConvertToCurrencyTarget(target, transactions, rates);

            return null;
        }
    }
}
