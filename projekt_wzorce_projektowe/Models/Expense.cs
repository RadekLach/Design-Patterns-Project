using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_wzorce_projektowe.Models
{
    public class Expense
    {
        public long Id { get; set; }
        public decimal Value { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
    }
}
