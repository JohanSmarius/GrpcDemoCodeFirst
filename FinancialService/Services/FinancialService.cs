using System;
using System.Threading.Tasks;
using FinancialService.Contracts;
using Microsoft.Extensions.Logging;

namespace FinancialService.Services
{
    public class FinancialService : IFinancialService
    {
        private readonly ILogger<FinancialService> _logger;

        public FinancialService(ILogger<FinancialService> logger)
        {
            _logger = logger;
        }

        public ValueTask AddInvoice(AddInvoiceRequest request)
        {
            Console.WriteLine($"Added invoice for {request.CustomerId} for amount {request.Amount}");

            return new ValueTask(Task.CompletedTask);
        }
    }
}