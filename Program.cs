using System.ComponentModel.DataAnnotations.Schema;
using FinanceManager;
using FinanceManager.Entities;
using FinanceManager.Entities.Enums;


//test
var db = new DataBase();
db.CreateTable();

db.CreateExpense(new Expense(200m, DateTime.Now, ExpenseCategory.Leisure, "Cinema"));

var expenses = db.ListExpenses();

foreach (var d in expenses)
{
        Console.WriteLine($"{d.Date.ToShortDateString()} - {d.Category} - {d.Value:C} - {d.Description}");
}