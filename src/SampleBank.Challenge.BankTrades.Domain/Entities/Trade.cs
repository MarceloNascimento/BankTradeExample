using SampleBank.Challenge.BankTrades.Domain.Interfaces.Entities;

namespace SampleBank.Challenge.BankTrades.Domain.Entities
{
    public class Trade : ITrade
    {
        public Trade()
        {

        }

        public double Value { get;}
        public string ClientSector { get;}
        public DateTime NextPaymentDate { get;}
        public bool IsPoliticallyExposed { get; }
    }
}
