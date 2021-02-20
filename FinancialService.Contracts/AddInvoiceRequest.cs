using ProtoBuf;

namespace FinancialService.Contracts
{
    [ProtoContract]
    public class AddInvoiceRequest
    {
        [ProtoMember(1)]
        public int CustomerId { get; set; }

        [ProtoMember(2)]
        public double Amount { get; set; }
    }
}