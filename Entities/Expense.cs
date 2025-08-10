using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Entities.Enums;
namespace FinanceManager.Entities
{
    public class Expense
    {
        // Properties
        public decimal Value { get; private set; }
        public ExpenseCategory Category { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }

        // Constructors
        public Expense()
        {
            Description = "";
        }
        public Expense(decimal value, DateTime date, ExpenseCategory category ,string description = "")
        {
            Value = value;
            Date = date;
            Category = category;
            Description = description;
        }
    }
}