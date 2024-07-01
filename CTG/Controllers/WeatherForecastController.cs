using CTG.ContService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace CTG.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
          ContingencyCalculator calculator = new ContingencyCalculator();
            return calculator.Calculate(ContType.Line, 500, .04,800) + calculator.Calculate(ContType.Percent,500,.04);
        }

        [HttpPost(Name = "GetEstimateInfo")]
        public List<Factor> GetTabFactors( EstimateCalculationInfo est)
        {
            est.GetTotalCostConstruction();
            return est.GetFactors();
        }
    }
}
