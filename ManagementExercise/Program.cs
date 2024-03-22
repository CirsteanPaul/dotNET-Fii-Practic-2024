// See https://aka.ms/new-console-template for more information


using ManagementExercise;

var database = new Database();
database.AddItem(new Customer()
{
    Name = "Added"
});

var customer = database.Customers.FirstOrDefault(x => x.Name == "paul");
database.PrintDb();