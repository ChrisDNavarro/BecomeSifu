using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace BecomeSifu.FightObjects
{
    public class AllFights
    {
        public int Wins { get; set; }
        public ulong Health { get; set; }
        public ulong Attack { get; set; }
        public bool IsActive { get; set; }
        public string FightName { get; set; }
        public SolidColorBrush Background { get; set; }

    }
}
