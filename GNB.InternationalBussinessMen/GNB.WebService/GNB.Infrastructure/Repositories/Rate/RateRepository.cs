using GNB.Domain.Contracts;
using GNB.Domain.Entities.Models;
using GNB.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Infrastructure.Repositories.Rate
{
    public class RateRepository : IRateRepository
    {
        private GNBContext gNBContext;

        public RateRepository()
        {
            gNBContext = new GNBContext();
        }

        public async Task AddRage(List<Domain.Entities.Models.Rate> rates)
        {
            await gNBContext.Rates.AddRangeAsync(rates);
            await gNBContext.SaveChangesAsync();
        }

        public async Task DeleteRange(List<Domain.Entities.Models.Rate> rates)
        {
            gNBContext.Rates.RemoveRange(rates);
            await gNBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Models.Rate>> GetAll()
        {
            return await gNBContext.Rates.ToListAsync();
        }
    }
}
