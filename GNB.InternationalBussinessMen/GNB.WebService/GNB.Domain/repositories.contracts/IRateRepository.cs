using GNB.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGNB.Domain.repositories.contracts
{
    public interface IRateRepository
    {
        Task<IEnumerable<RateModel>> GetAllRatesFromProvider();
        Task<IEnumerable<RateModel>> GetAll();
        Task DeleteRange(List<RateModel> rates);
        Task AddRage(List<RateModel> rates);
    }
}
