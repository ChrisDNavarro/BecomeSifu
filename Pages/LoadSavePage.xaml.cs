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
    /// Interaction logic for LoadSavePage.xaml
    /// </summary>
    public partial class LoadSavePage : UserControl
    {
        public LoadSavePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageHolder.MainWindow.Load = true;
            PageHolder.MainWindow.LoadState();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageHolder.MainWindow.Load = false;
            PageHolder.DojoPicker.Height = PageHolder.MainWindow.ContentArea.Height;
            PageHolder.DojoPicker.Width = PageHolder.MainWindow.ContentArea.Width;
            PageHolder.MainWindow.ContentArea.Content = PageHolder.DojoPicker;
        }
    }
}
