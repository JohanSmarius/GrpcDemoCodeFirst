using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorWAGrpc.Server.Protos;
using Grpc.Core;

namespace BlazorWAGrpc.Shared.Services
{
    public class StringService : Server.Protos.StringService.StringServiceBase
    {
        public override Task<StringReverseResponse> ReverseString(StringReverseRequest request, ServerCallContext context)
        {
            var charArray = request.Original.ToCharArray();
            Array.Reverse(charArray);
            

            var response = new StringReverseResponse()
            {
                Reversed = $"{new string(charArray)}"
            };

            return Task.FromResult(response);
        }
    }
}
