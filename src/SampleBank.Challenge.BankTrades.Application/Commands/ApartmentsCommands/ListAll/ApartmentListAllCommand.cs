using Microsoft.Extensions.Logging;
using MediatR;
using SampleBank.Challenge.BankTrades.API.ViewModels;
using SampleBank.Challenge.BankTrades.Domain.Interfaces.Repositories;

namespace SampleBank.Challenge.BankTrades.Application.Commands.TradeListAll
{
    public class TradeListAllCommand : IRequestHandler<TradeListAllRequest, TradeListAllViewModel>
    {
        protected readonly ITradeRepository TradeRepository;
        protected ILogger _logger { get; set; }

        public TradeListAllCommand(ILogger logger, ITradeRepository TradeRepository)
        {
            this._logger = logger;
            this.TradeRepository = TradeRepository;
        }

        public async Task<TradeListAllViewModel?> Handle(TradeListAllRequest request
            , CancellationToken cancellationToken)
        {
            try
            {
                var entitiesTaskList = this.TradeRepository.GetAllAsync(cancellationToken);
                var TradesViewModels = new TradeListAllViewModel
                {
                    TradeDTOs = new List<TradeListAllDto>()
                };


                if (entitiesTaskList == null) return null;

                TradesViewModels.TradeDTOs = (await entitiesTaskList)
                    .Select(item => new TradeListAllDto()
                {
                    Id = item.Id,
                    Name = item?.Name,
                    Block = item?.Block,
                    Floor = item?.Floor,
                    Created = item?.Created
                }).ToList();

                return await Task.FromResult(TradesViewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing request from {nameof(Handle)}", ex.Message);
                return await Task.FromResult(result: new TradeListAllViewModel());
            }
        }
    }
}