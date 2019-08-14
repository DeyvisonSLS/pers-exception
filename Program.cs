using System;
using System.Globalization;
using pers_exception.Entities;
using pers_exception.Entities.Exceptions;

namespace pers_exception
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Pegando os dados
                Console.Write("Room number: ");
                int roomNumber = int.Parse(Console.ReadLine());
                //
                Console.Write("Check-in date (dd/MM/yyyy): ");
                DateTime checkIn = DateParse(Console.ReadLine());
                //
                Console.Write("Check-out date (dd/MM/yyyy): ");
                DateTime checkOut = DateParse(Console.ReadLine());
                //
                Reservation reserv = new Reservation(roomNumber, checkIn, checkOut);
                Console.Write("Reservation: " + reserv);


                //Segundo bloco usado p/ atualizar datas
                Console.WriteLine();
                Console.WriteLine("Enter data to update the reservation:");
                //
                Console.Write("Check-in date (dd/MM/yyyy): ");
                checkIn = DateParse(Console.ReadLine());
                //
                Console.Write("Check-out date (dd/MM/yyyy): ");
                checkOut = DateParse(Console.ReadLine());
                //
                reserv.UpdateDates(checkIn, checkOut);
                Console.WriteLine("Reservation: " + reserv);
            }
            catch(DomainException e)
            {
                Console.WriteLine("Error in reservation: " + e.Message);
            }
            catch(FormatException e)
            {
                Console.WriteLine("Format error: " + e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
        static DateTime DateParse(string dateTime)
        {
            return DateTime.ParseExact(dateTime, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}
