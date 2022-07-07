using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace projekt_wzorce_projektowe.Models
{
    public abstract class AbstractYearlyReport : IReport //Abstract productA
    {
        protected Dictionary<string, decimal> _reportContent;
        private List<Expense> _expenses;
        public abstract string GetReport();

        public AbstractYearlyReport(List<Expense> expenses)
        {
            _expenses = expenses;
        }
        private void BuildReport() // wewnetrzna logika produktu
        {
            _reportContent = _expenses.GroupBy(e => e.Time.Year.ToString()) // pobranie wszystkich wydatkow i podzielenie ich na grupy ze wzgledu na rok
                .ToDictionary(x => x.Key, x => x.Sum(e=>e.Value)); // dla kazdej grupy zsumuj wydatki
        }
    }
}
