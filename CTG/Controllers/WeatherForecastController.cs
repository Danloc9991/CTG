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


        [HttpGet]
        [Route("/tt")]
        public decimal getTabTotal()
        {
            decimal baseCost = 981527;
            decimal fee = 0.035m;
            decimal markups = 0.07m + 0.062m + 0.0435m;
            decimal DC = 0.04m;
            decimal total;

            total = (baseCost * (1 + DC)) / (1 - markups - DC * markups - (fee / (1 + fee)));


            decimal MarkupTotal = total * markups;
            decimal FeeTotal= (fee/(1 + fee))*total;
            decimal dctotal = (DC * (total - FeeTotal)) / (1 + DC);

           decimal totalTest= baseCost+ MarkupTotal+FeeTotal+dctotal;

            return total;
        }


        [HttpGet]
        [Route("/CompleteTotal")]
        public decimal getTabTotalComplete()
        {
            decimal baseCost = 981527;
            decimal fee = 0.035m;
            decimal markups = 0.07m + 0.062m + 0.0435m;
            decimal DC = 0.08m;
            decimal CC= 0.04m;
            decimal ESC= 0.04m;
            decimal DRF= 0.04m;
            decimal total;

            decimal CF = (1 + (1+DC)*(1+CC)*(1+ESC)*DRF + (1+DC)*(1+CC)*ESC+ (1+DC)*CC + DC);

            total = baseCost*CF/(1- (fee/(1+fee))-markups*CF);


            decimal feeTotal= (fee/(1+fee)) * total;
            decimal DFRtotal = (DRF / (1 + DRF)) * (total - feeTotal);
            decimal ESCTotal= (ESC / (1 + ESC)) * (total- feeTotal-DFRtotal);
            decimal CCTotal= (CC / (1 + CC)) * (total-feeTotal-DFRtotal-ESCTotal);
            decimal DCTotal= (DC / (1 + DC)) * (total - feeTotal - DFRtotal - ESCTotal-CCTotal);
            decimal MarkupTotal=markups*total;


            decimal resultTest= baseCost +MarkupTotal + feeTotal+DFRtotal+ESCTotal+CCTotal +DCTotal;


            return total;
        }
    }
}
