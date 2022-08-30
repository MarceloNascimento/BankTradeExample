using SampleBank.Challenge.BankTrades.Domain.Entities;
using SampleBank.Challenge.BankTrades.Domain.Interfaces.Repositories;
using SampleBank.Challenge.BankTrades.Infrastructure.Data.Context;
namespace SampleBank.Challenge.BankTrades.Infrastructure.Data.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DataContext context)
        : base(context: context)
        { }
    }
}
