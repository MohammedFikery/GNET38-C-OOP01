using GNET38_C_OOP01;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GNET38_C_OOP01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1 : Explain with code example how class and struct behave differently

            /*
            PersonClass p1 = new PersonClass();
            p1.Name = "Ali";

            PersonClass p2 = p1;   // نسخ المرجع فقط
            p2.Name = "Omar";

            Console.WriteLine(p1.Name);
            */

            /*
            PersonStruct p1;
            p1.Name = "Ali";

            PersonStruct p2 = p1;  // نسخ القيمة بالكامل
            p2.Name = "Omar";

            Console.WriteLine(p1.Name);
            */

            #endregion

            #region part2

            Console.WriteLine("========== Ticket Booking ==========\n");

            var cinema = new Cinema();

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Enter data for Ticket {i}:");

                string movie = ReadNonEmptyString("Movie Name: ");
                TicketType type = ReadTicketType("Ticket Type (1=Standard, 2=VIP, 3=IMAX): ");
                char row = ReadSeatRow("Seat Row (A-Z): ");
                int seatNo = ReadPositiveInt("Seat Number: ");
                double price = ReadPositiveDouble("Price: ");

                var seat = new SeatLocation(row, seatNo);
                var ticket = new Ticket(movie, type, seat, price);

                cinema.AddTicket(ticket);
                Console.WriteLine();
            }

            Console.WriteLine("========== All Tickets ==========\n");

            for (int i = 0; i < 3; i++)
            {
                var t = cinema[i];
                if (t is null) continue;

                Console.WriteLine(
                    $"Ticket #{t.TicketId} | {t.MovieName} | {t.Type} | Seat: {t.Seat} | " +
                    $"Price: {t.Price:0.##} EGP | After Tax: {t.PriceAfterTax:0.##} EGP"
                );
            }

            Console.WriteLine("\n========== Search by Movie ==========\n");
            string search = ReadNonEmptyString("Enter movie name to search: ");
            var found = cinema[search];

            if (found is null)
                Console.WriteLine("Not found.");
            else
                Console.WriteLine(
                    $"Found Ticket #{found.TicketId} | {found.MovieName} | {found.Type} | Seat: {found.Seat} | " +
                    $"Price: {found.Price:0.##} EGP"
                );

            Console.WriteLine("\n========== Statistics ==========\n");
            Console.WriteLine($"Total Tickets Sold: {Ticket.GetTotalTicketsSold()}");

            Console.WriteLine("\nBooking Reference 1: " + BookingHelper.GenerateBookingReference());
            Console.WriteLine("Booking Reference 2: " + BookingHelper.GenerateBookingReference());

            Console.WriteLine("\n========== Group Discount ==========\n");
            int groupCount = 5;
            double groupPrice = 80;
            double discountedTotal = BookingHelper.CalcGroupDiscount(groupCount, groupPrice);

            double originalTotal = groupCount * groupPrice;
            Console.WriteLine($"Group Discount ({groupCount} tickets x {groupPrice:0.##} EGP): {discountedTotal:0.##} EGP " +
                              (groupCount >= 5 ? "(10% off applied)" : "(no discount)"));

            Console.WriteLine("\n====================================");
        }


        private static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? s = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(s))
                    return s.Trim();

                Console.WriteLine("Invalid input. Please enter a non-empty value.");
            }
        }

        private static int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
                    return n;

                Console.WriteLine("Invalid number. Please enter a positive integer.");
            }
        }

        private static double ReadPositiveDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double d) && d > 0)
                    return d;

                Console.WriteLine("Invalid number. Please enter a positive value.");
            }
        }

        private static char ReadSeatRow(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? s = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(s))
                {
                    char c = char.ToUpperInvariant(s.Trim()[0]);
                    if (c >= 'A' && c <= 'Z')
                        return c;
                }

                Console.WriteLine("Invalid row. Please enter a letter A-Z.");
            }
        }

        private static TicketType ReadTicketType(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    if (n >= 1 && n <= 3)
                        return (TicketType)n;

                    if (n >= 0 && n <= 2)
                        return (TicketType)(n + 1);
                }

                Console.WriteLine("Invalid type. Enter 1 (Standard), 2 (VIP), 3 (IMAX).");
            }
        }
        #endregion
    }


    #region Q1 : Explain with code example how class and struct behave differently
    /*
    //class>>>> Reference type>>>>Stored in Heap >>>Copies reference>>>>using with Larg data
    //struct>>>Value type >>>>>Stored in Stack (usually)>>>>>Copies value...dont support Inheritance >>>>using with Small data
    class PersonClass
    {
        public string Name;
    }

    struct PersonStruct
    {
        public string Name;
    }
    */
    #endregion

    #region Q2 : Explain the difference between public and private access modifiers with an example. 

    //public >>>> ألكل يقدر يشوفها من اي مكان ...>Example Constractor 
    //private >>> ماحدش يقدر يشوفها خارج السكوب بتاعها وده بنحتاج نعمله لو في خصوصية او تحقق مثلا ....>>>  Encapsulation لتحقيق مبداء ال 


    #endregion

    #region Q3 : Describe the steps to create and use a class library in Visual Studio.
    /*
     * افتح Visual Studio
     * اختر Create a new project
     * ابحث عن:Class Library (.NET)
     * اكتب الاسم
     * اختر Framework
     * Create
     * الكلاس يجب أن يكون public
     * اكتب الكود الخاص بك محتاج تستخدمع فيما بعد في اي مشروع
     * اعمل Build للمشروع
     * ==============================================================================================
     * في المشروع الجديد محتاج تعمل استيراد للمكتبة فيه 
                            * Right Click References
                            * Add Reference
                            * اختار الملف الامتداد dll
                            * OK

     */
    #endregion

    #region Q4 : What is a class library? Why do we use class libraries?
    /*
     * هي كود انت محتاج تكرره في اكثر من مشروع فبنعمله في مكتبة ونحفظه ونستدعيه في اي مشروع 
     */
    #endregion


}
