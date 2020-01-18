using Grpc.Net.Client;
using System;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using SynchronisationService.Protos;
using static SynchronisationService.Protos.SynchronisationService;

namespace Thermo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var channel = GrpcChannel.ForAddress("https://localhost:5005");

            var client = new SynchronisationServiceClient(channel);

            using (var call = client.AddTemperatureReading())
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
