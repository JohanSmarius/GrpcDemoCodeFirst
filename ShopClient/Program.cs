using System;
using Grpc.Net.Client;
using GrpcService.Protos;

namespace ShopClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new ShopService.ShopServiceClient(channel);

            var request = new CreateCustomerRequest
            {
                Name = "Hello DotNED Saturday"
            };

            var response = client.CreateCustomer(request);

            Console.WriteLine($"Created {response.Name} with id {response.Id}");
            Console.ReadLine();
        }
    }
}
