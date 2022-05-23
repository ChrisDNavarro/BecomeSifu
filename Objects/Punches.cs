using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Media;

namespace BecomeSifu.Objects
{
    public class Punches : Buttons
    {        
        public Punches(string name, int step)
        {
            AttackName = name;
            Step = step + 1;
            LevelUp = $"Level Up\n{ExpToNext}";


            BackgroundColor = Step % 2 == 0
                ? new SolidColorBrush(Colors.IndianRed)
                : new SolidColorBrush(Colors.PaleGoldenrod);
        }       
    }
}
