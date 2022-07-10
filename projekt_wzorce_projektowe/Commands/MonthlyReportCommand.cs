using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projekt_wzorce_projektowe.Models;

namespace projekt_wzorce_projektowe.Commands
{
    public class MonthlyReportCommand : IReportCommand
    {
        private Receiver _receiver;
        private ReportSerializationType _type;

        public MonthlyReportCommand(Receiver receiver, ReportSerializationType type)
        {
            _receiver = receiver;
            _type = type;
        }

        public string Execute()
        {
            return _receiver.GetMonthlyReport(_type);
        }
    }
}
