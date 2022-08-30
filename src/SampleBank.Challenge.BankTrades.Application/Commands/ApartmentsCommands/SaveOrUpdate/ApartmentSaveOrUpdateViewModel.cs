namespace SampleBank.Challenge.BankTrades.API.ViewModels
{
    public struct TradeSaveOrUpdateViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Floor { get; set; }
        public string? Block { get; set; }
        public DateTime Created { get; set; }
    }
}