
using TypesOfTypes;

Console.WriteLine("Welcome to the App");
Console.Write("What is your first Name: ");
var firstName = Console.ReadLine();

Console.Write("What is your last Name: ");
var lastName = Console.ReadLine();

var formattedName = Formatters.FormatName(firstName, lastName);

Console.WriteLine(formattedName.FullName);

Console.Write(formattedName.Header);


