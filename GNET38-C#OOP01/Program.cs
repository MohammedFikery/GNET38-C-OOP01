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

            Console.WriteLine("=== Movie Ticket Booking System ===");

            // Read movie name
            string movieName = ReadNonEmptyString("Enter Movie Name: ");

            // Ask if user wants defaults (movie-only constructor)
            bool useDefaults = ReadYesNo("Use default ticket (Standard, A1, Price 50)? (y/n): ");

            Ticket ticket;

            if (useDefaults)
            {
                ticket = new Ticket(movieName);
            }
            else
            {
                TicketType type = ReadTicketType("Choose Ticket Type: 1=Standard, 2=VIP, 3=IMAX : ");

                char row = ReadSeatRow("Enter Seat Row (A-Z): ");
                int number = ReadPositiveInt("Enter Seat Number (>0): ");

                double price = ReadNonNegativeDouble("Enter Base Price: ");

                ticket = new Ticket(movieName, type, new SeatLocation(row, number), price);
            }

            // Discount
            double discount = ReadNonNegativeDouble("Enter Discount Amount (0 for none): ");
            double discountBefore = discount;
            ticket.ApplyDiscount(ref discount);

            // Tax
            double taxPercent = ReadNonNegativeDouble("Enter Tax Percent (e.g., 14): ");
            double totalAfterTax = ticket.CalcTotal(taxPercent);

            // Print summary
            Console.WriteLine();
            ticket.PrintTicket();
            Console.WriteLine($"Discount Applied? : {(discount == 0 && discountBefore > 0 ? "YES" : "NO")}");
            Console.WriteLine($"Tax (%)           : {taxPercent:0.00}");
            Console.WriteLine($"Total After Tax   : {totalAfterTax:0.00}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(); 
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

        #region part2
        static string ReadNonEmptyString(string prompt)
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

        static bool ReadYesNo(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? s = Console.ReadLine()?.Trim().ToLowerInvariant();

                if (s == "y" || s == "yes") return true;
                if (s == "n" || s == "no") return false;

                Console.WriteLine("Please enter y/n.");
            }
        }

        static TicketType ReadTicketType(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int n) && Enum.IsDefined(typeof(TicketType), n))
                    return (TicketType)n;

                Console.WriteLine("Invalid type. Enter 1, 2, or 3.");
            }
        }

        static char ReadSeatRow(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && input.Trim().Length == 1)
                {
                    char c = char.ToUpperInvariant(input.Trim()[0]);
                    if (c >= 'A' && c <= 'Z') return c;
                }

                Console.WriteLine("Invalid row. Enter a letter A-Z.");
            }
        }

        static int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int n) && n > 0)
                    return n;

                Console.WriteLine("Invalid number. Enter an integer > 0.");
            }
        }

        static double ReadNonNegativeDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (double.TryParse(input, out double v) && v >= 0)
                    return v;

                Console.WriteLine("Invalid value. Enter a number >= 0.");
            }
        }

        #endregion

    }
}
