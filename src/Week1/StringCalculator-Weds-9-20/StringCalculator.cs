
namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        if (numbers == "") { return 0; }
        if (numbers.Contains('-')) { throw new NoNegativeNumbersException(); }

        var (delimeters, processNumbers) = ProcessNumbers(numbers);
        return processNumbers.Split(delimeters).Select(int.Parse).Sum();
    }
    private (char[], string) ProcessNumbers(string input)
    {
        var delimeters = new List<char>
        {
            ',', '\n'
        };
        if (input.StartsWith("//"))
        {
            var newDelimeter = input.Substring(2, 1);
            input = input[4..];
            delimeters.Add(char.Parse(newDelimeter));
        }
        return (delimeters.ToArray<char>(), input);
    }
}

public class NoNegativeNumbersException : ArgumentOutOfRangeException { }