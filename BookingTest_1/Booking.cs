using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTest_1
{
    class Booking
    {
        private int bookingId;

        public int BookingId
        {
            get { return bookingId; }
            set { bookingId = value; }
        }
        private DateTime bookingStart;

        public DateTime BookingStart
        {
            get { return bookingStart; }
            set { bookingStart = value; }
        }
        private DateTime bookingEnd;

        public DateTime BookingEnd
        {
            get { return bookingEnd; }
            set { bookingEnd = value; }
        }
        private List<BookingPart> bookingItem;

        public List<BookingPart> BookingItem
        {
            get { return bookingItem; }
            set { bookingItem = value; }
        }
        public Booking(DateTime BookingStart, DateTime BookingEnd) 
        {
            bookingStart = BookingStart;
            bookingEnd = BookingEnd;
        }
        public Booking(DateTime BookingStart, DateTime BookingEnd, List<BookingPart> BookingItem) 
        {
            bookingStart = BookingStart.Date;
            bookingEnd = BookingEnd.Date;
            bookingItem = BookingItem;
        }






    }
}
