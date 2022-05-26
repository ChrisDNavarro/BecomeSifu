using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace BecomeSifu.Objects
{
    public class Buttons
    {
        public SolidColorBrush BackgroundColor { get; set; }
        public SolidColorBrush ForegroundColor { get; set; }
        public string AttackName { get; set; }
        public string LevelUp { get; set; }
        public int Step { get; set; }
        public bool AttackEnabled { get; set; }
        public bool MaxLevel { get; set; }
        public bool Learned { get; set; }
        public bool AllDefense { get; set; }
        public bool AllKicks { get; set; }
        public string Level { get; set; } = "0";
        public decimal ExpToNext { get; set; } = 10;
        public string ExpString { get; set; }
    
    }
}
