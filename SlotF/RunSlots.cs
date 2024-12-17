namespace SlotF;

public class RunSlots
{
    private static readonly Random Random = new Random();
    private static readonly ConstDataProvider DataProvider = new ConstDataProvider();
    private static readonly Dictionary<string, int> Paytable = DataProvider.GetPaytable();
    
    public long Run(long bet, long spins, long balance, string[] colOne, string[] colTwo, string[] colThree, ResultData.LogData log)
    {
        printUI printUi = new printUI();
        
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
            string colOneValue = GetRandomColumnValue(colOne);
            string colTwoValue = GetRandomColumnValue(colTwo);  
            string colThreeValue = GetRandomColumnValue(colThree);
            
            string[] columns = { colOneValue, colTwoValue, colThreeValue };
            string matchValue = GetValueIfMatchingColumns(columns);

            long coef = 0;
            if (matchValue != "")
            {
                coef = GetCoeficentFromPaytable(matchValue);
            }
            long win = bet * coef;
            balance += win;
            printUi.PrintFormattedBox(colOneValue, colTwoValue, colThreeValue);
            
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
    
    
    static string GetRandomColumnValue(string[] columnValues)
    {
        int randomIndex = Random.Next(columnValues.Length);
        return columnValues[randomIndex];
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

    static void AddToLog(int spin, long bet, Dictionary<string, (int,int)> stats)
    {
        
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