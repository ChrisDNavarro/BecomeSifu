using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace BecomeSifu.FightObjects
{
    public class BTournament : AllFights , IFights
    {
        public BTournament()
        {
            Wins = 0;
            Health = ((ulong)Wins + 1) * 100;
            Attack = ((ulong)Wins + 1) * 1000;
            FightName = "Tournament Bout";
            Background = new SolidColorBrush(Colors.IndianRed);
        }
        public BTournament(int wins)
        {
            Wins = wins;
            Health = ((ulong)Wins + 1) * 100;
            Attack = ((ulong)Wins + 1) * 1000;
        }

        private BTournament Won(int win)
        {
            return new BTournament(win);
        }
    }
}
