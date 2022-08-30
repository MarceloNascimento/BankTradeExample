using MediatR;

namespace SampleBank.Challenge.BankTrades.API.ViewModels
{
    public class TradeListAllRequest : IRequest<TradeListAllViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public int Block { get; set; }
    }
}