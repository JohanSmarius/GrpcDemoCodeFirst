using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace FinancialService.Contracts
{
    [ServiceContract(Name = "SDN.FinancialService")]
    public interface IFinancialService
    {
        [OperationContract]
        ValueTask AddInvoice(AddInvoiceRequest request);
    }
}
