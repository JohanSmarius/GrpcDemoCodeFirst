using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ProtoBuf.Grpc;
using WeatherForecaseStreamingService.Contracts;

namespace WeatherForecastService.Services
{
    public class WeatherForecastStreamingService : IWeatherForecastStreamingService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public IAsyncEnumerable<WeatherForecastStreamElement> GetWeatherForecastStream(CallContext context = default)
            => GetWeatherForecastStream(context.CancellationToken);

        private async IAsyncEnumerable<WeatherForecastStreamElement> GetWeatherForecastStream([EnumeratorCancellation]CancellationToken cancellationToken)
        {
            var randomGenerator = new Random();
            var index = 0;

            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(500, cancellationToken);

                var forecast = new WeatherForecastStreamElement
                {
                    Date = (DateTime.UtcNow.AddDays(index++)),
                    Temperature = randomGenerator.Next(-20, 55),
                    Summary = Summaries[randomGenerator.Next(Summaries.Length)]
                };

                yield return forecast;
            }


        }
    }
}