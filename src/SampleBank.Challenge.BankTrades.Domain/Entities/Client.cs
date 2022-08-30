namespace SampleBank.Challenge.BankTrades.Domain.Entities
{
    public class Client : EntityBase
    {
        public Client()
        {
        }

        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string AgencyNumber { get; set; }
        public string BankNumber { get; set; }        
    }
}
