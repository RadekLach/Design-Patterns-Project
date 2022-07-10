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
        private Invoker _invoker;
        public ExpenseController(Receiver receiver, Invoker  invoker)
        {
            _receiver = receiver;
            _invoker = invoker;
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
           var command = new GetExpenseCommand(_receiver,id);
           _invoker.Command = command;
           return Ok(_invoker.ExecuteCommand()); //zwróć status http
        }
        [HttpPost]
        public IActionResult Post([FromBody]Expense ex) // FromBody - pobranie z ciala zadania
        {
            var command = new AddExpenseCommand(_receiver,ex);
            _invoker.Command = command;
            return Ok(_invoker.ExecuteCommand()); //zwróć status http
        }
        [HttpPut]
        public IActionResult Update([FromBody] Expense ex) // FromBody - pobranie z ciala zadania
        {
            var command = new UpdateExpenseCommand(_receiver, ex);
            _invoker.Command = command;
            return Ok(_invoker.ExecuteCommand()); //zwróć status http
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var command = new DeleteExpenseCommand(_receiver, id);
            _invoker.Command = command;
            return Ok(_invoker.ExecuteCommand()); //zwróć status http
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var command = new GetManyExpensesCommand(_receiver);
            _invoker.Command = command;
            return Ok(_invoker.ExecuteCommand()); //zwróć status http
        }
    }
}
