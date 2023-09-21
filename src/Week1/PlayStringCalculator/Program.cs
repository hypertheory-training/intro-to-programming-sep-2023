// See https://aka.ms/new-console-template for more information
using sc = StringCalculator;
Console.WriteLine("Let's Calculate Some Strings, Yo!");

var calculator = new sc.StringCalculator(new sc.RealLogger(), new sc.RealWebService());

while (true)
{
    Console.Write("Enter a string of numbers: ");
    var numbers = Console.ReadLine();
    var result = calculator.Add(numbers);

    Console.WriteLine(result);

}
