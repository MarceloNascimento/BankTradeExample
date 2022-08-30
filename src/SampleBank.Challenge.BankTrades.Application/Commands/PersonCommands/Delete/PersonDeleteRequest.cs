using MediatR;
namespace SampleBank.Challenge.BankTrades.API.ViewModels
{
    public class ClientDeleteRequest : IRequest<ClientDeletedViewModel>
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Floor { get; set; }
        public int Block { get; set; }
    }
}