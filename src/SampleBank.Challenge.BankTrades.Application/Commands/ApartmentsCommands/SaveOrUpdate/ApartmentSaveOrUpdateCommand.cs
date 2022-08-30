using Microsoft.Extensions.Logging;
using MediatR;
using SampleBank.Challenge.BankTrades.API.ViewModels;
using SampleBank.Challenge.BankTrades.Domain.Entities;
using SampleBank.Challenge.BankTrades.Domain.Interfaces.Repositories;

namespace SampleBank.Challenge.BankTrades.Application.Commands.TradeInsert
{
    public class TradeSaveOrUpdateCommand : IRequestHandler<TradeSaveOrUpdateRequest, TradeSaveOrUpdateViewModel>
    {
        protected readonly ITradeRepository TradeRepository;
        private readonly ILogger _logger;

        public TradeSaveOrUpdateCommand(ILogger Logger, ITradeRepository TradeRepository)
        {
            this._logger = Logger;
            this.TradeRepository = TradeRepository;
        }

        public async Task<TradeSaveOrUpdateViewModel> Handle(TradeSaveOrUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null) return await Task.FromResult(new TradeSaveOrUpdateViewModel());
                var entity = new Trade()
                {
                    Id = request.Id,
                    Name = request.Name,
                    Block = request.Block,
                    Floor = request.Floor,
                    Created = DateTime.UtcNow
                };

                var entityResult = (entity.Id != 0) ?
                    this.TradeRepository.InsertAsync(entity, cancellationToken)
                  : this.TradeRepository.UpdateAsync(entity, cancellationToken);

                var id = entityResult.Id;
                var taskEntityResult = this.TradeRepository.GetAsync(id, cancellationToken);

                var result = await taskEntityResult;
                var viewModel = new TradeSaveOrUpdateViewModel()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Block = result.Block,
                    Floor = result.Floor,
                    Created = result.Created
                };

                return await Task.FromResult(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing result from {nameof(Handle)}", ex.Message);
                return await Task.FromResult(result: new TradeSaveOrUpdateViewModel());
            }
        }
    }
}