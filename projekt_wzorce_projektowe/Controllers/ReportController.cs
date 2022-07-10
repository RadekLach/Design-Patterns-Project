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

        private Receiver _receiver;
        private Invoker _invoker;
        public ReportController(Receiver receiver, Invoker invoker)
        {
            _receiver = receiver;
            _invoker = invoker;
        }

        [HttpGet("yearly/{type}")]
        public IActionResult GetYearly(string type)
        {
            IReportCommand command;
            try
            {
                var serializationType = CheckType(type);
                command = new YearlyReportCommand(_receiver, serializationType);
                _invoker.ReportCommand = command;
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            return Ok(_invoker.ExecuteReportCommand());
        }

        private ReportSerializationType CheckType(string type)
        {
            return type switch
            {
                "json" => ReportSerializationType.Json,
                "xml" => ReportSerializationType.Xml,
                _ => throw new ArgumentException("Invalid serialization type")
            };
        }

        [HttpGet("monthly/{type}")]
        public IActionResult GetMonthly(string type)
        {
            IReportCommand command;
            try
            {
                var serializationType = CheckType(type);
                command = new MonthlyReportCommand(_receiver, serializationType);
                _invoker.ReportCommand = command;
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            return Ok(_invoker.ExecuteReportCommand());
        }

    }
}
