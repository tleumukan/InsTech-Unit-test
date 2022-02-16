using Microsoft.AspNetCore.Mvc;
using MortgageCalculator.API.DTO;
using MortgageCalculator.API.Util;

namespace MortgageCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<double> GetPaymentPerPaymentSchedule([FromQuery] CalculatorDTO input)
        {
            var ans = new CalculatePayment(input);
            return ans.CalculatePaymentPerPaymentSchedule();
        }

    }
}