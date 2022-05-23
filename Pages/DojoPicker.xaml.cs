using BecomeSifu.MartialArts;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
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
    public partial class DojoPicker : UserControl
    {
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
    }
}
