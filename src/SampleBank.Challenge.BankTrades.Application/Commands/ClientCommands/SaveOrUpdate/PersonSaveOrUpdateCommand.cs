using SampleBank.Challenge.BankTrades.API.ViewModels;
using SampleBank.Challenge.BankTrades.Domain.Entities;
using SampleBank.Challenge.BankTrades.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
namespace SampleBank.Challenge.BankTrades.Application.Commands.ClientListAll
{
    public class ClientSaveOrUpdateCommand : IRequestHandler<ClientSaveOrUpdateRequest, ClientSaveOrUpdateViewModel>
    {
        protected readonly IClientRepository ClientRepository;
        protected readonly ITradeRepository TradeRepository;
        private readonly ILogger _logger;

        public ClientSaveOrUpdateCommand(ILogger logger, IClientRepository ClientRepository, ITradeRepository TradeRepository)
        {
            this._logger = logger;
            this.ClientRepository = ClientRepository;
            this.TradeRepository = TradeRepository;
        }

        public async Task<ClientSaveOrUpdateViewModel> Handle(ClientSaveOrUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null) return await Task.FromResult(new ClientSaveOrUpdateViewModel());

                var Trade = await TradeRepository.GetAsync(request.TradeId, cancellationToken);
                var entity = new Client()
                {
                    Id = request.Id,
                    Name = request.Name,                                                            
                    Created = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                };

                var TaskSaveOrUpdate = (entity.Id != 0) ? this.ClientRepository.InsertAsync(entity, cancellationToken)
                 : this.ClientRepository.UpdateAsync(entity, cancellationToken);

                var result = await TaskSaveOrUpdate;
                var viewModel = new ClientSaveOrUpdateViewModel()
                {
                    Id = result.Id,
                    Name = result.Name
                };

                return await Task.FromResult(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing result from {nameof(Handle)}", ex.Message);
                return await Task.FromResult(result: new ClientSaveOrUpdateViewModel());
            }
        }
    }
}