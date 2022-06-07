using BecomeSifu.MartialArts;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Threading;

namespace BecomeSifu.Controls
{
    public class Practicing
    {
        public decimal Energy { get; set; } = 10;
        public decimal EnergyGain { get; set; }
        public string EnergyString { get; set; } = "10";
        public string EnergyGainString { get; set; } = "0";

        public decimal Exp { get; set; }
        public decimal ExpGain { get; set; }
        public string ExpString { get; set; } = "0";
        public string ExpGainString { get; set; } = "0";

        public decimal Attack { get; set; }
        public decimal AttackGain { get; set; }
        public string AttackString { get; set; } = "0";
        public string AttackGainString { get; set; } = "0";


        public decimal Defense { get; set; }
        public decimal DefenseGain { get; set; }
        public string DefenseString { get; set; } = "0";
        public string DefenseGainString { get; set; } = "0";

        public decimal Health { get; set; } = 100;
        public decimal HealthGain { get; set; }
        public string HealthString { get; set; } = "100";
        public string HealthGainString { get; set; } = "0";

        public bool IsMeditating { get; set; }
        public Visibility MeditateOption { get; set; } = Visibility.Collapsed;
        public string IsMeditatingString { get; set; } = "Start Mediation";
        public bool AutoMeditate { get; set; }
        public bool AutoPractice { get; set; }
        public Visibility CanAutoMeditate { get; set; } = Visibility.Collapsed;
        public Visibility CanAutoPractice { get; set; } = Visibility.Visible;
        public decimal Multiplier { get; set; } = 1;
        public string Rate { get; set; } = "Auto";

        public DispatcherTimer Timer { get; set; }
        public DispatcherTimer MeditateTimer { get; set; }

    }
}
