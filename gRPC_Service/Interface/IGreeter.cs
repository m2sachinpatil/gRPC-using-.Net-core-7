using Grpc.Core;

namespace gRPC_Service.Interface
{
    public interface IGreeter
    {
        Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context);
    }
}
