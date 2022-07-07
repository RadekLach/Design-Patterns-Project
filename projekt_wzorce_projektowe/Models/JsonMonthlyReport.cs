using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace projekt_wzorce_projektowe.Models
{
    public class JsonMonthlyReport : AbstractMonthlyReport   //Concrete product
    {
        public JsonMonthlyReport(List<Expense> expenses) : base(expenses)
        {
              
        }
        public override string GetReport()
        {
            return JsonSerializer.Serialize(_reportContent);
        }
    }
}
