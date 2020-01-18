using Grpc.Net.Client;
using System;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SynchronisationService.Protos;
using static SynchronisationService.Protos.SynchronisationService;

namespace Thermo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int clientId = new Random().Next(100);

            Console.WriteLine("Hello World!");

            var channel = GrpcChannel.ForAddress("https://localhost:5005");

            var client = new SynchronisationServiceClient(channel);

            var metaData = new Metadata();
            metaData.Add("ClientID", clientId.ToString());

            using (var call = client.AddTemperatureReading(metaData))
            {
                var timer = new System.Timers.Timer();
                var randomizer = new Random(Int32.MaxValue);
                timer.AutoReset = true;
                timer.Elapsed += (o, args) =>
                {
                    var request = new AddTemperatureReadingRequest()
                    {
                        RegisteredAt = Timestamp.FromDateTime(DateTime.UtcNow),
                        Temperature = 20.00 * randomizer.NextDouble()

                    };

                    call.RequestStream.WriteAsync(request);
                };

                timer.Start();

                var shouldEnd = Console.ReadLine();

                await call.RequestStream.CompleteAsync();
            }
        }
    }
}
