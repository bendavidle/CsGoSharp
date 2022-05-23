using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGo
{

    internal class Terrorist : Team
    {

        public bool FindBombSite()
        {
            return IsSuccessful(10);
        }

        public int PlantBomb(int time)
        {
            Console.WriteLine($"The Terrorist planted the bomb! {time - 5} seconds left!");
            return 5;
        }


    }
}
