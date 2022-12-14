using GNB.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Application.application.services
{
    public interface IRateService
    {
        Task<List<RateModel>> GetAllRatesFromProv();
        Task ResetDataFromRateTable(List<RateModel> rates);
        Task<IEnumerable<RateModel>> GetAllRatesFromDb();
    }
}
