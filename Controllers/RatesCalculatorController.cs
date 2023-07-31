using GeicoRateCalculator.Request;
using GeicoRateCalculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeicoRateCalculator.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RatesCalculatorController : Controller
    {
        public IRatesCalculatorService _ratesCalculatorService { get; set; }
        public RatesCalculatorController(IRatesCalculatorService ratesCalculatorService)
        {
                _ratesCalculatorService = ratesCalculatorService;
        }
       

        [HttpGet("/calculate")]
        public async Task<IActionResult>  CalculateRateAsync([FromBody] RatesCalculatorDto ratesCalculatorDto )
        {
            //User //CostOfCar , //Age ,//DrivingRecord(points), //Location, //Sex , //IsElectric , 
            //Request validation

            var value = _ratesCalculatorService.CalculateRateAsync( ratesCalculatorDto.User, ratesCalculatorDto.Car );
            return Ok(value);
        }
    }
}
