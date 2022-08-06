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
            IEnumerable<RateModel> result = new List<RateModel>();

            try
            {
                result = await _rateRepository.GetAllRatesFromProvider();
                var rates = result.ToList();

                await ResetDataFromRateTable(rates);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }

            result = await GetAllRatesFromDb();
            return result.ToList();            
        }

        public async Task ResetDataFromRateTable(List<RateModel> rates)
        {
            try
            {
                await _rateRepository.DeleteRange(rates);
                await _rateRepository.AddRage(rates);
            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        public async Task<IEnumerable<RateModel>> GetAllRatesFromDb() => await _rateRepository.GetAll();
    }
}
