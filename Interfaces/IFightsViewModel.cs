using BecomeSifu.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace BecomeSifu.Interfaces
{
    public interface IFightsViewModel
    {
        CommandAbstract StartFighting { get; }
        int Wins { get; set; }
        decimal Health { get; set; }

        decimal Attack { get; set; }

        string HealthString { get; set; }
        string AttackString { get; set; }
        bool IsActive { get; set; }
        string FightName { get; set; }
        SolidColorBrush Background { get; set; }
    }
}
