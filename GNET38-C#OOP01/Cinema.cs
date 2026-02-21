using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNET38_C_OOP01
{
    internal class Cinema
    {
        private readonly Ticket?[] _tickets = new Ticket?[20];

        public Ticket? this[int index]
        {
            get
            {
                if (index < 0 || index >= _tickets.Length) return null;
                return _tickets[index];
            }
            set
            {
                if (index < 0 || index >= _tickets.Length) return;
                _tickets[index] = value;
            }
        }

        public Ticket? this[string movieName]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(movieName)) return null;

                for (int i = 0; i < _tickets.Length; i++)
                {
                    var t = _tickets[i];
                    if (t is null) continue;

                    if (string.Equals(t.MovieName, movieName.Trim(), StringComparison.OrdinalIgnoreCase))
                        return t;
                }

                return null;
            }
        }

        public bool AddTicket(Ticket t)
        {
            for (int i = 0; i < _tickets.Length; i++)
            {
                if (_tickets[i] is null)
                {
                    _tickets[i] = t;
                    return true;
                }
            }
            return false; 
        }
    }
}
