using ProtoBuf;

namespace Shop.Contracts
{
    [ProtoContract]
    public class CreateCustomerResponse
    {
        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public int Id { get; set; }
    }
}