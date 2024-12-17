
using System;
using SlotF;


class Program
{
    static void Main()
    {
        long balance = 0;
        bool restart = true;
        bool addBalance = true;
        printUI printUi = new printUI();
        
        
        var logData = new ResultData.LogData(0, 0,0, ConstDataProvider.EmptyLogResult());
        
        while (restart)
        {
            if (addBalance)
            {
                Console.WriteLine("Add balance:");
                balance += Convert.ToInt64(Console.ReadLine());
            }

            Console.WriteLine("Bet:");
            long bet = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Number of spins");
            long spins = Convert.ToInt64(Console.ReadLine());
            
            Console.WriteLine("==========================================");

            ConstDataProvider dataProvider = new ConstDataProvider();
            
            RunSlots slotMachine = new RunSlots();
            balance = slotMachine.Run(bet, spins, balance, dataProvider.GetColumnOneValues(), dataProvider.GetColumnTwoValues(), dataProvider.GetColumnThreeValues(), logData);
            // balance = Result.Balance;
            Console.WriteLine($"Current balance: {balance}, do you wish to payout? (Y/N)");
            string input = Console.ReadLine()?.ToUpper()!;
            if (input == "Y")
            {
                restart = false;
                printUI.PrintLogStats(logData);
                Console.WriteLine("Final payout: " + balance);
            }
            else
            {
                if (balance <= 0)
                {
                    addBalance = true;
                }
                else
                {
                    // Always Require funds if balance is 0
                    Console.WriteLine("Do you wish to add additional funds? (Y/N)");
                    string input2 = Console.ReadLine()?.ToUpper()!;
                    if (input2 == "N")
                    {
                        addBalance = false;
                    }
                }
            }
        }
    }
}
