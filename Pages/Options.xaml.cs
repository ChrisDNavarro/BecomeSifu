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
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : UserControl
    {
        public Options()
        {
            InitializeComponent();
        }

        private void OnOff_Checked(object sender, RoutedEventArgs e)
        {
            PageHolder.MainWindow.Save = false;
        }

        private void OnOff_Unchecked(object sender, RoutedEventArgs e)
        {
            PageHolder.MainWindow.Save = true;
        }
    }
}
