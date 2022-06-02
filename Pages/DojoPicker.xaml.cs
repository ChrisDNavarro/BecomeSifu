using BecomeSifu.MartialArts;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BecomeSifu.Pages
{
    /// <summary>
    /// Interaction logic for DojoPicker.xaml
    /// </summary>
    public partial class DojoPicker : UserControl, INotifyPropertyChanged
    {
        public string _SelectMessage = "Become Sifu";
        public string SelectMessage
        {
            get { return _SelectMessage; }
            set
            {
                _SelectMessage = value;
                OnPropertyChanged();
            }
        }
        private string _SelectInfo;
        public string SelectInfo
        {
            get { return _SelectInfo; }
            set
            {
                _SelectInfo = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public DojoPicker()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Content.ToString().ToLower())
            {
                case "taekwondo":
                    Dojos.PickDojo(new Taekwondo());
                    break;
                case "boxing":
                    Dojos.PickDojo(new Boxing());
                    break;
                case "karate":
                    Dojos.PickDojo(new Karate());
                    break;
                default:
                    break;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Karate_MouseEnter(object sender, MouseEventArgs e)
        {
            KarateLogo.Visibility = Visibility.Visible;
            SelectMessage = "Select this Dojo";
        }

        private void Karate_MouseLeave(object sender, MouseEventArgs e)
        {
            KarateLogo.Visibility = Visibility.Hidden;
            SelectMessage = "Become Sifu";
        }

        private void Boxing_MouseEnter(object sender, MouseEventArgs e)
        {
            BoxingRing.Visibility = Visibility.Visible;
            SelectMessage = "Select this Gym";
        }

        private void Boxing_MouseLeave(object sender, MouseEventArgs e)
        {
            BoxingRing.Visibility = Visibility.Hidden;
            SelectMessage = "Become Sifu";
        }

        private void TaeKwonDo_MouseEnter(object sender, MouseEventArgs e)
        {
            TKDTrigrams.Visibility = Visibility.Visible;
            SelectMessage = "Select this Dojang";
        }

        private void TaeKwonDo_MouseLeave(object sender, MouseEventArgs e)
        {
            TKDTrigrams.Visibility = Visibility.Hidden;
            SelectMessage = "Become Sifu";
        }
    }
}
