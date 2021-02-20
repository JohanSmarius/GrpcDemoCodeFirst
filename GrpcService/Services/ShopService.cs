using System;
using System.Linq;
using System.Threading.Tasks;
using FinancialService.Contracts;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;
using Shop.Contracts;

namespace GrpcService.Services
{
    public class ShopService : IShopService
    {
        private readonly ILogger<ShopService> _logger;

        public ShopService(ILogger<ShopService> logger)
        {
            _logger = logger;
        }

        public ValueTask<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request)
        {
            _logger.LogInformation("Received customer", null);

            var response = new CreateCustomerResponse
            {
                Id = new Random().Next(1000),
                Name = request.Name
            };

            return new ValueTask<CreateCustomerResponse>(response);

        }

        public async ValueTask AddOrder(CreateOrderRequest request)
        {
            Console.WriteLine($"Received order placed at {request.OrderedAt.ToLongDateString()}");

            foreach (var orderLine in request.OrderLines)
            {
                Console.WriteLine($"Received {orderLine.ProductId}");
            }

            using var channel = GrpcChannel.ForAddress("https://localhost:5003");
            var financialService = channel.CreateGrpcService<IFinancialService>();
            await financialService.AddInvoice(new AddInvoiceRequest
            {
                Amount = request.OrderLines.Sum(line => line.Price * line.Quantity),
                CustomerId = request.CustomerId
            });
        }
    }
}