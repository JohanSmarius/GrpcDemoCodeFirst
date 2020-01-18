using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SynchronisationService.Protos;
using System;
using System.Collections.Generic;
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
            await foreach (var reading in requestStream.ReadAllAsync())
            {
                Console.WriteLine($"Received @ {reading.RegisteredAt.ToDateTime()} temp {reading.Temperature}");
            }

            return new Empty();

        }
    }
}
