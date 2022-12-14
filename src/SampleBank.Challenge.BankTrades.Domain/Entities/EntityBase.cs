
namespace SampleBank.Challenge.BankTrades.Domain.Entities
{
    public class EntityBase
    {
        protected EntityBase()
        {
            LastUpdated = DateTime.Now;
        }

        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastUpdated { get; set; }
    }
}
