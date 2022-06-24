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


        /// <summary>
        /// Get WeatherForecast By Id
        /// </summary>
        ///<param name="id" example="2">The product id</param>
        /// <returns>Return success/fail status</returns>
        /// <remarks>
        /// **Sample request body:**
        ///
        ///     {
        ///        "id": 2
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="401">Failed/Unauthorized</response>

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


        /// <summary>
        /// Add new WeatherForecast
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Return success/fail status</returns>
        /// <remarks>
        /// **Sample request body:**
        ///
        ///     {
        ///        "id": 1,
        ///        "Date": "2022-06-24",
        ///        "TemperatureC": 30,
        ///        "Summary": "TemperatureC is 30 today",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="401">Failed/Unauthorized</response>
        [HttpPost]
        [ProducesResponseType(typeof(WeatherForecast), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<WeatherForecast>> Create([FromBody] WeatherForecast model)
        {

            WeatherForecast weatherForecast = new WeatherForecast()
            {
                Id = model.Id,
                Date = model.Date,
                TemperatureC =  model.TemperatureC,
                Summary = model.Summary
            };

            return await Task.FromResult(weatherForecast);  
        }
    }
}