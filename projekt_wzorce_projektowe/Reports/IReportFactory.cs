using projekt_wzorce_projektowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_wzorce_projektowe.Reports
{
    public abstract class ReportFactory //Creator factory method
    {
        protected abstract IReport Monthly();
        protected abstract IReport Yearly();

        public string GetMonthly() // some operation
        {
            var report = Monthly();
            return report.GetReport();
        }

        public string GetYearly() // some operation
        {
            var report = Yearly();
            return report.GetReport();
        }

    }
}
