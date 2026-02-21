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
        private static int ticketCounter = 0;

        private string _movieName = "Unknown";
        private TicketType _type = TicketType.Standard;
        private SeatLocation _seat = new SeatLocation('A', 1);
        private double _price = 50;

        public int TicketId { get; } 

        public Ticket()
        {
            TicketId = ++ticketCounter; 
        }

        public Ticket(string movieName) : this()
        {
            MovieName = movieName;
        }

        public Ticket(string movieName, TicketType type, SeatLocation seat, double price) : this()
        {
            MovieName = movieName;
            Type = type;
            Seat = seat;
            Price = price;
        }

        public string MovieName
        {
            get => _movieName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _movieName = value.Trim();
            }
        }

        public TicketType Type
        {
            get => _type;
            set => _type = value;
        }

        public SeatLocation Seat
        {
            get => _seat;
            set => _seat = value;
        }

        public double Price
        {
            get => _price;
            set
            {
                if (value > 0)
                    _price = value;
            }
        }

        public double PriceAfterTax => Price * 1.14;

        public static int GetTotalTicketsSold() => ticketCounter;
    }
    }
