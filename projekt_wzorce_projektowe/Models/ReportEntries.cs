using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_wzorce_projektowe.Models
{

    public class ReportEntries
    {
        public Entry[] Entries { get; set; }
    }

    public class Entry
    {
        public string Date { get; set; }
        public decimal Sum { get; set; }
    }
}
