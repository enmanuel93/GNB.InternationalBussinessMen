﻿using GNB.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Domain.domain.services
{
    public interface IProductDomainService
    {
        void ConvertToCurrencyTarget(string target, List<Transaction> transactions, List<RateModel> rates);
    }
}
