using Microsoft.Extensions.Logging;
using System;

namespace MoneytechTest.Application
{
    public class MathService : IMathService
    {
        private readonly ILogger<MathService> _logger;

        public MathService(ILogger<MathService> logger)
        {
            _logger = logger; //logger was added here to easily add logging functionality and any part of the code.
        }


        public ulong GetNextFibonaciNumber(ulong baseNumber)
        {
            var doubleResult = baseNumber * (1 + Math.Sqrt(5)) / 2.0;

            var ulongResult = (ulong)Math.Round(doubleResult);


            if (baseNumber > 0 && ulongResult < 1)
            {
                throw new ArithmeticException("Next Fibonacci number is outside the ulong max value");
            }

            return ulongResult;
        }
    }
}