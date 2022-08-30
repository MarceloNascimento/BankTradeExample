using MediatR;

namespace SampleBank.Challenge.BankTrades.API.ViewModels
{
    public class TradeSaveOrUpdateRequest : IRequest<TradeSaveOrUpdateViewModel>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Floor { get; set; }
        public string? Block { get; set; }
    }
}