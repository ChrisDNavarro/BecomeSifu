using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace BecomeSifu.FightObjects
{
    public class Championship : AllFights , IFights
    {
        public Championship()
        {
            Wins = 0;
            Health = ((decimal)Wins + 1) * 100;
            Attack = ((decimal)Wins + 1) * 1000;
            FightName = this.GetType().Name;
            Background = new SolidColorBrush(Colors.PaleGoldenrod);
        }
        public Championship(int wins)
        {
            Wins = wins;
            Health = ((decimal)Wins + 1) * 100;
            Attack = ((decimal)Wins + 1) * 1000;
        }

        private Championship Won(int win)
        {
            return new Championship(win);
        }
    }
}
