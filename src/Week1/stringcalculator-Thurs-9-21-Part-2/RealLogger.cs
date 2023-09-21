namespace StringCalculator;
public class RealLogger : ILogger
{
    public void Write(string message)
    {
        if (message == "42")
        {
            throw new LoggerException();
        }
        Console.WriteLine("Logger Is Saying " + message);
    }
}

public class RealWebService : IWebService
{
    public void NotifyOfLoggerFailure(string message)
    {

        Console.WriteLine("Would actually call the API Here.");
    }
}