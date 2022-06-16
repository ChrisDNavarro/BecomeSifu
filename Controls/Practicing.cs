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
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace BecomeSifu.Controls
{
    public class Practicing
    {
        public decimal Energy { get; set; } = 10;
        public decimal EnergyGain { get; set; }
        public decimal EnergyMeditationGain { get; set; }

        private string _EnergyGainString = "0";

        public decimal Exp { get; set; }
        public decimal ExpGain { get; set; }

        public decimal Attack { get; set; }
        public decimal AttackGain { get; set; }


        public decimal Defense { get; set; }
        public decimal DefenseGain { get; set; }

        public decimal Health { get; set; } = 100;
        public decimal HealthGain { get; set; }

        
        public decimal AutoSpeedMultiplier { get; set; } = 1;
        public decimal EnergyGainMultiplier { get; set; } = 1;
        public decimal ExpGainMultiplier { get; set; } = 1;
        

        public DispatcherTimer Timer { get; set; }
        public DispatcherTimer MeditateTimer { get; set; }

        

    }
}
