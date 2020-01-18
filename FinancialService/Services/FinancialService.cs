using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FinancialService.FinancialService;

namespace FinancialService.Services
{
    public class FinancialService : FinancialServiceBase
    {
        private readonly ILogger<FinancialService> _logger;

        public FinancialService(ILogger<FinancialService> logger)
        {
            _logger = logger;
        }

        public override Task<AddInvoiceResponse> AddInvoice(AddInvoiceRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AddInvoiceResponse());
        }
    }
}
