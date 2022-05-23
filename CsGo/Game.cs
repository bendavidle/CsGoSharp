using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGo
{
    internal class Game
    {
        private readonly CounterTerrorist _counterTerrorist;
        private readonly Terrorist _terrorist;
        public bool BombSiteFound { get; private set; }
        public bool Finished { get; private set; }
        private bool _bombPlanted;

        public Game()
        {
            _counterTerrorist = new CounterTerrorist();
            _terrorist = new Terrorist();
            _bombPlanted = false;
        }

        public void Run()
        {
            if (BombSiteFound)
            {
                for (int i = 20; i >= 0; i--)
                {
                    if (!_bombPlanted)
                    {
                        i -= _terrorist.PlantBomb(i);
                        _bombPlanted = true;
                    }

                    _counterTerrorist.Kill(_terrorist, "Counter Terrorists", 3, i);
                    _terrorist.Kill(_counterTerrorist, "Terrorists", 7, i);

                    if (!_terrorist.Members.All(mem => mem.IsDead)) continue;
                    Console.WriteLine("All Terrorists are dead!");
                    i -= _counterTerrorist.DefuseBomb(i);
                    if (i < 0) continue;
                    Finished = true;
                    Console.WriteLine("The bomb was defused, Counter Terrorists win!");
                    break;
                }

                if (!Finished)
                {
                    Finished = true;
                    Console.WriteLine("The bomb went off, Terrorist win!");
                }

            }
            else
            {
                BombSiteFound = _terrorist.FindBombSite();

                _terrorist.Kill(_counterTerrorist, "Terrorists", 7);
                _counterTerrorist.Kill(_terrorist, "Counter Terrorists", 5);


                if (_counterTerrorist.Members.All(mem => mem.IsDead) | _terrorist.Members.All(mem => mem.IsDead))
                {
                    Finished = true;
                    Console.WriteLine("A team died before the bomb was planted!");
                }
            }



        }
    }
}
