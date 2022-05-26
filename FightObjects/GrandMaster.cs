﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace BecomeSifu.FightObjects
{
    public class GrandMaster : AllFights , IFights
    {
        public GrandMaster()
        {
            Wins = 0;
            Health = ((decimal)Wins + 1) * 100;
            Attack = ((decimal)Wins + 1) * 1000;
            FightName = this.GetType().Name;
            Background = new SolidColorBrush(Colors.PaleGoldenrod);
        }
        public GrandMaster(int wins)
        {
            Wins = wins;
            Health = ((decimal)Wins + 1) * 100;
            Attack = ((decimal)Wins + 1) * 1000;
        }

        private GrandMaster Won(int win)
        {
            return new GrandMaster(win);
        }
    }
}
