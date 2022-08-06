using GGNB.Domain.repositories.contracts;
using GNB.Application.application.services;
using GNB.Domain.repositories.contracts;
using GNB.Infrastructure.Repositories.Rate;
using GNB.Infrastructure.Repositories.Transaction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNB.Api.Helpers
{
    public static class RegisterServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            if (services is null)
                return services;
            
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IRateService, RateService>();
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            return services;
        }
    }
}
