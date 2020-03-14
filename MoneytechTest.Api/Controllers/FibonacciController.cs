using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoneytechTest.Application;
using MoneytechTest.WebApi.Model;
using System;
using System.Threading.Tasks;

namespace MoneytechTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FibonacciController : ControllerBase
    {
        private readonly IMathService _mathService;
        private readonly ILogger<FibonacciController> _logger;

        public FibonacciController(ILogger<FibonacciController> logger, IMathService mathService)
        {
            _logger = logger; //logger was injected here to easily add logging functionality and any part of the class.
            _mathService = mathService;
        }

        [HttpGet]
        [Route("{baseNumber}/NextNumber")]
        public async Task<IActionResult> GetNextFibonacciNumber(ulong baseNumber)
        {
            try
            {
                var result = await Task.Run(() => _mathService.GetNextFibonaciNumber(baseNumber));

                return Ok(new Fibonacci()
                {
                    NextFibonacciNumber = result
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}