using ProtoBuf;

namespace Shop.Contracts
{
    [ProtoContract]
    public class CreateOrderLineRequest
    {
        [ProtoMember(1)]
        public int ProductId { get; set; }

        [ProtoMember(2)]
        public int Quantity { get; set; }

        [ProtoMember(3)]
        public int Price { get; set; }
    }
}