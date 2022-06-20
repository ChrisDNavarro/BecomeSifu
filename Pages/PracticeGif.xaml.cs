using BecomeSifu.Controls;
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
    /// Interaction logic for PracticeGif.xaml
    /// </summary>
    public partial class PracticeGif : UserControl
    {
        public PracticeGif()
        {
            InitializeComponent();
            PracticeGifIC.ItemsSource = PageHolder.MainWindow.DojoState.Practice;
        }

        public void UpdatePracticing(object sender, RoutedEventArgs e)
        {
            PageHolder.MainWindow.DojoState.Practice[0].Practicing = false;
        }
    }
}
