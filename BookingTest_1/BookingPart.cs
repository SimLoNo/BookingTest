using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTest_1
{
    class BookingPart
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int bookingId;

        public int BookingId
        {
            get { return bookingId; }
            set { bookingId = value; }
        }

        private int roomNumber;

        public int RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }



    }
}
