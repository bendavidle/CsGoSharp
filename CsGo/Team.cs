using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGo
{
    internal class Team : ITeam
    {
        public Member[] Members { get; }

        public Team()
        {
            Members = new Member[5];
            for (int i = 0; i < Members.Length; i++)
            {
                Members[i] = new Member();
            }
        }

        public void Kill(Team team, string teamName, int maxVal)
        {
            bool kill = IsSuccessful(maxVal);
            if (!kill) return;

            Random rnd = new Random();

            string opponentName = teamName == "Counter Terrorists" ? "Terrorist" : "Counter Terrorists";

            var member = team.Members[rnd.Next(0, team.Members.Length)];
            if (!member.IsDead)
            {
                Console.WriteLine($"{teamName} killed a member from {opponentName}!");
                member.IsDead = true;
            }
            else
            {
                Console.WriteLine($"{teamName} moves forward.");
            }
        }

        public void Kill(Team team, string teamName, int maxVal, int timeLeft)
        {
            bool kill = IsSuccessful(maxVal);
            if (!kill) return;

            Random rnd = new Random();

            string opponentName = teamName == "Counter Terrorists" ? "Terrorist" : "Counter Terrorists";

            var member = team.Members[rnd.Next(0, team.Members.Length)];
            if (!member.IsDead)
            {
                Console.WriteLine($"{teamName} killed a member from {opponentName}! {timeLeft} seconds left!");
                member.IsDead = true;
            }
            else
            {
                Console.WriteLine($"{teamName} moves forward. {timeLeft} seconds left!");
            }
        }

        protected bool IsSuccessful(int maxValue)
        {
            Random rnd = new Random();
            return rnd.Next(0, maxValue) == 2;
        }
    }
}
