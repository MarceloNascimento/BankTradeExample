using SampleBank.Challenge.BankTrades.Domain.Interfaces.Repositories;
using SampleBank.Challenge.BankTrades.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace SampleBank.Challenge.BankTrades.Infrastructure.CrossCutting
{
    [ExcludeFromCodeCoverage]
    public static class RepositoryServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITradeRepository, TradeRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            return services;
        }
    }
}