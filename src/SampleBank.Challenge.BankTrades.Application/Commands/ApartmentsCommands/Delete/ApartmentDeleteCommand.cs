using Microsoft.Extensions.Logging;
using MediatR;
using SampleBank.Challenge.BankTrades.API.ViewModels;
using SampleBank.Challenge.BankTrades.Domain.Entities;
using SampleBank.Challenge.BankTrades.Domain.Interfaces.Repositories;

namespace SampleBank.Challenge.BankTrades.Application.Commands.TradesCommand
{
    public class TradeDeleteCommand : IRequestHandler<TradeDeleteRequest, TradeDeletedViewModel>
    {
        protected readonly ITradeRepository TradeRepository;
        private readonly ILogger _logger;

        public TradeDeleteCommand(ILogger logger, ITradeRepository TradeRepository)
        {
            _logger = logger;
            this.TradeRepository = TradeRepository;
        }

        public async Task<TradeDeletedViewModel> Handle(TradeDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null || request.Id is 0) { return await Task.FromResult(result: new TradeDeletedViewModel()); }

                var Trade = await this.TradeRepository.GetAsync(request.Id, cancellationToken);
                if (Trade != null)
                {
                    var TaskDelete = this.TradeRepository.DeleteAsync(Trade, cancellationToken);
                    return new TradeDeletedViewModel() { IsDeleted = await TaskDelete };
                }
                return new TradeDeletedViewModel() { IsDeleted = false };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing request from {nameof(Handle)}", ex.Message);
                return await Task.FromResult(new TradeDeletedViewModel());
            }
        }
    }
}