using System;
using System.ComponentModel.DataAnnotations;
using Google.Protobuf.WellKnownTypes;
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

            var orderLine1 = new CreateOrderLine()
            {
                ProductId = 100,
                Price = 10,
                Quantity = 2
            };

            var orderLine2 = new CreateOrderLine()
            {
                ProductId = 200,
                Price = 20,
                Quantity = 3
            };

            var order = new CreateOrder()
            {
                Customer = response.Id,
                OrderedAt = Timestamp.FromDateTime(DateTime.UtcNow),
            };

            order.OrderLines.Add(orderLine1);
            order.OrderLines.Add(orderLine2);

            client.AddOrder(order);
            
            Console.WriteLine($"Created {response.Name} with id {response.Id}");
            Console.ReadLine();
        }
    }
}
