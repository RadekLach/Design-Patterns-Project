using projekt_wzorce_projektowe.FileAccess;
using projekt_wzorce_projektowe.Models;
using projekt_wzorce_projektowe.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_wzorce_projektowe.Commands
{
    public class Receiver
    {
        private List<Expense> expenses = new List<Expense>(); // Receiver przechowuje wydatki
        private FileAccessor _fileAccessor;
        //logika biznesowa

        public Receiver(FileAccessor fileAccessor)
        {
            _fileAccessor = fileAccessor;
            expenses = _fileAccessor.Read();
        }
        public Expense AddExpense(Expense ex)
        {
            ex.Id = DateTime.Now.Ticks;
            expenses.Add(ex);
            Save();
            return ex;
        }
        public Expense DeleteExpense(long id)
        {
            var ex = expenses.SingleOrDefault(e => e.Id == id);
            if (ex != null)
            {
                expenses.Remove(ex);
            }
            Save();
            return ex;
        }
        private void Save()
        {
            _fileAccessor.Save(expenses);
        }
        public Expense GetExpense(long id)
        {
            return expenses.SingleOrDefault(e => e.Id == id);
        }
        public Expense UpdateExpense(Expense ex)
        {
            var expenseToUpdate = expenses.SingleOrDefault(e => e.Id == ex.Id);
            if (ex != null)
            {
                expenseToUpdate.Description = ex.Description;
                expenseToUpdate.Value = ex.Value;
                expenseToUpdate.Time = ex.Time;
            }
            Save();
            return expenseToUpdate;
        }

        public string GetMonthlyReport(ReportSerializationType type)
        {
            var factory = ReportFactory.GetInstance(type);
            return factory.GetMonthly(expenses);
        }
        public string GetYearlyReport(ReportSerializationType type)
        {
            var factory = ReportFactory.GetInstance(type);
            return factory.GetYearly(expenses);
        }
        
        public List <Expense> All()
        {
            return expenses.OrderBy(x=>x.Time).ToList();
        }
    }
}
