using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ProtoBuf;

namespace Shop.Contracts
{
    [ProtoContract]
    public class CreateOrderRequest
    {
        [ProtoMember(1)]
        public int CustomerId { get; set; }

        [ProtoMember(2)]
        public CustomerType CustomerType { get; set; }

        [ProtoMember(3, DataFormat =  DataFormat.WellKnown)]
        public DateTime OrderedAt { get; set; }

        [ProtoMember(4)]
        public IEnumerable<CreateOrderLineRequest> OrderLines { get; set; }
    }
}