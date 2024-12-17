namespace SlotF;

public class printUI
{
    public void PrintFormattedBox(string val1, string val2, string val3)
    {
        int columnWidth = 10;
        string border = new string('-', columnWidth * 3 + 4);

        Console.WriteLine(border);
        Console.WriteLine($"|{CenterText(val1, columnWidth)}|{CenterText(val2, columnWidth)}|{CenterText(val3, columnWidth)}|");
        Console.WriteLine(border);
    }
    static string CenterText(string text, int width)
    {
        int padding = width - text.Length;
        int padLeft = padding / 2;
        int padRight = padding - padLeft;

        return new string(' ', padLeft) + text + new string(' ', padRight);
    }

    public static void PrintLogStats(ResultData.LogData logData)
    {
        Console.WriteLine("==========================================");
        //RTP calculation formula example was incorrect in README.txt, used the correct formula here 
        double rtpValue = (double)logData.Win / logData.Bet * 100;
        Console.WriteLine($"RTP: {rtpValue:F2}% " +
                            ", Total spins: " + logData.Spin +
                            ", Total bet: " + logData.Bet + 
                            ", Total win: " + logData.Win);
        Console.WriteLine("\nWin stats:");
        foreach (var stat in logData.Stats)
        {
            // Console.WriteLine($" {{stat.Key},-10} - {stat.Value.Item1} hits, Total Win = {stat.Value.Item2}");
            // Console.WriteLine($" \\\"{{stat.Key,-10}}\\\" - {stat.Value.Item1} hits, Total Win = {stat.Value.Item2}");
            // Console.WriteLine($" \"{stat.Key,-10}\" - {stat.Value.Item1} hits, Total Win = {stat.Value.Item2}");
            // Console.WriteLine($" {stat.Key.PadRight(8)} - {stat.Value.Item1} hits, Total Win = {stat.Value.Item2}");
            Console.WriteLine($" \"{stat.Key}\"{new string(' ', 8 - stat.Key.Length)} - {stat.Value.Item1} hits, Total Win = {stat.Value.Item2}");




        }
    }
}