using projekt_wzorce_projektowe.Commands;
using projekt_wzorce_projektowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_wzorce_projektowe.Reports
{
    public abstract class ReportFactory //Creator factory method
    {
        protected abstract IReport Monthly(List<Expense> list);
        protected abstract IReport Yearly(List<Expense> list);

        protected static Dictionary<ReportSerializationType, ReportFactory> _factories
            = new Dictionary<ReportSerializationType, ReportFactory>(); //referencje do pojedynczych instacji singletonowych fabryk
        public static ReportFactory GetInstance(ReportSerializationType type)
        {
            return _factories[type];
        }


        public string GetMonthly(List<Expense> list) // some operation
        {
            var report = Monthly(list);
            return report.GetReport();
        }

        public string GetYearly(List<Expense> list) // some operation
        {
            var report = Yearly(list);
            return report.GetReport();
        }

    }
}
