using BecomeSifu.Controls;
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

namespace BecomeSifu.Pages
{
    /// <summary>
    /// Interaction logic for MessagePopUp.xaml
    /// </summary>
    public partial class MessagePopUp : Window
    {
        public MessagePopUp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
