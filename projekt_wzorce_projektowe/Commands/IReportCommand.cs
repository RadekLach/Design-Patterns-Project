using projekt_wzorce_projektowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_wzorce_projektowe.Commands
{

    public enum ReportSerializationType
    {
        Json,
        Xml
    }

    public interface IReportCommand
    {

        string Execute(); 

    }
}
