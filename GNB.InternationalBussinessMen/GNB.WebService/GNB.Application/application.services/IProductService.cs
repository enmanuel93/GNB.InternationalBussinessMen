using GNB.Application.DTOs;
using GNB.Domain.Entities.Enums;
using GNB.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Application.application.services
{
    public interface IProductService
    {
        Task<ProductDto> GetTransactionsInTargetCurrency(string target, List<Transaction> transactions, List<RateModel> rates);
    }
}
