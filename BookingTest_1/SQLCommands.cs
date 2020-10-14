using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BookingTest_1
{
    class SQLCommands
    {
        public string ConString = "Data Source=.;Initial Catalog=BookingApp;Integrated Security=True";

        public bool CheckConnection() 
        { using (SqlConnection Con = new SqlConnection(ConString))
            {
                try 
                { Con.Open();
                    return true;
                }
                catch (Exception)  {return false; }
            }
        }
        public void MakeBooking(Booking NewBooking) 
        {
            using (SqlConnection Con = new SqlConnection(ConString)) 
            {
                DateTime D1 = NewBooking.BookingStart;
                DateTime D2 = NewBooking.BookingEnd;
                try 
                {

                   // NewBooking.BookingStart = Convert.ToDateTime("2020/10/20");
                   // NewBooking.BookingEnd = Convert.ToDateTime("2020/10/22");
                    Console.WriteLine(NewBooking.BookingStart);
                    Console.WriteLine(NewBooking.BookingEnd);
                    Con.Open();
                    InfoCheck InfChk = new InfoCheck();
                    bool AlreadyBooked = false;
                    SqlCommand CheckAvailable = new SqlCommand("SELECT BookingDateStart, BookingDateEnd FROM BookingTable", Con);
                   // SqlCommand InsertBooking = new SqlCommand("INSERT INTO BookingTable VALUES ('" + NewBooking.BookingStart.Date + "','" + NewBooking.BookingEnd.Date + "')", Con);
                    SqlCommand InsertBooking = new SqlCommand("dbo.Dates '"+NewBooking.BookingStart+"' , '"+NewBooking.BookingEnd+"'", Con);
                    //SqlCommand InsertBooking = new SqlCommand("INSERT INTO BookingTable VALUES ('"+D1+"','"+D2+"')", Con);
                    //SqlCommand InsertBooking = new SqlCommand("INSERT INTO BookingTable VALUES ('"+D3+"','"+D4+"')", Con);
                    SqlDataReader ReaderBookings = CheckAvailable.ExecuteReader();
                    while (ReaderBookings.Read()) 
                    {
                        DateTime OldBookingStart = ReaderBookings.GetDateTime(0);
                        DateTime OldBookingEnd = ReaderBookings.GetDateTime(1);
                        if (InfChk.DateCheck(OldBookingStart, OldBookingEnd, NewBooking.BookingStart, NewBooking.BookingEnd) == true) AlreadyBooked = true;
                        
                    }
                    ReaderBookings.Close();
                    if (AlreadyBooked == false) InsertBooking.ExecuteNonQuery();
                    else Console.WriteLine("Der er desværre ikke plads i denne tidsperiode.");
                }catch(Exception Ex) { Console.WriteLine(Ex.Message); }
            }
        }
    }
}
