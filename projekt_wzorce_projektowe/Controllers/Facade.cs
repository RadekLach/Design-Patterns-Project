using projekt_wzorce_projektowe.Commands;
using projekt_wzorce_projektowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_wzorce_projektowe.Controllers
{   //zarzadzanie systemem
    public class Facade
    {
        private Receiver _receiver; //subsystem
        private Invoker _invoker;
        public Facade()
        {
            _receiver = new Receiver();
            _invoker = new Invoker();
        }

        public object GetExpense(long id)
        {
            var command = new GetExpenseCommand(_receiver, id);
            _invoker.Command = command;
            var result = _invoker.ExecuteCommand();
            return result;
        }
        public object AddExpense(Expense ex)
        {
            var command = new AddExpenseCommand(_receiver, ex);
            _invoker.Command = command;
            return _invoker.ExecuteCommand(); 
        }
        public object EditExpense(Expense ex)
        {
            var command = new UpdateExpenseCommand(_receiver, ex);
            _invoker.Command = command;
            return _invoker.ExecuteCommand(); 
        }
        public object RemoveExpense(long id)
        {
            var command = new DeleteExpenseCommand(_receiver, id);
            _invoker.Command = command;
            return _invoker.ExecuteCommand(); 
        }
        public object ShowAllExpenses()
        {
            var command = new GetManyExpensesCommand(_receiver);
            _invoker.Command = command;
            return _invoker.ExecuteCommand(); 
        }

        public string GetYearlyReport(string type)
        {
            IReportCommand command;
            var serializationType = CheckType(type);
            command = new YearlyReportCommand(_receiver, serializationType);
            _invoker.ReportCommand = command;
            return _invoker.ExecuteReportCommand();
        }
        public string GetMonthlyReport(string type)
        {
            IReportCommand command;
            var serializationType = CheckType(type);
            command = new MonthlyReportCommand(_receiver, serializationType);
            _invoker.ReportCommand = command;
            return _invoker.ExecuteReportCommand();
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
    }
}
