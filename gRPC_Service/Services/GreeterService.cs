using Grpc.Core;
using gRPC_Service;
using gRPC_Service.Interface;

namespace gRPC_Service.Services
{
    public class GreeterService : Greeter.GreeterBase, IGreeter
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}