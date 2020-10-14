using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTest_1
{
    class WriteInfo
    {
        public void MakeBooking() 
        {
            SQLCommands SqlCmd = new SQLCommands();
            DateTime StartDate = SelectStartDate();
            DateTime EndDate = SelectEndDate();
            if (DateValidCheck(StartDate, EndDate))
            {
                Booking Bk = new Booking(StartDate, EndDate);
                SqlCmd.MakeBooking(Bk);
            }
        }
        public DateTime SelectStartDate() 
        {
            Console.WriteLine("Indtast venligst den ønskede startdato, og tryk enter.");
            DateTime StartDate;
            string DateInput;
            DateInput = Console.ReadLine();
            try 
            {
                //StartDate = DateTime.Parse(DateInput);

                StartDate = Convert.ToDateTime(DateInput);
                return StartDate;
            }
            catch (Exception Ex) { Console.WriteLine(Ex.Message); return DateTime.MinValue; }
        }
        public DateTime SelectEndDate() 
        {
            Console.WriteLine("Indtast venligst den ønskede slutdato, og tryk enter.");
            DateTime EndDate;
            string DateInput;
            DateInput = Console.ReadLine();
            try
            {
                //EndDate = DateTime.Parse(DateInput);

                EndDate = Convert.ToDateTime(DateInput);
                return EndDate;
            }
            catch (Exception Ex) { Console.WriteLine(Ex.Message); return DateTime.MinValue; }
        }
        public bool DateValidCheck(DateTime StartDate, DateTime EndDate) 
        { 
            if (StartDate == DateTime.MinValue || EndDate == DateTime.MinValue) return false;
            else return true;
        }
    }
}
