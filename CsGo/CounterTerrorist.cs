using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGo
{
    internal class CounterTerrorist : Team
    {
        public int DefuseBomb(int timeLeft)
        {
            Console.WriteLine($"Counter Terrorist is trying to defuse the bomb! {timeLeft} seconds left!");
            return 5;
        }
    }
}
