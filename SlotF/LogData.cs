namespace SlotF;

    public class LogData
    {
        public int Spin { get; set; }
        public long Bet { get; set; }
        public long Win { get; set; }
        public Dictionary<string, (int, long)> Stats { get; set; }

        public LogData(int spin, long bet, long win, Dictionary<string, (int, long)> stats)
        {
            Spin = spin;
            Bet = bet;
            Win = win;
            Stats = stats;
        }
    }
