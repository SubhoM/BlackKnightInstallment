using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackKnightInstallment.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlackKnightInstallment.Controllers
{
    [Route("api/Installment")]
    public class InstallmentController : Controller
    {
        private IInstallmentService _installmentService;

        public InstallmentController(IInstallmentService installmentService)
        {
            _installmentService = installmentService;
        }

        [HttpGet("GetInstallmentAmount/{TotalAmount}/{NoOfInstallments}")]
        public IActionResult GetInstallmentAmount(int TotalAmount, int NoOfInstallments)
        {
            try
            {
                if(NoOfInstallments == 0 || NoOfInstallments > 4)
                {
                    return BadRequest("Please enter a valid number between 1 and 4 for number of installments");
                }

                if (TotalAmount == 0)
                {
                    return BadRequest("Please enter a valid amount");
                }

                var lstInstallment = _installmentService.CalculateInstallment(TotalAmount, NoOfInstallments);

                return Ok(lstInstallment);
            }
            catch
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }
    }
}