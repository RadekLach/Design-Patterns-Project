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
        private Facade _facade;
        public ExpenseController(Facade facade)
        {
            _facade = facade;
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
           return Ok(_facade.GetExpense(id)); //zwróć status http
        }
        [HttpPost]
        public IActionResult Post([FromBody]Expense ex) // FromBody - pobranie z ciala zadania
        {
            return Ok(_facade.AddExpense(ex)); //zwróć status http
        }
        [HttpPut]
        public IActionResult Update([FromBody] Expense ex) // FromBody - pobranie z ciala zadania
        {
            return Ok(_facade.EditExpense(ex)); //zwróć status http
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return Ok(_facade.RemoveExpense(id)); //zwróć status http
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            return Ok(_facade.ShowAllExpenses()); //zwróć status http
        }
    }
}
