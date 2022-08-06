using GNB.Domain.Entities.Models;
using GNB.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GGNB.Domain.repositories.contracts;
using GNB.Infrastructure.infrastructure.Provider;

namespace GNB.Infrastructure.Repositories.Rate
{
    public class RateRepository : IRateRepository
    {
        private GNBContext gNBContext;

        public RateRepository(GNBContext _gNBContext)
        {
            gNBContext = _gNBContext;
        }

        public async Task AddRage(List<Domain.Entities.Models.RateModel> rates)
        {
            await gNBContext.Rates.AddRangeAsync(rates);
            await gNBContext.SaveChangesAsync();
        }

        public async Task DeleteRange(List<Domain.Entities.Models.RateModel> rates)
        {
            gNBContext.Rates.RemoveRange(rates);
            await gNBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Models.RateModel>> GetAll() => await gNBContext.Rates.ToListAsync();

        public async Task<IEnumerable<Domain.Entities.Models.RateModel>> GetAllRatesFromProvider() => await RateProvider.GetRates();
    }
}
