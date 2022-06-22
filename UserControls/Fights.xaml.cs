using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BecomeSifu.Controls;
using System.Xml.Serialization;
using System.Threading.Tasks;
using BecomeSifu.Abstracts;
using BecomeSifu.ViewModels;

namespace BecomeSifu.UserControls
{
    /// <summary>
    /// Interaction logic for Fights.xaml
    /// </summary>
    public partial class Fights : UserControl
    {
        public Fights()
        {
            InitializeComponent();
            FightsIC.ItemsSource = PageHolder.MainWindow.DojoState.FightsVMs;
        }

        public void DoneFighting(object sender, RoutedEventArgs e)
        {
            foreach(FightsViewModel x in PageHolder.MainWindow.DojoState.FightsVMs)
                { 
                    x.Fought = true; 
                    x.Gif = "null.gif"; 
                }
        }
    }
}
