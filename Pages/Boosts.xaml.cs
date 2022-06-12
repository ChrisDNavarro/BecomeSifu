using BecomeSifu.Controls;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BecomeSifu.Pages
{
    /// <summary>
    /// Interaction logic for Advances.xaml
    /// </summary>
    public partial class Boosts : UserControl
    {
        public Boosts()
        {
            InitializeComponent();
            BoostsController.AutoPurchase = new DispatcherTimer();
            BoostsController.InitializeTimer();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            BoostsController.UpdateBoost(Convert.ToInt32(radioButton.Tag));
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            BoostsController.StartTimer();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            BoostsController.StopTimer();
        }
    }
}
