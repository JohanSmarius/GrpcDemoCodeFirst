using FinancialService.Protos;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialService.Services
{
    public class FinancialService : Protos.FinancialService.FinancialServiceBase
    {
        private readonly ILogger<FinancialService> _logger;

        public FinancialService(ILogger<FinancialService> logger)
        {
            _logger = logger;
        }

        public override Task<AddInvoiceResponse> AddInvoice(AddInvoiceRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Added invoice for {request.CustomerId} for amount {request.Amount}");

            return Task.FromResult(new AddInvoiceResponse());
        }
    }
}
