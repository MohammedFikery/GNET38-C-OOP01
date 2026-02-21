using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNET38_C_OOP01
{
    internal class BookingHelper
    {
        private static int _bookingCounter = 0;

        public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
        {
            double total = numberOfTickets * pricePerTicket;
            if (numberOfTickets >= 5)
                total *= 0.90;
            return total;
        }

        public static string GenerateBookingReference()
        {
            _bookingCounter++;
            return $"BK-{_bookingCounter}";
        }
    }
}
