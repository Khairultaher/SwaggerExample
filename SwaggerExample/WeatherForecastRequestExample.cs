using Swashbuckle.AspNetCore.Filters;

namespace SwaggerExample
{

    public class WeatherForecastRequestExample : IExamplesProvider<WeatherForecast>
    {
        public WeatherForecast GetExamples()
        {
            return new WeatherForecast()
            {
                Id = 1,
                Date = DateTime.Now.AddDays(1),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = "test data"
            };
        }
    }
}
