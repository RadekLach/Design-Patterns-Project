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
        public IReportCommand ReportCommand { get; set; }
        public object ExecuteCommand() //do zwracania odpowiedzi IExpenseCommand / API
        {
            return Command.Execute();
        }
        public string ExecuteReportCommand() //do zwracania odpowiedzi IReportCommand / API
        {
            return ReportCommand.Execute();
        }

    }
}
