using AutoMapper;
using GGNB.Domain.repositories.contracts;
using GNB.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Application.application.services
{
    public class RateService: IRateService
    {
        private readonly IRateRepository _rateRepository;

        public RateService(IRateRepository rateRepository)
        {
            this._rateRepository = rateRepository;
        }

        public async Task<List<RateModel>> GetAllRatesFromProv()
        {
            var result = await _rateRepository.GetAllRatesFromProvider();
            return result.ToList();
        }
    }
}
