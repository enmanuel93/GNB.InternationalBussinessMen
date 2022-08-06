using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GNB.Domain.Entities.Models;
using Refit;

namespace GNB.Infrastructure.infrastructure.Provider
{
    public interface IRateProvider
    {
        [Get("/rates.json")]
        Task<HttpResponseMessage> GetRates();
    }
}
