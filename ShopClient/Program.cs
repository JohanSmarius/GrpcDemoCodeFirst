using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using Shop.Contracts;

namespace ShopClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var shopService = channel.CreateGrpcService<IShopService>();

            var request = new CreateCustomerRequest
            {
                Name = "Hello SDN"
            };

            var response = await shopService.CreateCustomer(request);

            var orderLine1 = new CreateOrderLineRequest()
            {
                ProductId = 100,
                Price = 10,
                Quantity = 2
            };

            var orderLine2 = new CreateOrderLineRequest()
            {
                ProductId = 200,
                Price = 20,
                Quantity = 3
            };

            var order = new CreateOrderRequest()
            {
                CustomerId = response.Id,
                OrderedAt = DateTime.UtcNow
            };

            var orderLines = new List<CreateOrderLineRequest>
            {
                new CreateOrderLineRequest()
                {
                    ProductId = 100,
                    Price = 10,
                    Quantity = 2
                },
                new CreateOrderLineRequest()
                {
                    ProductId = 200,
                    Price = 20,
                    Quantity = 3
                }
            };

            order.OrderLines = orderLines;

            shopService.AddOrder(order);

            Console.WriteLine($"Created {response.Name} with id {response.Id}");
            Console.ReadLine();
        }
    }
}
