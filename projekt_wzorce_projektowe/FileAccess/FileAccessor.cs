using projekt_wzorce_projektowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace projekt_wzorce_projektowe.FileAccess
{
    public class FileAccessor
    {
        private readonly string _path = "DataBase.csv";
        public List<Expense> Read()
        {
            var result = new List<Expense>();
            var text = File.ReadAllText(_path);
            if (string.IsNullOrWhiteSpace(text))
                return result;
            var lines = text.Split(Environment.NewLine);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) break;
                var values = line.Split(",").ToArray();

                result.Add(new Expense
                {
                    Id = long.Parse(values[0]),
                    Value = decimal.Parse(values[1],CultureInfo.InvariantCulture),
                    Time = DateTime.Parse(values[2]),
                    Description = values[3]
                });   
            }
            return result;
        }
        public void Save(List<Expense> expenses)
        {
            File.WriteAllText(_path, string.Empty);

            foreach (var expense in expenses)
            {
                var line = $"{expense.Id},{expense.Value.ToString(CultureInfo.InvariantCulture)},{expense.Time:s},{expense.Description}{Environment.NewLine}";
                File.AppendAllText(_path,line);
            }
        }
    }
}
