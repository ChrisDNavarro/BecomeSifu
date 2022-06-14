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


namespace BecomeSifu.Controls
{
    public class Practicing
    {
        public decimal Energy { get; set; } = 10;
        public decimal EnergyGain { get; set; }
        public decimal EnergyMeditationGain { get; set; }
        private string _EnergyString = "10";
        public string EnergyString
        {
            get => _EnergyString;
            set
            {
                _EnergyString = value;
                Dojos.Practice[0].EnergyString = value;
            }
        }

        private string _EnergyGainString = "0";
        public string EnergyGainString
        {
            get => _EnergyGainString;
            set
            {
                _EnergyGainString = value;
                Dojos.Practice[0].EnergyGainString = value;
            }
        }
        private string _EnergyMeditationGainString = "0";
        public string EnergyMeditationGainString
        {
            get => _EnergyMeditationGainString;
            set
            {
                _EnergyMeditationGainString = value;
                Dojos.Practice[0].EnergyMeditationGainString = value;
            }
        }

        public decimal Exp { get; set; }
        public decimal ExpGain { get; set; }
        private string _ExpString = "0";
        public string ExpString
        {
            get => _ExpString;
            set
            {
                _ExpString = value;
                Dojos.Practice[0].ExpString = value;
            }
        }
        private string _ExpGainString = "0";
        public string ExpGainString
        {
            get => _ExpGainString;
            set
            {
                _ExpGainString = value;
                Dojos.Practice[0].ExpGainString = value;
            }
        }

        public decimal Attack { get; set; }
        public decimal AttackGain { get; set; }
        private string _AttackString = "0";
        public string AttackString
        {
            get => _AttackString;
            set
            {
                _AttackString = value;
                Dojos.Practice[0].AttackString = value;
            }
        }
        private string _AttackGainString = "0";
        public string AttackGainString
        {
            get => _AttackGainString;
            set
            {
                _AttackGainString = value;
                Dojos.Practice[0].AttackGainString = value;
            }
        }


        public decimal Defense { get; set; }
        public decimal DefenseGain { get; set; }
        private string _DefenseString = "0";
        public string DefenseString
        {
            get => _DefenseString;
            set
            {
                _DefenseString = value;
                Dojos.Practice[0].DefenseString = value;
            }
        }

        private string _DefenseGainString = "0";
        public string DefenseGainString
        {
            get => _DefenseGainString;
            set
            {
                _DefenseGainString = value;
                Dojos.Practice[0].DefenseGainString = value;
            }
        }

        public decimal Health { get; set; } = 100;
        public decimal HealthGain { get; set; }
        private string _HealthString = "100";
        public string HealthString
        {
            get => _HealthString;
            set
            {
                _HealthString = value;
                Dojos.Practice[0].HealthString = value;
            }
        }

        private string _HealthGainString = "0";
        public string HealthGainString
        {
            get => _HealthGainString;
            set
            {
                _HealthGainString = value;
                Dojos.Practice[0].HealthGainString = value;
            }
        }

        private bool _IsMeditating;
        public bool IsMeditating
        {
            get => _IsMeditating;
            set
            {
                _IsMeditating = value;
                Dojos.Practice[0].IsMeditating = value;
            }
        }
        private Visibility _MeditateOption = Visibility.Collapsed;
        public Visibility MeditateOption
        {
            get => _MeditateOption;
            set
            {
                _MeditateOption = value;
                Dojos.Practice[0].MeditateOption = value;
            }
        }

        private string _IsMeditatingString = "Start Meditating";
        public string IsMeditatingString
        {
            get => _IsMeditatingString;
            set
            {
                _IsMeditatingString = value;
                Dojos.Practice[0].IsMeditatingString = value;
            }
        }
        private bool _AutoMeditate;
        public bool AutoMeditate
        {
            get => _AutoMeditate;
            set
            {
                _AutoMeditate = value;
                Dojos.Practice[0].AutoMeditate = value;
            }
        }

        private bool _AutoPractice;
        public bool AutoPractice
        {
            get => _AutoPractice;
            set
            {
                _AutoPractice = value;
                Dojos.Practice[0].AutoPractice = value;
            }
        }

        private Visibility _CanAutoMeditate = Visibility.Collapsed;
        public Visibility CanAutoMeditate
        {
            get => _CanAutoMeditate;
            set
            {
                _CanAutoMeditate = value;
                Dojos.Practice[0].CanAutoMeditate = value;
            }
        }

        private Visibility _CanAutoPractice = Visibility.Visible;
        public Visibility CanAutoPractice
        {
            get => _CanAutoPractice;
            set
            {
                _CanAutoPractice = value;
                Dojos.Practice[0].CanAutoPractice = value;
            }
        }

        private string _Rate = "Auto";
        public string Rate
        {
            get => _Rate;
            set
            {
                _Rate = value;
                Dojos.Practice[0].Rate = value;
            }
        }
        public decimal AutoSpeedMultiplier { get; set; } = 1;
        public decimal EnergyGainMultiplier { get; set; } = 1;
        public decimal ExpGainMultiplier { get; set; } = 1;
        

        public DispatcherTimer Timer { get; set; }
        public DispatcherTimer MeditateTimer { get; set; }

        private RepeatBehavior _Repeat = new RepeatBehavior(1);
        public RepeatBehavior Repeat
        {
            get => _Repeat;
            set
            {
                _Repeat = value;
                Dojos.Practice[0].Repeat = value;
            }
        }

    }
}
