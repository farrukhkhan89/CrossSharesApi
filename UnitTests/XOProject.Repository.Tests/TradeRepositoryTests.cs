using System;
using System.Threading.Tasks;
using NUnit.Framework;
using XOProject.Api.Model;
using XOProject.Repository.Domain;
using XOProject.Repository.Exchange;
using XOProject.Repository.Tests.Helpers;

namespace XOProject.Repository.Tests
{
    public class TradeRepositoryTests
    {
        private TradeRepository _tradeRepository;
        private ExchangeContext _context;

        [SetUp]
        public void Initialize()
        {
            _context = ContextFactory.CreateContext(true);
            _tradeRepository = new TradeRepository(_context);
        }

        [TearDown]
        public void Cleanup()
        {
            _context.Dispose();
            _context = null;
            _tradeRepository = null;
        }

        [Test]
        public async Task GetAsync_WhenExists_ReturnsHourlyShareRate()
        {
            // Arrange
            var expected = new TradeModel
            { PortfolioId = 4, Symbol = "CBI", NoOfShares = 70, Action = "SELL" };

            // Act
            var result = await _tradeRepository.GetAsync(4);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expected.PortfolioId, result.Id);
            Assert.AreEqual(expected.Symbol, result.Symbol);
            Assert.AreEqual(expected.NoOfShares, result.NoOfShares);
            Assert.AreEqual(expected.Action, result.Action);
        }

        [Test]
        public async Task GetAsync_WhenDoesNotExist_ReturnsNull()
        {
            // Arrange

            // Act
            var result = await _tradeRepository.GetAsync(99);

            // Assert
            Assert.IsNull(result);
        }
    }
}
