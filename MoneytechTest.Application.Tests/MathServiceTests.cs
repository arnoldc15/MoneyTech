using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using Xunit;

namespace MoneytechTest.Application.Tests
{
    public class MathServiceTests
    {
        private static readonly Mock<ILogger<MathService>> LoggerMock = new Mock<ILogger<MathService>>();

        [Theory]
        [InlineData(1)]
        [InlineData(9000)]
        [InlineData(18000)]
        [InlineData(5000000000)]
        [InlineData(600000000000000)]
        public void WhenBaseNumberIsValid_ShouldNotThrowError(ulong baseNumber)
        {
            var service = new MathService(LoggerMock.Object);

            Should.NotThrow(() => service.GetNextFibonaciNumber(baseNumber));
        }


        [Theory]
        [InlineData(2, 3)]
        [InlineData(30000, 48541)]
        [InlineData(5000000000, 8090169944)]
        [InlineData(6000000000000000, 9708203932499370)]
        [InlineData(9800000000000000001, 15856733089748969472)]
        public void WhenBaseNumberIsValid_ShouldReturnExpectedResult(ulong baseNumber, ulong expected)
        {
            var service = new MathService(LoggerMock.Object);

            var result = service.GetNextFibonaciNumber(baseNumber);

            result.ShouldBe(expected);
        }

        [Fact]
        public void WhenBaseNumberIs0_ShouldReturn0()
        {
            var service = new MathService(LoggerMock.Object);

            var result = service.GetNextFibonaciNumber(0);

            result.ShouldBe((ulong)0);
        }

        [Fact]
        public void WhenBaseNumberIsMaxUlongValue_ShouldThrowArithmeticException()
        {
            var service = new MathService(LoggerMock.Object);

            Should.Throw<ArithmeticException>(() => service.GetNextFibonaciNumber(ulong.MaxValue));
        }





    }
}