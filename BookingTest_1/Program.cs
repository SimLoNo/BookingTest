using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTest_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey Valg;
            WriteInfo WriInf = new WriteInfo();
            SQLCommands SqlCmd = new SQLCommands();
            SqlCmd.CheckConnection();
            do
            {
                WriInf.FindBooking();
                WriInf.MakeBooking();
                Console.WriteLine("Prøv igen.");
                Valg = Console.ReadKey(true).Key;
            } while (Valg != ConsoleKey.Escape);
        }
    }
}
