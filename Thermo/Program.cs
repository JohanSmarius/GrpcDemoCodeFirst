using Grpc.Net.Client;
using System;
using static SynchronisationService.Protos.SynchronisationService;

namespace Thermo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var channel = GrpcChannel.ForAddress("https://localhost:5005");

            var client = new SynchronisationServiceClient(channel);




        }
    }
}
