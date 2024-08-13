namespace wormix_core.Extensions;

public static class ColorPrint
{
    public static void WriteLine(string line, System.ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(line);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}