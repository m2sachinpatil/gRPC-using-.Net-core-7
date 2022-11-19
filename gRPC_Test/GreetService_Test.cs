using gRPC_Service.Services;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.Extensions.Logging;
using System.Collections.Specialized;
using System.Reflection.Metadata.Ecma335;

namespace gRPC_Test
{
    public class Tests
    {
        private GreeterService _greeterService;
        private readonly ILogger<GreeterService>? _logger;

        [SetUp]
        public void Setup()
        {
            _greeterService = new GreeterService(_logger);
        }

        [Test]
        [TestCase("", ExpectedResult = "Hello ")]
        [TestCase("Sachin", ExpectedResult = "Hello Sachin")]
        public async Task<string> Greeter_Service_Success(string input)
        {
            // Arrange
            var request = new gRPC_Service.HelloRequest()
            {
                Name = input
            };

            //Act
            var result = await _greeterService.SayHello(request, null);

            //Assert
           return result.Message;

        }

    }
}