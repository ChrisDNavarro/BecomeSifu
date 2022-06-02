using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace BecomeSifu.FightObjects
{
    public interface IFights
    {
        int Wins { get; set; }
        decimal Health { get; set; }
        decimal Attack { get; set; }
        string HealthString { get; set; }
        string AttackString { get; set; }
        bool IsActive { get; set; }
        string FightName { get; set; }
        SolidColorBrush Background { get; set; }
        void Begin();
        ICommand StartFighting { get; }
    }
}
