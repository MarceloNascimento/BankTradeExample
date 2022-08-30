using Moq;
using Xunit;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using SampleBank.Challenge.BankTrades.Domain.Entities;
using SampleBank.Challenge.BankTrades.Domain.Interfaces.Repositories;
using SampleBank.Challenge.BankTrades.API.ViewModels;
using SampleBank.Challenge.BankTrades.Application.Commands.TradeInsert;

namespace SampleBank.Challenge.BankTrades.Tests
{
    public class TradeSaveOrUpdateCommandShould
    {
        private Mock<ITradeRepository> MockTradeRepository;
        private Mock<ILogger> _logger { get; set; }

        public TradeSaveOrUpdateCommandShould()
        {
            this._logger = new Mock<ILogger>();
            this.MockTradeRepository = new Mock<ITradeRepository>();
        }

        [Fact]
        public void SaveOrUpdateShouldReturnAparment()
        {
            //Arrange
            int TradeId = 104;
            var createdIn = new DateTime(2022, 07, 14);
            var entity = new Trade()
            {
                Id = TradeId,
                Name = "104",
                Floor = "1",
                Block = "7",
                Created = createdIn,
                LastUpdated = createdIn
            };
                        
            var mockLogger = new Mock<ILogger>();
            var request = new TradeSaveOrUpdateRequest()
            {
                Id = entity.Id,
                Name = entity.Name,
                Block = entity.Block,
                Floor = entity.Floor
            };

            //Act
            MockTradeRepository
                        .Setup(x => x.InsertAsync(entity, It.IsAny<CancellationToken>()))
                        .ReturnsAsync(entity);

            MockTradeRepository
                        .Setup(x => x.UpdateAsync(entity, It.IsAny<CancellationToken>()))
                        .ReturnsAsync(entity);

            MockTradeRepository
                        .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(entity);

            var sut = new TradeSaveOrUpdateCommand(mockLogger.Object,
                                            this.MockTradeRepository.Object);

            var response = sut.Handle(request, It.IsAny<CancellationToken>());

            //Asserts
            response.Result.Should().NotBeNull();
            response.Result.Should().BeOfType(typeof(TradeSaveOrUpdateViewModel));
        }
    }
}