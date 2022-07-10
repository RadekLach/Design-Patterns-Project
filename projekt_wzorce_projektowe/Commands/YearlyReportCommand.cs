using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace projekt_wzorce_projektowe.Commands
{
    public class YearlyReportCommand : IReportCommand
    {
        private Receiver _receiver;
        private ReportSerializationType _type;

        public YearlyReportCommand(Receiver receiver, ReportSerializationType type)
        {
            _receiver = receiver;
            _type = type;
        }

        public string Execute()
        {
            return _receiver.GetYearlyReport(_type);
        }
    }
}
