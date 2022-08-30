using MediatR;
namespace SampleBank.Challenge.BankTrades.API.ViewModels
{
    public class TradeDeleteRequest : IRequest<TradeDeletedViewModel>
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Floor { get; set; }
        public int Block { get; set; }
    }
}