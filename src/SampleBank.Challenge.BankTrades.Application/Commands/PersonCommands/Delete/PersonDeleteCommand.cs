using MediatR;
using Microsoft.Extensions.Logging;
using SampleBank.Challenge.BankTrades.API.ViewModels;
using SampleBank.Challenge.BankTrades.Domain.Entities;
using SampleBank.Challenge.BankTrades.Domain.Interfaces.Repositories;

namespace SampleBank.Challenge.BankTrades.Application.Commands.ClientListAll
{
    public class ClientDeleteCommand : IRequestHandler<ClientDeleteRequest, ClientDeletedViewModel>
    {
        protected readonly IClientRepository ClientRepository;
        private readonly ILogger _logger;

        public ClientDeleteCommand(ILogger logger, IClientRepository ClientRepository)
        {
            this._logger = logger;
            this.ClientRepository = ClientRepository;
        }

        public async Task<ClientDeletedViewModel> Handle(ClientDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null || request.Id is 0) { return await Task.FromResult(new ClientDeletedViewModel()); }

                var Client = await this.ClientRepository.GetAsync(request.Id, cancellationToken);
                if (Client != null)
                {
                    var TaskDelete = this.ClientRepository.DeleteAsync(Client, cancellationToken);
                    return new ClientDeletedViewModel() { IsDeleted = await TaskDelete };
                }

                return new ClientDeletedViewModel() { IsDeleted = false };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing request from {nameof(Handle)}", ex.Message);
                return await Task.FromResult(new ClientDeletedViewModel());
            }
        }
    }
}