using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace BecomeSifu.Objects
{
    public class Buttons
    {
        public SolidColorBrush BackgroundColor { get; set; }
        public string AttackName { get; set; }

        public string LevelUp { get; set; }
        public int Step { get; set; }
        public bool AttackEnabled { get; set; }
        public string Level { get; set; } = "0";
        public ulong ExpToNext { get; set; } = 10;
    }
}
