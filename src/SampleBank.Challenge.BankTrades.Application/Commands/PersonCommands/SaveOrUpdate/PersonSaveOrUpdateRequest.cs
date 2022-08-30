using MediatR;

namespace SampleBank.Challenge.BankTrades.API.ViewModels
{
    public class ClientSaveOrUpdateRequest : IRequest<ClientSaveOrUpdateViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsResident { get; set; }
        public decimal? CondominiumFee { get; set; }
        public int TradeId { get; set; }
        public int Block { get; set; }
    }
}