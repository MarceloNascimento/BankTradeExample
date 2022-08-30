using MediatR;

namespace SampleBank.Challenge.BankTrades.API.ViewModels
{
    public class ClientListAllRequest : IRequest<ClientListAllViewModel>
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Floor { get; set; }
        public int Block { get; set; }
    }
}