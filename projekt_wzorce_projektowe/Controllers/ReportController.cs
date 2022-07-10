using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projekt_wzorce_projektowe.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_wzorce_projektowe.Controllers
{



    [Route("api/[controller]")] //do zwrotu raportów
    [ApiController]
    public class ReportController : ControllerBase
    {

        private Facade _facade;
        public ReportController(Facade facade)
        {
            _facade = facade;
        }

        [HttpGet("yearly/{type}")]
        public IActionResult GetYearly(string type)
        {
            string result;
            try
            {
                result = _facade.GetYearlyReport(type);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            return Ok(result);
        }



        [HttpGet("monthly/{type}")]
        public IActionResult GetMonthly(string type)
        {
            string result;
            try
            {
                result = _facade.GetMonthlyReport(type);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            return Ok(result);
        }

    }
}
