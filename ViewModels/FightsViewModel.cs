using BecomeSifu.Abstracts;
using BecomeSifu.Controls;
using BecomeSifu.FightObjects;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace BecomeSifu.ViewModels
{
    public class FightsViewModel : ViewModelBase
    {
        public CommandAbstract FightEnd => new RelayCommand(x => UpdateFighting());

        private void UpdateFighting()
        {
            Gif = "null.gif";
        }

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

        private ImageSource _Gif;
        public string Gif
        {
            set => SetProperty(ref _Gif, new BitmapImage(new Uri("pack://application:,,,/Animations/" + value)), "FightGif", true);
        }

        [XmlIgnore]
        public ImageSource FightGif
        {
            get => _Gif;
        }

        private RepeatBehavior _Fighting= new RepeatBehavior(1);
        public RepeatBehavior Fighting
        {
            get => _Fighting;
            set => SetProperty(ref _Fighting, value);
        }

        private bool _Fought = true;
        public bool Fought
        {
            get => _Fought;
            set => SetProperty(ref _Fought, value);
        }

    }
}
