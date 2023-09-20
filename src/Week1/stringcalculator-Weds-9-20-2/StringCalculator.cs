
namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {

        if (numbers == "") { return 0; }
        GuardAgainstNegativeNumbers(numbers);

        var (delimeters, processedNumbers) = ProcessNumbers(numbers);

        return processedNumbers.Split(delimeters).Select(int.Parse).Sum();

    }

    private static void GuardAgainstNegativeNumbers(string numbers)
    {
        if (numbers.Contains('-'))
        {
            throw new NoNegativeNumbersException();
        }
    }

    private (char[], string) ProcessNumbers(string numbers)
    {
        var delimeters = new List<char>
        {
            ',',
            '\n'
        };
        if (numbers.StartsWith("//"))
        {
            var newDelimeter = numbers.Substring(2, 1);
            numbers = numbers.Substring(4);
            delimeters.Add(char.Parse(newDelimeter));
        }

        return (delimeters.ToArray<char>(), numbers);
    }
}

public class NoNegativeNumbersException : ArgumentOutOfRangeException { };