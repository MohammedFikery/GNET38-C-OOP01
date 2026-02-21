using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNET38_C_OOP01
{
    internal struct SeatLocation
    {
        public char Row { get; }
        public int Number { get; }

        public SeatLocation(char row, int number)
        {
            row = char.ToUpperInvariant(row);

            if (row < 'A' || row > 'Z')
                throw new ArgumentOutOfRangeException(nameof(row), "Row must be between A and Z.");

            if (number <= 0)
                throw new ArgumentOutOfRangeException(nameof(number), "Seat number must be > 0.");

            Row = row;
            Number = number;
        }

        public override string ToString() => $"{Row}-{Number}";
    }
}
