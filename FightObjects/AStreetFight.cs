using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace BecomeSifu.FightObjects
{
    public class AStreetFight : AllFights, IFights
    {
        public new bool IsActive = true;

        public AStreetFight()
        {
            Wins = 0;
            Health = ((decimal)Wins + 1) * 1000;
            Attack = ((decimal)Wins + 1) * 100;
            FightName = "Street Fight";
            Background = new SolidColorBrush(Colors.PaleGoldenrod);
        }
        public AStreetFight(int wins)
        {
            Wins = wins;
            Health = ((decimal)Wins + 1) * 100;
            Attack = ((decimal)Wins + 1) * 1000;
        }

        private AStreetFight Won(int win)
        {
            return new AStreetFight(win);
        }
    }
}
