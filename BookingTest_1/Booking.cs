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
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        /*private DateTime bookingStart;

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
        }*/
        private List<BookingPart> bookingItem;

        public List<BookingPart> BookingItem
        {
            get { return bookingItem; }
            set { bookingItem = value; }
        }
        public Booking(DateTime BkSt, DateTime BkNd) 
        {
            BookingStart = BkSt;
            BookingEnd = BkNd;
        }
        public Booking(DateTime BkSt, DateTime BkNd, List<BookingPart> BkIm) 
        {
            BookingStart = BkSt;
            BookingEnd = BkNd;
            bookingItem = BkIm;
        }






    }
}
