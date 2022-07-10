using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_wzorce_projektowe.Models
{
    public abstract class AbstractMonthlyReport : IReport //Abstract productA
    {
        private List<Expense> _expenses;
        protected Dictionary<string, decimal> _reportContent;
        public abstract string GetReport();
        public AbstractMonthlyReport(List<Expense> expenses)
        {
            _expenses = expenses;
        }
        protected void BuildReport() // wewnetrzna logika produktu (tworzenia raportu)
        {
            _reportContent = _expenses.GroupBy(e => e.Time.ToString("yyyy-MM")) // pobranie wszystkich wydatkow i podzielenie ich na grupy ze wzgledu na rok
                .ToDictionary(x => x.Key, x => x.Sum(e => e.Value)); // dla kazdej grupy zsumuj wydatki
        }
    }
}
