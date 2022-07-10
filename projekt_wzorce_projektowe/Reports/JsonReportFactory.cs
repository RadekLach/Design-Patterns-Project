using projekt_wzorce_projektowe.Commands;
using projekt_wzorce_projektowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_wzorce_projektowe.Reports
{
    public class JsonReportFactory : ReportFactory //ConcreteCreator 
    {
        private JsonReportFactory()
        {

        }
        public static void CreateFactory()
        {
            _factories.Add(ReportSerializationType.Json, new JsonReportFactory());
        }

        protected override IReport Monthly(List<Expense> list)
        {
            var report = new JsonMonthlyReport(list);
            return report;
        }

        protected override IReport Yearly(List<Expense> list)
        {
            var report = new JsonYearlyReport(list);
            return report;
        }
    }
}
