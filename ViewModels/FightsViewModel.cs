using BecomeSifu.FightObjects;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Media;
using System.Xml.Serialization;

namespace BecomeSifu.ViewModels
{
    public class FightsViewModel : ViewModelBase
    {
        private int _Wins;
        public int Wins
        {
            get => _Wins;
            set => SetProperty(ref _Wins, value);
        }

        private decimal _Health;
        public decimal Health
        {
            get => _Health;
            set => SetProperty(ref _Health, value);
        }

        private decimal _Attack;
        public decimal Attack
        {
            get => _Attack;
            set => SetProperty(ref _Attack, value);
        }

        private string _HealthString;
        public string HealthString
        {
            get => _HealthString;
            set => SetProperty(ref _HealthString, value);
        }

        private string _AttackString;
        public string AttackString
        {
            get => _AttackString;
            set => SetProperty(ref _AttackString, value);
        }

        private bool _IsActive;
        public bool IsActive
        {
            get => _IsActive;
            set => SetProperty(ref _IsActive, value);
        }

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
    }
}
