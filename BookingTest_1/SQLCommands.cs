using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BookingTest_1
{
    class SQLCommands
    {//Opretter variabler til connectionstring og tider for checkin og checkud----------------------------
        public string CheckInTime = " 15:00";
        public string CheckOutTime = " 11:00";
        public string ConString = "Data Source=.;Initial Catalog=BookingApp;Integrated Security=True";
        //-------------------------------------------------------------------------------------------------
        //Metode til at teste forbindelse------------------------------------------------------------------
        public bool CheckConnection() 
        { using (SqlConnection Con = new SqlConnection(ConString))
            {
                try 
                { Con.Open();
                    Console.WriteLine("Connection!");
                    return true;
                }
                catch (Exception)  {return false; }
            }
        }
        //-------------------------------------------------------------------------------------------------
        //Metode til at lave en booking hos hotellet-------------------------------------------------------
        public void MakeBooking(Booking Bk) 
        {
            using (SqlConnection Con = new SqlConnection(ConString)) 
            {
                try 
                {
                    Con.Open();
                    InfoCheck InfChk = new InfoCheck();
                    bool AlreadyBooked = false;
                    //Opretter Sql kommandoer til brug i koden------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    SqlCommand CheckAvailable = new SqlCommand("SELECT BookingDateStart, BookingDateEnd FROM BookingTable", Con);
                    SqlCommand InsertBooking = new SqlCommand("INSERT INTO BookingTable(BookingDateStart, BookingDateEnd) VALUES ('" + Bk.BookingStart.ToString("MM-dd-yyyy") + CheckInTime+ "','" + Bk.BookingEnd.ToString("MM-dd-yyyy")+CheckOutTime + "')", Con);
                    //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    SqlDataReader ReaderBookings = CheckAvailable.ExecuteReader();
                    while (ReaderBookings.Read()) 
                    {
                        //Tjekker om der allerede er bookinger i den oenskede tidsperiode-------------------------------------------------------------------------
                        DateTime OldBookingStart = ReaderBookings.GetDateTime(0);
                        DateTime OldBookingEnd = ReaderBookings.GetDateTime(1);
                        if (InfChk.DateCheck(OldBookingStart, OldBookingEnd, Bk.BookingStart, Bk.BookingEnd) == true) AlreadyBooked = true;
                        //----------------------------------------------------------------------------------------------------------------------------------------

                    }
                    ReaderBookings.Close(); //Lukker forbindelsen der tjekker databasen
                    //Hvis der ikke er fundet nogle krydsende datoer i databasen, bliver bookingen lavet, eller bliver brugeren oplyst om at booking ikke er muligt----
                    if (AlreadyBooked == false) 
                    {
                        Console.WriteLine("Booking tilgængelig.");
                        InsertBooking.ExecuteNonQuery(); }
                    else Console.WriteLine("Der er desværre ikke plads i denne tidsperiode.");
                    //-------------------------------------------------------------------------------------------------------------------------------------------------
                }
                catch (Exception Ex) { Console.WriteLine(Ex.Message); }
            }
        }
        public Booking FindBooking(Booking Bk) 
        {
            Booking FndBk = new Booking();   
            using(SqlConnection Con = new SqlConnection(ConString)) 
            {
                try 
                {
                    List<BookingPart> BkPList = new List<BookingPart>();
                    Con.Open();
                    SqlCommand SelectBooking = new SqlCommand("SELECT * FROM BookingTable WHERE BookingDateStart ='" + Bk.BookingStart.ToString("MM-dd-yyyy")+CheckInTime + "' AND BookingDateEnd='" + Bk.BookingEnd.ToString("MM-dd-yyyy")+CheckOutTime+"'", Con);
                    SqlDataReader Reader = SelectBooking.ExecuteReader();
                    while (Reader.Read()) 
                    {
                        FndBk.BookingId = Reader.GetInt32(0);
                        FndBk.BookingStart = Reader.GetDateTime(1);
                        FndBk.BookingEnd = Reader.GetDateTime(2);
                    }
                }
                catch (Exception Ex) { Console.WriteLine(Ex.Message," !FindBooking!"); }
                return FndBk;
            }
        
        }
        //-------------------------------------------------------------------------------------------------
        //Metode til at teste loesninger til problemer i andre metoder-------------------------------------
        public void InsertCheck(Booking Bk) 
        {
            using (SqlConnection Con = new SqlConnection(ConString)) 
            {
                try
                {
                    string D1 = Bk.BookingStart.ToString();
                    string D2 = Bk.BookingEnd.ToString();
                    Con.Open();
                    SqlCommand Cmd = new SqlCommand("INSERT INTO BookingTable(BookingDateStart, BookingDateEnd) VALUES ('"+Bk.BookingStart.ToString("MM-dd-yyyy")+"','"+Bk.BookingEnd.ToString("MM-dd-yyyy") +"')",Con);
                    Cmd.ExecuteNonQuery();
                    Console.WriteLine("Appers to have done it.");
                }
                catch (Exception Ex) { Console.WriteLine(Ex.Message); }
            }
        }
        //-------------------------------------------------------------------------------------------------
    }
}
