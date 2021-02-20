using System.ServiceModel;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shop.Contracts
{
    [ServiceContract(Name  = "SDN.ShopService")]
    public interface IShopService
    {
        [OperationContract]
        ValueTask<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request);

        [OperationContract]
        ValueTask AddOrder(CreateOrderRequest request);
    }
}

