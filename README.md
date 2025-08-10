# My Personal Finance Manager :)

I started this console project to help me get my own finances in order. The idea was to have a simple tool to track my expenses

It's a C# project that uses a local SQLite database to store everything.

### What it can do so far

For now, the basics are up and running:

- It creates a local SQLite database, so no data gets lost.
- I can add new expenses, providing a value, category, date, and a description.
- The very next step is to build the feature for listing these expenses!

### Tech and Tools I Used

- **Language:** C# 
- **Database:** SQLite
  
### How the Code is Structured:

The project structure is

- A `Database` class handles all the SQLite stuff (connection, table creation, inserts).
- The `Expense` class is the model that represents each expense.
- An `enum` called `ExpenseCategory` defines the spending categories (e.g., Food, Transport).

### How to Run It:

1.  Make sure you have the .NET SDK installed.
2.  Run `dotnet build` to compile the project.
3.  Execute it with `dotnet run`.
4.  On startup, the app will create the database and table if they don't already exist. For now, expenses are added directly in the code, but I want to make this interactive soon.

### Next Steps;

- **The first thing I want to tackle** is implementing expense listing, with filters for date or category and add a deposit class
- **After that, the plan is** to create some simple reports, like a monthly summary of spending by category.
- **And maybe one day. I'll turn this console app into something with a more user-friendly graphical interface (GUI).
