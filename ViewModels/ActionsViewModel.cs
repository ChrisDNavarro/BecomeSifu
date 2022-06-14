using BecomeSifu.Objects;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace BecomeSifu.ViewModels
{
    public class ActionsViewModel : ViewModelBase
    {
        public ICommand PunchesLevelUpCommand => new RelayCommand(() => Punches.TryLevelUp(this));
        public ICommand KicksLevelUpCommand => new RelayCommand(() => Kicks.TryLevelUp(this));
        public ICommand DefensesLevelUpCommand => new RelayCommand(() => Defenses.TryLevelUp(this));
        public ICommand SpecialsLevelUpCommand => new RelayCommand(() => Specials.TryLevelUp(this));


        private SolidColorBrush _BackgroundColor;
        public SolidColorBrush BackgroundColor
        {
            get => _BackgroundColor;
            set => SetProperty(ref _BackgroundColor, value);
        }

        private SolidColorBrush _ForegroundColor;
        public SolidColorBrush ForegroundColor
        {
            get => _ForegroundColor;
            set => SetProperty(ref _ForegroundColor, value);
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
