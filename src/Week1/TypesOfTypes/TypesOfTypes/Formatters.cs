namespace TypesOfTypes;
public class Formatters
{

    public static FormatNameResult FormatName(string firstName, string lastName)
    {
        var fullName = $"{firstName} {lastName}";
        var header = new string('#', fullName.Length);

        return new FormatNameResult(fullName, header, fullName.Length);

    }
}

// "Data Transfer Object"
public record FormatNameResult(string FullName, string Header, int LengthOfName);
