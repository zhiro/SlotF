namespace SlotF;

public class PrintUi
{
    public void PrintFormattedBox(string[] columns)
    {
        int columnWidth = 10;
        string border = new string('-', (columnWidth + 1) * columns.Length + 1);

        Console.WriteLine(border);
        Console.Write("|");
        foreach (var column in columns)
        {
            Console.Write(CenterText(column, columnWidth) + "|");
        }
        Console.WriteLine();
        Console.WriteLine(border);
    }
    
    static string CenterText(string text, int width)
    {
        int padding = width - text.Length;
        int padLeft = padding / 2;
        int padRight = padding - padLeft;

        return new string(' ', padLeft) + text + new string(' ', padRight);
    }

    public static void PrintLogStats(LogData logData)
    {
        Console.WriteLine("==========================================");
        //RTP calculation formula example was incorrect in README.txt, used the correct formula here 
        double rtpValue = (double)logData.Win / logData.Bet * 100;
        Console.WriteLine($"RTP: {rtpValue:F2}%" +
                            ", Total spins: " + logData.Spin +
                            ", Total bet: " + logData.Bet + 
                            ", Total win: " + logData.Win);
        Console.WriteLine("\nWin stats:");
        foreach (var stat in logData.Stats)
        {
            Console.WriteLine($" \"{stat.Key}\"{new string(' ', 8 - stat.Key.Length)} - {stat.Value.Item1} hits, Total Win = {stat.Value.Item2}");




        }
    }
}