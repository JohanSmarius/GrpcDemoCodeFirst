using System;
using ProtoBuf;

namespace WeatherForecaseStreamingService.Contracts
{
    [ProtoContract]
    public class WeatherForecastStreamElement
    {
        [ProtoMember(1, DataFormat = DataFormat.WellKnown)]
        public DateTime Date { get; set; }

        [ProtoMember(2)]
        public int Temperature { get; set; }

        [ProtoMember(3)]
        public string Summary { get; set; }
    }
}