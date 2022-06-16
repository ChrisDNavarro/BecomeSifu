using BecomeSifu.Abstracts;
using BecomeSifu.Controls;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Media;
using System.Xml.Serialization;

namespace BecomeSifu.ViewModels
{
    public class ActionsViewModel : ViewModelBase
    {
        public CommandAbstract PunchesLevelUpCommand => new RelayCommand(x => Punches.TryLevelUp(this));
        public CommandAbstract KicksLevelUpCommand => new RelayCommand(x => Kicks.TryLevelUp(this));
        public CommandAbstract DefensesLevelUpCommand => new RelayCommand(x => Defenses.TryLevelUp(this));
        public CommandAbstract SpecialsLevelUpCommand => new RelayCommand(x => Specials.TryLevelUp(this));


        private SolidColorBrush _BackgroundColor;
        public Color BackgroundColor
        {
            get => _BackgroundColor.Color;
            set => SetProperty(ref _BackgroundColor, new SolidColorBrush(value));
        }
        [XmlIgnore]
        public SolidColorBrush BackgroundIgnorable
        {
            get => _BackgroundColor;
        }

        private SolidColorBrush _ForegroundColor;
        public Color ForegroundColor
        {
            get => _ForegroundColor.Color;
            set => SetProperty(ref _ForegroundColor, new SolidColorBrush(value));
        }
        
        [XmlIgnore]
        public SolidColorBrush ForegroundIgnorable
        {
            get => _ForegroundColor;
        }


        private string _Name;
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }

        private string _LevelUp;
        public string LevelUp
        {
            get => _LevelUp;
            set => SetProperty(ref _LevelUp, value);
        }

        private bool _Enabled;
        public bool Enabled
        {
            get => _Enabled;
            set => SetProperty(ref _Enabled, value);
        }

        private string _Level;
        public string Level
        {
            get => _Level;
            set => SetProperty(ref _Level, value);
        }

        private string _ExpString;
        public string ExpString
        {
            get => _ExpString;
            set => SetProperty(ref _ExpString, value);
        }

        private int _Step;
        public int Step
        {
            get => _Step;
            set => SetProperty(ref _Step, value);
        }

        private bool _MaxLevel;
        public bool MaxLevel
        {
            get => _MaxLevel;
            set => SetProperty(ref _MaxLevel, value);
        }

        private bool _Learned;
        public bool Learned
        {
            get => _Learned;
            set => SetProperty(ref _Learned, value);
        }

        private bool _Learning;
        public bool Learning
        {
            get => _Learning;
            set => SetProperty(ref _Learning, value);
        }

        private int _LevelInt;
        public int LevelInt
        {
            get => _LevelInt;
            set => SetProperty(ref _LevelInt, value);
        }

        private decimal _ExpToNext;
        public decimal ExpToNext
        {
            get => _ExpToNext;
            set => SetProperty(ref _ExpToNext, value);
        }
    }
}
