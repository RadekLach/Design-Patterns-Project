using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projekt_wzorce_projektowe.Commands;
using projekt_wzorce_projektowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_wzorce_projektowe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private Receiver _receiver;
        public ExpenseController(Receiver receiver)
        {
            _receiver = receiver;
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
           var command = new GetExpenseCommand(_receiver,id);
           return Ok(command.Execute()); //zwróć status http
        }
        [HttpPost]
        public IActionResult Post([FromBody]Expense ex) // FromBody - pobranie z ciala zadania
        {
            var command = new AddExpenseCommand(_receiver,ex);
            return Ok(command.Execute()); //zwróć status http
        }
        [HttpPut]
        public IActionResult Update([FromBody] Expense ex) // FromBody - pobranie z ciala zadania
        {
            var command = new UpdateExpenseCommand(_receiver, ex);
            return Ok(command.Execute()); //zwróć status http
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var command = new DeleteExpenseCommand(_receiver, id);
            return Ok(command.Execute()); //zwróć status http
        }
    }
}
