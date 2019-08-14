using System;
using pers_exception.Entities.Exceptions;

namespace pers_exception.Entities
{
    class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
         public Reservation()
         {
         }
         public Reservation(int roomNumber, DateTime checkin, DateTime checkout)
         {
             if(checkout < checkin)
             {
                 throw new DomainException("Check-out date must be higher than check-in.");
             }
             RoomNumber = roomNumber;
             Checkin = checkin;
             Checkout = checkout;
         }
        public int Duration()
        {
            TimeSpan duration = Checkout.Subtract(Checkin);
            return (int) duration.TotalDays;
        }
        public void UpdateDates(DateTime checkin, DateTime checkout)
        {
            DateTime now = DateTime.Now;
            if(checkin < now || checkout < now)
            {
                throw new DomainException("Reservation dates for update must be future dates.");
            }
            if(checkout <= checkin)
            {
                throw new DomainException ("Check-out date must be higher than check-in.");
            }

            Checkin = checkin;
            Checkout = checkout;
        }
        public override string ToString()
        {
            string night = Duration() > 1 ? " nights" : " night";
            return "Room "
                    + RoomNumber
                    + ", "
                    + "Checkin: "
                    + Checkin.ToString("dd/MM/yyyy")
                    + ", "
                    + "Checkout: "
                    + Checkout.ToString("dd/MM/yyyy")
                    + ", "
                    + Duration()
                    + night;
        }
    }
}