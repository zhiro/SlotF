namespace SlotF;

public class RunSlots
{
    private static readonly ConstDataProvider DataProvider = new ConstDataProvider();
    private static readonly Dictionary<string, int> Paytable = DataProvider.GetPaytable();
    
    public long Run(long bet, long spins, long balance, LogData log)
    {
        PrintUi printUi = new PrintUi();
        
        for (int spin = 1; spin <= spins; spin++)
        {
            
            long previousBalance = balance;
            balance -= bet;
            if (balance < 0)
            {
                Console.WriteLine("Insufficient balance: unable to continue the spins.");
                balance = previousBalance;
                break;
            }

            string[] randomValues = SlotRow.GetRandomColumnValues();
            string matchValue = GetValueIfMatchingColumns(randomValues);

            long coef = 0;
            if (matchValue != "")
            {
                coef = GetCoeficentFromPaytable(matchValue);
            }
            long win = bet * coef;
            balance += win;
            printUi.PrintFormattedBox(randomValues);
            
            Console.WriteLine("Spin: " + spin +
                              ", Win: " + win +
                              (string.IsNullOrEmpty(matchValue) ? "" : $" ({matchValue})") +
                              ", Balance: " + balance + "\n");

            var stats = new Dictionary<string, (int hits,int wins)>();
            
            log.Spin += 1;
            log.Bet += bet;
            log.Win += win;
            
            UpdateStats(log.Stats, matchValue, win);
        }
        return balance;
    }
    
    public static string GetValueIfMatchingColumns(string[] columns)
    {
        if (columns.Contains("Wild"))
        {
            var nonWildValues = columns.Where(c => c != "Wild").Distinct().ToArray();
            
            if (nonWildValues.Length == 1)
            {
                return nonWildValues[0];
            }
            else if (nonWildValues.Length == 0)
            {
                return "Wild";
            }
        }
        else if (columns.Distinct().Count() == 1)
        {
            return columns[0];
        }
        return "";
    }

    static int GetCoeficentFromPaytable(string value)
    {
        return Paytable[value];
    }
    

    private void UpdateStats(Dictionary<string, (int, long)> stats, string match, long winAmount)
    {
        if (!string.IsNullOrEmpty(match))
        {
            var currentStat = stats[match];
            stats[match] = (currentStat.Item1 + 1, currentStat.Item2 + winAmount);
        }
    }
}