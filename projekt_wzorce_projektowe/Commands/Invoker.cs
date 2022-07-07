using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_wzorce_projektowe.Commands
{
    public class Invoker 
    {
        public IExpenseCommand Command { get; set; }
        public object ExecuteCommand() //do zwracania odpowiedzi ICommand / API
        {
            return Command.Execute();
        }
    }
}
