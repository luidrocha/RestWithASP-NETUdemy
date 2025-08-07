using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("subtract/{firstNumber}/{secondNumber}")]
        public IActionResult GetSubtract(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }

            return BadRequest("Invalid Input");

        }

        [HttpGet("divide/{firstNumber}/{secondNumber}")]
        public IActionResult GetDevide(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }

            return BadRequest("Invalid Input");

        }

        [HttpGet("multply/{firstNumber}/{secondNumber}")]
        public IActionResult GetMultplay(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }

            return BadRequest("Invalid Input");

        }

        [HttpGet("raiz/{firstNumber}")]
        public IActionResult GetRaiz(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var result = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(result.ToString());
            }

            return BadRequest("Invalid Input");

        }

        // Metodos 

        private bool IsNumeric(string strNumber)
        {
            double number;
            // Verifica se o valor recebido é um numero considerando o Pais
            // Retorna true se a conversão funcionar e false se não funcionar
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;
        }


        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue))
            {

                return decimalValue;
            }
            return 0;
        }

       
    }
}
