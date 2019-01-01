using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using XOProject.Api.Model;
using XOProject.Repository.Domain;
using XOProject.Repository.Exchange;
using XOProject.Services.Exchange;
using XOProject.Services.Tests.Helpers;

namespace XOProject.Services.Tests
{
    public class TradeServiceTests
    {
        private readonly Mock<ITradeRepository> _tradeRepositoryMock = new Mock<ITradeRepository>();

        private readonly TradeService _tradeService;

        public TradeServiceTests()
        {
            _tradeService = new TradeService(_tradeRepositoryMock.Object);
        }

        [TearDown]
        public void Cleanup()
        {
            _tradeRepositoryMock.Reset();
        }

        [Test]
        public async Task GetHourlyAsync_WhenExists_GetsHourlySharePrice()
        {
            // Arrange
            
            var trade = new TradeModel
            {
                Symbol = "CBI",
                Action = "SELL",
                NoOfShares = 70,
                PortfolioId = 1
            };

            // Act
            var result = await _tradeService.GetByIdAsync(4);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(trade, result);
            Assert.AreEqual(4, result.Id);
        }

        //private void ArrangeRates()
        //{
        //    var rates = new[]
        //    {
        //        new HourlyShareRate
        //        {
        //            Id = 1,
        //            Symbol = "CBI",
        //            Rate = 310.0M,
        //            TimeStamp = new DateTime(2017, 08, 17, 5, 0, 0)
        //        },
        //        new HourlyShareRate
        //        {
        //            Id = 2,
        //            Symbol = "CBI",
        //            Rate = 320.0M,
        //            TimeStamp = new DateTime(2018, 08, 16, 5, 0, 0)
        //        },
        //        new HourlyShareRate
        //        {
        //            Id = 3,
        //            Symbol = "REL",
        //            Rate = 300.0M,
        //            TimeStamp = new DateTime(2018, 08, 17, 5, 0, 0)
        //        },
        //        new HourlyShareRate
        //        {
        //            Id = 4,
        //            Symbol = "CBI",
        //            Rate = 300.0M,
        //            TimeStamp = new DateTime(2018, 08, 17, 5, 0, 0)
        //        },
        //        new HourlyShareRate
        //        {
        //            Id = 5,
        //            Symbol = "CBI",
        //            Rate = 400.0M,
        //            TimeStamp = new DateTime(2018, 08, 17, 6, 0, 0)
        //        },
        //        new HourlyShareRate
        //        {
        //            Id = 6,
        //            Symbol = "IBM",
        //            Rate = 300.0M,
        //            TimeStamp = new DateTime(2018, 08, 17, 5, 0, 0)
        //        },
        //    };
        //    _shareRepositoryMock
        //        .Setup(mock => mock.Query())
        //        .Returns(new AsyncQueryResult<HourlyShareRate>(rates));
        //}
    }
}
