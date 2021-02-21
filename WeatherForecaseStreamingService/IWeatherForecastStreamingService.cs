using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Xml;
using ProtoBuf.Grpc;

namespace WeatherForecaseStreamingService.Contracts
{
    [ServiceContract(Name = "SDN.WeaterForecaseStreamingService")]
    public interface IWeatherForecastStreamingService
    {
        [OperationContract]
        IAsyncEnumerable<WeatherForecastStreamElement> GetWeatherForecastStream(CallContext context = default);
    }
}
