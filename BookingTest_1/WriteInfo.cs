using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTest_1
{
    class WriteInfo
    {
        //Metode til at lave en booking------------------------------------------------------------------------------------------------
        public void MakeBooking() 
        {
            //Opretter variabler og reference til at udfoere koden-------
            SQLCommands SqlCmd = new SQLCommands();
            string BeskedSlutDato = "slutdato"; //String til at give metoden for at vaelge dato tekst
            string BeskedStartDato = "startdato"; //String til at give metoden for at vaelge dato tekst
            //-----------------------------------------------------------
            DateTime StartDate = SelectDate(BeskedStartDato); //Brugeren vaelger oensket startdato for opholdet
            DateTime EndDate = SelectDate(BeskedSlutDato); //Brugeren vaelger oensket slutdato for opholdet
            //Tjekker om der er gyldige datoer i variablerne, ved at tjekke om der er blevet returneret minimumsvaerdi fra SelectDate metoden---------------------
            if (DateValidCheck(StartDate, EndDate))
            {
                Booking Bk = new Booking(StartDate, EndDate);
                SqlCmd.MakeBooking(Bk);
                //SqlCmd.InsertCheck(Bk); (Gammel linie fra bugfixing forsoeg, lader blive indtil videre)
            }
            //----------------------------------------------------------------------------------------------------------------------------------------------------
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        //Metode til at vaelge dato til booking------------------------------------------------------------
        public DateTime SelectDate(string DatoBesked) 
        {
            Console.WriteLine($"Indtast venligst den ønskede {DatoBesked}, og tryk enter.");
            DateTime Date; //Variable til at holde og returnere den konverterede dato
            string DateInput; //Variable til at modtage brugerens input
            DateInput = Console.ReadLine();
            //Proever at konvertere input til datetime------------------------------------------
            try 
            {
                Date = Convert.ToDateTime(DateInput);
                return Date;
            }
            catch (Exception Ex) { Console.WriteLine(Ex.Message); return DateTime.MinValue; } // Hvis der ikke kan konverteres, bliver minimum vaerdi returneret
            //----------------------------------------------------------------------------------
        }
        //-------------------------------------------------------------------------------------------------
        //public DateTime SelectEndDate() 
        //{
        //    Console.WriteLine("Indtast venligst den ønskede slutdato, og tryk enter.");
        //    DateTime EndDate;
        //    string DateInput;
        //    DateInput = Console.ReadLine();
        //    try
        //    {
        //        EndDate = Convert.ToDateTime(DateInput);
        //        return EndDate;
        //    }
        //    catch (Exception Ex) { Console.WriteLine(Ex.Message); return DateTime.MinValue; }
        //}
        //Metode der tjekker om der er minumum value i en af de indtastede datoer. Returnere true hvis datoerne er gyldige---------------------
        public bool DateValidCheck(DateTime StartDate, DateTime EndDate) 
        { 
            if (StartDate == DateTime.MinValue || EndDate == DateTime.MinValue) return false;
            else return true;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
    }
}
