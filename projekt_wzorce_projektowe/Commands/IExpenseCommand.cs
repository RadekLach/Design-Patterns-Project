using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projekt_wzorce_projektowe.Models;

namespace projekt_wzorce_projektowe.Commands
{
    public interface IExpenseCommand 
    {
        Expense Execute();
    }
}
