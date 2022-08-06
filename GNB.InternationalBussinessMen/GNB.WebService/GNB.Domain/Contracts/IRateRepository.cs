using GNB.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Domain.Contracts
{
    public interface IRateRepository
    {
        Task<IEnumerable<Rate>> GetAll();
        Task DeleteRange(List<Rate> rates);
        Task AddRage(List<Rate> rates);
    }
}
