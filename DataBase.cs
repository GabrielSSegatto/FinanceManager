using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Entities;
using FinanceManager.Entities.Enums;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace FinanceManager
{
    public class DataBase
    {
        private const string connectionString = "Data Source=finances.db";

        public void CreateTable()
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                CREATE TABLE IF NOT EXISTS Expenses (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Value DECIMAL NOT NULL,
                    Category INTEGER NOT NULL,
                    Date TEXT NOT NULL,
                    Description TEXT
                );
            ";

            command.ExecuteNonQuery();

        }


        public void CreateExpense(Expense expense)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"
                    INSERT INTO Expenses (Value, Category, Date, Description)
                    VALUES ($value, $Category, $date, $description);
                ";

            command.Parameters.AddWithValue("$value", expense.Value);
            command.Parameters.AddWithValue("$Category", (int)expense.Category);
            command.Parameters.AddWithValue("$date", expense.Date.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("$description", expense.Description ?? "");

            command.ExecuteNonQuery();
        }

        public List<Expense> ListExpenses()
        {
            var expenses = new List<Expense>();

            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Value, Category, Date, Description from Expenses;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var value = reader.GetDecimal(0);
                var category = (ExpenseCategory)reader.GetInt32(1);
                var date = DateTime.Parse(reader.GetString(2));
                var description = reader.IsDBNull(3) ? "" : reader.GetString(3);

                var expense = new Expense(value, date, category, description);
                expenses.Add(expense);
            }

            return expenses;

        }
    }


}