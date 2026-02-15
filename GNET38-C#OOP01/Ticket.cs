using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GNET38_C_OOP01
{
    internal class Ticket
    {
        public string? MovieName{ get; set; }
        public TicketType Type { get; set; }
        public SeatLocation Seat { get; set; }

        private double Price;
        public double GetPrice() => Price;

        public Ticket(string movieName): this(movieName, TicketType.Standard, new SeatLocation('A', 1), 50) 
        {

        }
        public Ticket(string movieName, TicketType type, SeatLocation seat, double price)
        {
            if (string.IsNullOrWhiteSpace(movieName))
                throw new ArgumentException("Movie name is required.", nameof(movieName));

            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");

            MovieName = movieName.Trim();
            Type = type;
            Seat = seat;
            Price = price;
        }
        public double CalcTotal(double taxPercent)
        {
            if (taxPercent < 0)
                throw new ArgumentOutOfRangeException(nameof(taxPercent), "Tax percent cannot be negative.");

            double taxValue = Price * (taxPercent / 100.0);
            return Price + taxValue;
        }

        public void ApplyDiscount(ref double discountAmount)
        {
            if (discountAmount > 0 && discountAmount <= Price)
            {
                Price -= discountAmount;
                discountAmount = 0; // consumed
            }
        }

        public void PrintTicket()
        {
            Console.WriteLine("===== Ticket Info =====");
            Console.WriteLine($"Movie   : {MovieName}");
            Console.WriteLine($"Type    : {Type}");
            Console.WriteLine($"Seat    : {Seat}");
            Console.WriteLine($"Price   : {Price:0.00}");
            Console.WriteLine("=======================");
        }
    }
}
