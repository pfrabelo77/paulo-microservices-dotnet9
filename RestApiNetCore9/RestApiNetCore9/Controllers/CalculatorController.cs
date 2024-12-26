using Microsoft.AspNetCore.Mvc;

namespace RestApiNetCore9.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Soma/{firstNumber}/{secondNumber}")]
        public IActionResult Soma(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("Subtracao/{firstNumber}/{secondNumber}")]
        public IActionResult Subtracao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var subtracao = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(subtracao.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("Multiplicacao/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplicacao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var multiplicacao = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(multiplicacao.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("Media/{firstNumber}/{secondNumber}")]
        public IActionResult Media(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2;
                return Ok(media.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("RaizQuadrada/{firstNumber}")]
        public IActionResult RaizQuadrada(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var raizQuadrada = ConvertToDecimal(firstNumber);
                if (raizQuadrada < 0)
                {
                    return BadRequest("O valor deve ser maior que zero.");
                }
                double dblRaizQuadrada = Math.Sqrt((double)raizQuadrada);
                return Ok(dblRaizQuadrada.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string number)
        {
            decimal valorDecimal;
            bool isNumber = decimal.TryParse(number, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out valorDecimal);
            return isNumber;
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal valorDecimal;
            if (decimal.TryParse(number, out valorDecimal))
            {
                return valorDecimal;
            }
            return 0; ;
        }

    }
}
