namespace CrashLogAnalyzer;

public static class Traces
{
    public static void ConsoleTrace(string message)
    {
        Console.WriteLine($"{DateTime.Now:HH:mm:ss} - {message}");
    }
}
