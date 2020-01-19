using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SynchronisationService.Protos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SynchronisationService.Services
{
    public class SynchronisationService : Protos.SynchronisationService.SynchronisationServiceBase
    {
        public SynchronisationService()
        {

        }

        public override async Task<Empty> AddTemperatureReading(IAsyncStreamReader<AddTemperatureReadingRequest> requestStream, 
            ServerCallContext context)
        {
            var callingClient = context.RequestHeaders.SingleOrDefault(header => header.Key.ToLower() == "clientid");

            await foreach (var reading in requestStream.ReadAllAsync())
            {
                Console.WriteLine($"Received @ {reading.RegisteredAt.ToDateTime()} temp {reading.Temperature} from {callingClient.Value}");
            }

            return new Empty();

        }
    }
}
