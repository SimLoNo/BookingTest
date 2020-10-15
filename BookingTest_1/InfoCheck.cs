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
            // Tjekker om brugerens oenskede datoer, kommer i kambolage med bookinger allerede i systemet
            if ((NewStartDate.Date >= OldStartDate.Date && NewStartDate.Date < OldEndDate.Date) || (NewEndDate.Date > OldStartDate.Date && NewEndDate.Date < OldEndDate.Date) || (NewStartDate.Date < OldStartDate.Date && NewEndDate.Date >= OldEndDate.Date))
            {;
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
