using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace BecomeSifu.FightObjects
{
    public class DMaster : AllFights , IFights
    {
        public DMaster()
        {
            Wins = 0;
            Health = ((decimal)Wins + 1) * 100;
            Attack = ((decimal)Wins + 1) * 1000;
            FightName = "Master";
            Background = new SolidColorBrush(Colors.IndianRed);
        }
        public DMaster(int wins)
        {
            Wins = wins;
            Health = ((decimal)Wins + 1) * 100;
            Attack = ((decimal)Wins + 1) * 1000;
        }

        private DMaster Won(int win)
        {
            return new DMaster(win);
            
        }
    }
}
