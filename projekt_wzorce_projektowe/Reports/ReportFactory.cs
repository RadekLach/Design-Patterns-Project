using projekt_wzorce_projektowe.Commands;
using projekt_wzorce_projektowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_wzorce_projektowe.Reports
{
    public abstract class ReportFactory //Abstract Factory
    {
        protected abstract IReport Monthly(List<Expense> list); //utworzenie raportów
        protected abstract IReport Yearly(List<Expense> list);

        protected static Dictionary<ReportSerializationType, ReportFactory> _factories
            = new Dictionary<ReportSerializationType, ReportFactory>(); //referencje do pojedynczych instacji singletonowych fabryk
        public static ReportFactory GetInstance(ReportSerializationType type)
        {
            return _factories[type]; //pobranie z slownika wybranego singletona json/xml
        }


        public IReport GetMonthly(List<Expense> list) // some operation
        {
            return Monthly(list);
        }

        public IReport GetYearly(List<Expense> list) // some operation
        {
            return Yearly(list);
        }

    }
}
