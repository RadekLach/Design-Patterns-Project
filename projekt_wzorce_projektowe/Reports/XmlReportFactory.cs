using projekt_wzorce_projektowe.Commands;
using projekt_wzorce_projektowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_wzorce_projektowe.Reports
{
    public class XmlReportFactory : ReportFactory //ConcreteCreator 
    {
        private XmlReportFactory()
        {

        }
        public static void CreateFactory()
        {
            _factories.Add(ReportSerializationType.Xml, new XmlReportFactory());
        }

        protected override IReport Monthly(List<Expense> list)
        {
            var report = new XmlMonthlyReport(list);
            return report;
        }

        protected override IReport Yearly(List<Expense> list)
        {
            var report = new XmlYearlyReport(list);
            return report;
        }
    }
}
