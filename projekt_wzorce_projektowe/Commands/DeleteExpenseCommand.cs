using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projekt_wzorce_projektowe.Models;

namespace projekt_wzorce_projektowe.Commands
{
    public class DeleteExpenseCommand : IExpenseCommand
    {
        private Receiver _receiver;
        private long _id;
        public DeleteExpenseCommand(Receiver receiver, long id)
        {
            _receiver = receiver;
            _id = id;
        }
        public Expense Execute()
        {
            return _receiver.DeleteExpense(_id);
        }
    }
}
