namespace SampleBank.Challenge.BankTrades.API.ViewModels
{
    public record TradeListAllViewModel
    {
        public IEnumerable<TradeListAllDto>? TradeDTOs { get; set; }        
    }
}