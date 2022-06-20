using BecomeSifu.Abstracts;
using BecomeSifu.Controls;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using WpfAnimatedGif;

namespace BecomeSifu.ViewModels
{
    public class PracticeViewModel : ViewModelBase
    {
        public CommandAbstract PracticeClick => new RelayCommand(x => PageHolder.MainWindow.DojoState.Dojo[0].Practice());

        public CommandAbstract MeditateClick => new RelayCommand(x => PageHolder.MainWindow.DojoState.Dojo[0].Meditation());

        public CommandAbstract AutoPracticeCheck => new RelayCommand(x => PageHolder.MainWindow.DojoState.Dojo[0].StartStopAutoPractice());

        public CommandAbstract AutoMeditateCheck => new RelayCommand(x => PageHolder.MainWindow.DojoState.Dojo[0].StartStopAutoMeditate());

        public CommandAbstract StartStopMeditationCommand => new RelayCommand(x => PageHolder.MainWindow.DojoState.Dojo[0].StartStopMeditation());

        



        private string _EnergyGainString = "0";
        public string EnergyGainString
        {
            get => _EnergyGainString;
            set => SetProperty(ref _EnergyGainString, value);
        }


        private string _EnergyString = "10";
        public string EnergyString
        {
            get => _EnergyString;
            set => SetProperty(ref _EnergyString, value);
        }

        private string _EnergyMeditationGainString = "0";
        public string EnergyMeditationGainString
        {
            get => _EnergyMeditationGainString;
            set => SetProperty(ref _EnergyMeditationGainString, value);
        }

        private string _ExpString = "0";
        public string ExpString
        {
            get => _ExpString;
            set => SetProperty(ref _ExpString, value);
        }

        private string _ExpGainString ="0";
        public string ExpGainString
        {
            get => _ExpGainString;
            set => SetProperty(ref _ExpGainString, value);
        }


        private string _AttackString ="0";
        public string AttackString
        {
            get => _AttackString;
            set => SetProperty(ref _AttackString, value);
        }

        private string _AttackGainString = "0";
        public string AttackGainString
        {
            get => _AttackGainString;
            set => SetProperty(ref _AttackGainString, value);
        }

        private string _DefenseString = "0";
        public string DefenseString
        {
            get => _DefenseString;
            set => SetProperty(ref _DefenseString, value);
        }

        private string _DefenseGainString = "0";
        public string DefenseGainString
        {
            get => _DefenseGainString;
            set => SetProperty(ref _DefenseGainString, value);
        }


        private string _HealthString = "100";
        public string HealthString
        {
            get => _HealthString;
            set => SetProperty(ref _HealthString, value);
        }

        private string _HealthGainString = "0";
        public string HealthGainString
        {
            get => _HealthGainString;
            set => SetProperty(ref _HealthGainString, value);
        }

        private bool _IsMeditating;
        public bool IsMeditating
        {
            get => _IsMeditating;
            set => SetProperty(ref _IsMeditating, value);
        }


        private Visibility _MeditateOption = Visibility.Collapsed;
        public Visibility MeditateOption
        {
            get => _MeditateOption;
            set => SetProperty(ref _MeditateOption, value);
        }

        private string _IsMeditatingString = "Start Meditating";
        public string IsMeditatingString
        {
            get => _IsMeditatingString;
            set => SetProperty(ref _IsMeditatingString, value);
        }

        private bool _AutoMeditate;
        public bool AutoMeditate
        {
            get => _AutoMeditate;
            set => SetProperty(ref _AutoMeditate, value);
        }

        private bool _AutoPractice;
        public bool AutoPractice
        {
            get => _AutoPractice;
            set => SetProperty(ref _AutoPractice, value);
        }

        private Visibility _CanAutoMeditate = Visibility.Collapsed;
        public Visibility CanAutoMeditate
        {
            get => _CanAutoMeditate;
            set => SetProperty(ref _CanAutoMeditate, value);
        }

        private Visibility _CanAutoPractice = Visibility.Visible;
        public Visibility CanAutoPractice
        {
            get => _CanAutoPractice;
            set => SetProperty(ref _CanAutoPractice, value);
        }

        private string _Rate = "Auto";
        public string Rate
        {
            get => _Rate;
            set => SetProperty(ref _Rate, value);
        }


        private RepeatBehavior _Repeat = new RepeatBehavior(1);
        public RepeatBehavior Repeat
        {
            get => _Repeat;
            set => SetProperty(ref _Repeat, value);
        }

        private RepeatBehavior _Practiced = new RepeatBehavior(1);
        public RepeatBehavior Practiced
        {
            get => _Practiced;
            set => SetProperty(ref _Practiced, value);
        }

        private ImageSource _Source = new BitmapImage(new Uri("pack://application:,,,/Animations/Kicks.gif"));
        public string Source
        {
            set => SetProperty(ref _Source, new BitmapImage(new Uri("pack://application:,,," + value)));
        }

        [XmlIgnore]
        public ImageSource SourceIgnorable
        {
            get => _Source;
        }

        private bool _Practicing;
        public bool Practicing
        {
            get => _Practicing;
            set => SetProperty(ref _Practicing, value);
        }

    }
}
