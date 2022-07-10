using projekt_wzorce_projektowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_wzorce_projektowe.Commands
{
    public class GetManyExpensesCommand : IExpenseCommand
    {
        private Receiver _receiver;
        public GetManyExpensesCommand(Receiver receiver)
        {
            _receiver = receiver;
        }
        public object Execute()
        {
            return _receiver.All();
        }
    }
}
