using SampleBank.Challenge.BankTrades.API.ViewModels;
using SampleBank.Challenge.BankTrades.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace SampleBank.Challenge.BankTrades.Application.Commands.ClientListAll
{
    public class ClientListAllCommand : IRequestHandler<ClientListAllRequest, ClientListAllViewModel>
    {
        protected readonly IClientRepository ClientRepository;
        private readonly ILogger _logger;

        public ClientListAllCommand(ILogger logger, IClientRepository ClientRepository)
        {
            this._logger = logger;
            this.ClientRepository = ClientRepository;
        }

        public async Task<ClientListAllViewModel> Handle(ClientListAllRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entitiesTaskList = this.ClientRepository.GetAllAsync(cancellationToken);
                var ClientsViewModels = new ClientListAllViewModel
                {
                    ClientDTOs = new List<ClientListAllDto>()
                };

                ClientsViewModels.ClientDTOs = (await entitiesTaskList).Select(item => new ClientListAllDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Block = item.Trade.Block,
                    Floor = item.Trade.Floor,
                    Created = item.Created
                }).ToList();

                return await Task.FromResult(ClientsViewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing request from {nameof(Handle)}", ex.Message);
                return await Task.FromResult(result: new ClientListAllViewModel());
            }
        }
    }
}