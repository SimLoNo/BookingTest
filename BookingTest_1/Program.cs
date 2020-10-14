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
            DateTime Book1Start = new DateTime(2020,10,14);
            DateTime Book1End = new DateTime(2020, 10, 24);

            DateTime Book2Start = new DateTime(2020, 10, 25);
            DateTime Book2End = new DateTime(2020, 10, 26);

            if((Book2Start.Date >= Book1Start.Date && Book2Start.Date < Book1End.Date) || (Book2End.Date > Book1Start.Date && Book2End.Date < Book1End.Date) || (Book2Start.Date < Book1Start.Date && Book2End.Date >= Book1End.Date)) 
            {
                Console.WriteLine("Booking ikke tilgængelig");
            }
            else Console.WriteLine("Booking tilgængelig.");
            Console.ReadKey();
        }
    }
}
