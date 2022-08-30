using Moq;
using Xunit;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using SampleBank.Challenge.BankTrades.Domain.Entities;
using SampleBank.Challenge.BankTrades.Domain.Interfaces.Repositories;
using SampleBank.Challenge.BankTrades.API.ViewModels;
using SampleBank.Challenge.BankTrades.Application.Commands.TradeListAll;

namespace SampleBank.Challenge.BankTrades.Tests
{
    public class TradeListAllCommandShould
    {
        protected readonly Mock<ITradeRepository> MockTradeRepository;

        public TradeListAllCommandShould()
        {
            this.MockTradeRepository = new Mock<ITradeRepository>();
        }

        [Fact]
        public void ListAllAparmentThatShouldNotBeNull()
        {
            //Arrange                      
            int TradeId = 104;
            var createdIn = new DateTime(2022, 07, 14);
            var Trade = new Mock<Trade>().Object;            

            IList<Trade>? aparmentList = new List<Trade>() { Trade };
            var expectedRepositoryList = Task.FromResult(aparmentList);

            var mocklogger = new Mock<ILogger>();
            var request = new TradeListAllRequest();

            //Act
                           
            var taskTrade = new TradeListAllViewModel()
            {
                TradeDTOs = aparmentList.Select(item => new TradeListAllDto()
                {
                    Id = item.Id,
                    Name = item?.Name,
                    Block = item?.Block,
                    Floor = item?.Floor,
                    Created = item?.Created
                }).ToList()
            };
                        
            _= MockTradeRepository
                           .Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
                           .Returns(expectedRepositoryList);
            
            var sut = new TradeListAllCommand(mocklogger.Object, this.MockTradeRepository.Object);            
            var response = sut.Handle(request, It.IsAny<CancellationToken>());
            var expectedResponse = Task.FromResult(taskTrade);

            //Asserts
            response.Result.Should().NotBeNull();            
            response.Result.Should().BeAssignableTo(typeof(TradeListAllViewModel));
            _ = response.Result.TradeDTOs.Should().BeEquivalentTo(expectedResponse.Result.TradeDTOs);
        }
    }
}