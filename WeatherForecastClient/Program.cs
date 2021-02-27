using System;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using WeatherForecaseStreamingService.Contracts;

namespace WeatherForecastClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var terminateDemo = 0;

            CancellationTokenSource _cancellationTokenSource = new();

            try
            {
                using var channel = GrpcChannel.ForAddress("https://localhost:6001");
                var weatherForecastService = channel.CreateGrpcService<IWeatherForecastStreamingService>();

                await foreach (var weatherData in weatherForecastService.GetWeatherForecastStream(
                    context: _cancellationTokenSource.Token).WithCancellation(_cancellationTokenSource.Token))
                {
                    Console.WriteLine(
                        $"Forecast {terminateDemo} {weatherData.Date.ToLongDateString()} {weatherData.Temperature} {weatherData.Summary}");

                    ++terminateDemo;

                    if (terminateDemo > 100)
                    {
                        _cancellationTokenSource.Cancel();
                    }
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Cancelled)
            {
                // Save to ignore
            }
        }
    }
}
