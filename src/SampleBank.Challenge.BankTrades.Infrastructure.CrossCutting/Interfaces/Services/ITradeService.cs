using SampleBank.Challenge.BankTrades.Domain.Entities;

namespace SampleBank.Challenge.BankTrades.Infrastructure.CrossCutting.Interfaces
{
    public interface ITradeService
    {
        Client AddTrade(Client client, int TradeId);
        Client RemoveTrade(Client client, int TradeId);
        Client UpdateTrade(Client client, int TradeId);
        Client GetTrade(Client client, int TradeId);
    }
}
