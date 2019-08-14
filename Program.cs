using System;
using System.Globalization;
using pers_exception.Entities;

namespace pers_exception
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Room number: ");
            int roomNumber = int.Parse(Console.ReadLine());

            Console.Write("Check-in date (dd/MM/yyyy): ");
            DateTime checkIn = DateParse(Console.ReadLine());

            Console.Write("Check-out date (dd/MM/yyyy): ");
            DateTime checkOut = DateParse(Console.ReadLine());

            if(checkOut <= checkIn)
            {
                Console.WriteLine("Error in reservation: Check-out date must be higher than check-in");
            }
            else
            {
                Reservation reserv = new Reservation(roomNumber, checkIn, checkOut);
                Console.Write("Reservation: " + reserv);

                //Segundo bloco usado p/ atualizar datas
                Console.WriteLine();
                
                Console.WriteLine("Enter data to update the reservation:");

                Console.Write("Check-in date (dd/MM/yyyy): ");
                checkIn = DateParse(Console.ReadLine());

                Console.Write("Check-out date (dd/MM/yyyy): ");
                checkOut = DateParse(Console.ReadLine());

                string error = reserv.UpdateDates(checkIn, checkOut);

                if(error != null)
                {
                    Console.WriteLine("Error: " + error);
                }
                else
                {
                    reserv.UpdateDates(checkIn, checkOut);
                    Console.WriteLine("Reservation: " + reserv);
                }
            }
        }
        static DateTime DateParse(string dateTime)
        {
            return DateTime.ParseExact(dateTime, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}
