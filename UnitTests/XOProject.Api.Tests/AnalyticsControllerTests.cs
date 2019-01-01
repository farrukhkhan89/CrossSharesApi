using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using XOProject.Api.Controller;
using XOProject.Api.Model;
using XOProject.Services.Exchange;

namespace XOProject.Api.Tests
{
    class AnalyticsControllerTests
    {
        private readonly Mock<IAnalyticsService> _analyticsServiceMock = new Mock<IAnalyticsService>();

        private readonly AnalyticsController _analyticsController;

        public AnalyticsControllerTests()
        {
            _analyticsController = new AnalyticsController(_analyticsServiceMock.Object);
        }

        [TearDown]
        public void Cleanup()
        {
            _analyticsServiceMock.Reset();
        }

        [Test]
        public async Task Get_ShouldGetMonthly()
        {
            string symbol = "CBI";
            int year = 2018;
            int month = 8;
            // Act
            var result = await _analyticsController.Monthly(symbol,year,month);

            // Assert
            Assert.NotNull(result);

            var createdResult = result as CreatedResult;
            // Assert
            Assert.NotNull(createdResult);
            Assert.AreEqual(200, createdResult.StatusCode);
        }
    }
}
