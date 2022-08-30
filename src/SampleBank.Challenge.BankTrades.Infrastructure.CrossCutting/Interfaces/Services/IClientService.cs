using SampleBank.Challenge.BankTrades.Domain.Entities;

namespace SampleBank.Challenge.BankTrades.Infrastructure.CrossCutting.Interfaces
{
    public interface IClientService
    {
        IList<Client>? ListEntries(Trade Trade);
        Client AddEntry(Client client);
        Client UpdateEntry(Client client);
        bool RemoveEntry(Client client);
    }
}
