﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projekt_wzorce_projektowe.Models;

namespace projekt_wzorce_projektowe.Commands
{
    public class AddExpenseCommand : IExpenseCommand
    {
        private Receiver _receiver;
        private Expense _expense;
        public AddExpenseCommand(Receiver receiver, Expense expense)
        {
            _receiver = receiver;
            _expense = expense;
        }
        public object Execute()
        {
            return _receiver.AddExpense(_expense);
        }
    }
}
