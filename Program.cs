using System;
using System.Globalization;
using pers_exception.Entities;

namespace pers_exception
{
    class Program
    {
        static void Main(string[] args)
        {
            Reservation reserv = new Reservation(1001, DateTime.Now, DateParse("14/08/2019"));

            Console.WriteLine(reserv);
        }
        static DateTime DateParse(string dateTime)
        {
            return DateTime.ParseExact(dateTime, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}
