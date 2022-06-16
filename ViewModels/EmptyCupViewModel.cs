using BecomeSifu.Abstracts;
using BecomeSifu.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace BecomeSifu.ViewModels
{
    public class EmptyCupViewModel : ViewModelBase
    {
        public CommandAbstract EmptyYourCup => new RelayCommand(x => EmptyCupControl.EmptyingCup());

        private string _CurrentBonus = "No Bonus";
        [XmlAttribute("currentBonus")]
        public string CurrentBonus
        {
            get => _CurrentBonus;
            set => SetProperty(ref _CurrentBonus, value);
        }

        private string _ButtonName = "First, fill your cup.";
        [XmlAttribute("buttonName")]
        public string ButtonName
        {
            get => _ButtonName;
            set => SetProperty(ref _ButtonName, value);
        }

        private bool _ButtonActive;
        [XmlAttribute("buttonActive")]
        public bool ButtonActive
        {
            get => _ButtonActive;
            set => SetProperty(ref _ButtonActive, value);
        }

        private ImageSource _ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Resources/CupIsEmpty.png"));
        [XmlAttribute("imageSource")]
        public string ImageSource
        {
            set => SetProperty(ref _ImageSource, new BitmapImage(new Uri(value)));
        }
        [XmlIgnore]
        public ImageSource ImageIgnorable
        {
            get => _ImageSource;
        }

    }
}
