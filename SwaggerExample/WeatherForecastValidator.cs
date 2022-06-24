using FluentValidation;

namespace SwaggerExample
{
    public class WeatherForecastValidator : AbstractValidator<WeatherForecast>
    {
        public WeatherForecastValidator()
        {

            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Date).NotNull().NotEmpty();
            RuleFor(x => x.TemperatureC).NotNull().NotEmpty();
            RuleFor(x => x.Summary).NotNull().NotEmpty().MaximumLength(5);
        }
    }
}
