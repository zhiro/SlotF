
using System;
using SlotF;


class Program
{
    static void Main()
    {
        long balance = 0;
        bool restart = true;
        bool addBalance = true;
        
        var logData = new LogData(0, 0,0, ConstDataProvider.EmptyLogResult());
        RunSlots slotMachine = new RunSlots();
        PrintUi printUi = new PrintUi();
        
        
        while (restart)
        {
            if (addBalance)
            {
                balance += GetValidLongInput("Add balance:");
            }
            long bet = GetValidLongInput("Bet:");
            long spins = GetValidLongInput("Number of spins:");
            
            Console.WriteLine("==========================================");
            
            balance = slotMachine.Run(bet, spins, balance, logData);
            
            
            restart = GetValidYesNoInput($"Current balance: {balance}, do you wish to continue rolling? (Y/N)");
            if (!restart)
            {
                PrintUi.PrintLogStats(logData);
                Console.WriteLine("==========================================");
                Console.WriteLine("Final payout: " + balance);
            }
            else
            {
                addBalance = balance <= 0 || GetValidYesNoInput("Do you wish to add additional funds? (Y/N)");
            }
            
        }
    }

    static long GetValidLongInput(string prompt)
    {
        long number;
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine()!;
            
            if (long.TryParse(input, out number))
            {
                return number;
            }
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        
    }

    static bool GetValidYesNoInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine()?.Trim().ToUpper()!;
        
            if (input == "Y")
            {
                return true;
            }
            if (input == "N")
            {
                return false;
            }

            Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
        }
    }
}
