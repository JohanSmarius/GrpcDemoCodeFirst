using System;
using System.Linq;
using System.Threading.Tasks;
using FinancialService.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcService.Protos;
using Microsoft.Extensions.Logging;
using static FinancialService.Protos.FinancialService;

namespace GrpcService.Services
{
    public class ShopService : Protos.ShopService.ShopServiceBase
    {
        private readonly ILogger<ShopService> _logger;
        private readonly FinancialServiceClient _financialClient;

        public ShopService(ILogger<ShopService> logger, FinancialServiceClient financialClient)
        {
            _logger = logger;
            _financialClient = financialClient;
        }

        public override Task<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Received customer", null);

            var response = new CreateCustomerResponse
            {
                Id = new Random().Next(1000),
                Name = request.Name
            };

            return Task.FromResult(response);
        }

        public override async Task<Empty> AddOrder(CreateOrder request, ServerCallContext context)
        {
            Console.WriteLine($"Received order placed at {request.OrderedAt.ToDateTime().ToLongDateString()}");
            foreach (var orderLine in request.OrderLines)
            {
                Console.WriteLine($"Received {orderLine.ProductId}");
            }
            
            await _financialClient.AddInvoiceAsync(new AddInvoiceRequest
            {
                Amount = request.OrderLines.Sum(line => line.Price * line.Quantity),
                CustomerId = request.Customer
            });

            return new Empty();
        }
    }
}
