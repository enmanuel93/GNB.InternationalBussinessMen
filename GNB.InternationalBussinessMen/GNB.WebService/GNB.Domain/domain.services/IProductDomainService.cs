using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Domain.domain.services
{
    public interface IProductDomainService
    {
        void ConvertCurrency();
        decimal SumCurrencyByUsk();
    }
}
