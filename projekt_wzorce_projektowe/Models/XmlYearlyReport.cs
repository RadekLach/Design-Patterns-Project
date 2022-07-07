﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace projekt_wzorce_projektowe.Models
{
    public class XmlYearlyReport : AbstractYearlyReport   //Concrete product
    {

        public XmlYearlyReport(List<Expense> expenses) : base(expenses)
        {

        }
        public override string GetReport()
        {
            var report = new XmlReport
            {
                Entries = _reportContent.Select(x => new Entry { Date = x.Key, Sum = x.Value }).ToArray()
            };
            var Writer = new StringWriter();
            var serializer = new XmlSerializer(typeof(XmlReport));
            serializer.Serialize(Writer, report);
            return Writer.ToString();
        }
    }
}
