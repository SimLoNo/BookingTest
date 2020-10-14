using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTest_1
{
    class InfoCheck
    {public bool DateCheck(DateTime OldStartDate, DateTime OldEndDate, DateTime NewStartDate, DateTime NewEndDate) 
        {
            if ((NewStartDate.Date >= OldStartDate.Date && NewStartDate.Date < OldEndDate.Date) || (NewEndDate.Date > OldStartDate.Date && NewEndDate.Date < OldEndDate.Date) || (NewStartDate.Date < OldStartDate.Date && NewEndDate.Date >= OldEndDate.Date))
            {
                Console.WriteLine("Booking ikke tilgængelig");
                return true;
            }
            else 
            {
                Console.WriteLine("Booking tilgængelig.");
                return false;
            }
        }
    }
}
