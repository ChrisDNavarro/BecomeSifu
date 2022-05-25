using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace BecomeSifu.FightObjects
{
    public interface IFights
    {
        int Wins { get; set; }
        ulong Health { get; set; }
        ulong Attack { get; set; }
        bool IsActive { get; set; }
        string FightName { get; }
        SolidColorBrush Background { get; }


    }
}
