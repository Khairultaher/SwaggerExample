using Microsoft.AspNetCore.Mvc;

namespace SwaggerExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 10).Select(index => new WeatherForecast
        //    {
        //        Id = index,
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        ///<param name="id" example="2">The product id</param>
        [HttpGet]
        [ProducesResponseType(typeof(WeatherForecast), 200)]
        [ProducesResponseType(400)]
        public ActionResult<WeatherForecast> Get([FromQuery] int id)
        {
            return Enumerable.Range(1, 5)
                .Select(index => new WeatherForecast
                {
                    Id = index,
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).Where(w => w.Id == id).FirstOrDefault()!;
        }


        [HttpPost]
        [ProducesResponseType(typeof(WeatherForecast), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<WeatherForecast>> Create([FromBody] WeatherForecast dto)
        {

            WeatherForecast weatherForecast = new WeatherForecast()
            {
                Id = 1,
                Date = DateTime.Now.AddDays(1),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };

            return await Task.FromResult(weatherForecast);  
        }
    }
}