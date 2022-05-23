using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace BecomeSifu.Objects
{
    public class Defenses
    {
        public SolidColorBrush BackgroundColor { get; set; }
        public string DefenseName { get; set; }

        public string LevelUp { get; set; }
        public int Step { get; set; }
        public bool DefenseEnabled { get; set; }
        public string Level { get; set; } = "0";
        public ulong ExpToNext { get; set; } = 10;


        public Defenses(string name, int step)
        {
            DefenseName = name;
            Step = step + 1;
            LevelUp = $"Level Up\n{ExpToNext}";

            BackgroundColor = Step % 2 == 0
                ? new SolidColorBrush(Colors.IndianRed)
                : new SolidColorBrush(Colors.PaleGoldenrod);
        }
    }
}
