using ProtoBuf;

namespace Shop.Contracts
{
    [ProtoContract]
    public class CreateCustomerRequest
    {
        [ProtoMember(1)]
        public string Name { get; set; }
    }
}