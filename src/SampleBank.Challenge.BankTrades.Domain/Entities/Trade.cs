namespace SampleBank.Challenge.BankTrades.Domain.Entities
{
    public class Trade : ITrade,EntityBase
    {
        public Trade() : base()
        {
        }

        public double Value { get;}
        public string ClientSector { get;}
        public DateTime NextPaymentDate { get;}
    }
}
