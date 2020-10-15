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
        public void FindBooking() 
        {
            SQLCommands SqlCmd = new SQLCommands();
            Booking FndBk;
            string BeskedSlutDato = "slutdato"; //String til at give metoden for at vaelge dato tekst
            string BeskedStartDato = "startdato"; //String til at give metoden for at vaelge dato tekst
            //-----------------------------------------------------------
            DateTime StartDate = SelectDate(BeskedStartDato); //Brugeren vaelger startdato for opholdet
            DateTime EndDate = SelectDate(BeskedSlutDato); //Brugeren vaelger slutdato for opholdet
            //Tjekker om der er gyldige datoer i variablerne, ved at tjekke om der er blevet returneret minimumsvaerdi fra SelectDate metoden---------------------
            if (DateValidCheck(StartDate, EndDate))
            {
                Booking Bk = new Booking(StartDate, EndDate);
                FndBk=SqlCmd.FindBooking(Bk); // Ret til ny Sql metode
                if(FndBk.BookingId >= 1) Console.WriteLine($"Booking fundet: Id: {FndBk.BookingId}. Check-in: {FndBk.BookingStart}. Checkud: {FndBk.BookingEnd}.");

                else Console.WriteLine("Vi kunne ikke finde din booking.");
            }
            else { Console.WriteLine("En eller flere dato'er er ikke gyldige."); }
            //----------------------------------------------------------------------------------------------------------------------------------------------------
            
        }
        //Metode der tjekker om der er minumum value i en af de indtastede datoer. Returnere true hvis datoerne er gyldige---------------------
        public bool DateValidCheck(DateTime StartDate, DateTime EndDate) 
        { 
            if (StartDate == DateTime.MinValue || EndDate == DateTime.MinValue) return false;
            else return true;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
    }
}
