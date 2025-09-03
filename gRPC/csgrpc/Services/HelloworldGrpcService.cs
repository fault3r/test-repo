using System;
using csgrpc.Protos;
using Grpc.Core;

namespace csgrpc.Services
{
    public class HelloworldGrpcService : HelloworldService.HelloworldServiceBase
    {
        public override Task<HiReply> SayHi(HiRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HiReply { Message = "Hello World!" });
        }        
    }
}