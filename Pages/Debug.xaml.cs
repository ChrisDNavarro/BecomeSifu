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

namespace BecomeSifu.Pages
{
    /// <summary>
    /// Interaction logic for Debug.xaml
    /// </summary>
    public partial class Debug : UserControl
    {
        public Debug()
        {
            InitializeComponent();
        }

        private void Energy_Click(object sender, RoutedEventArgs e)
        {
            PageHolder.MainWindow.State.Dojo[0].Energy += 1000000000;
            PageHolder.MainWindow.State.Dojo[0].EnergyString = PageHolder.MainWindow.State.Dojo[0].Energy.ConvertToString();
            Extensions.UpdateActives();
        }

        private void Exp_Click(object sender, RoutedEventArgs e)
        {
            PageHolder.MainWindow.State.Dojo[0].Exp += 1000000000;
            PageHolder.MainWindow.State.Dojo[0].ExpString = PageHolder.MainWindow.State.Dojo[0].Exp.ConvertToString();
            Extensions.UpdateActives();
        }

        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            PageHolder.MainWindow.State.Dojo[0].Attack += 1000000;
            PageHolder.MainWindow.State.Dojo[0].AttackString = PageHolder.MainWindow.State.Dojo[0].Attack.ConvertToString();
            Extensions.UpdateActives();
        }

        private void Defense_Click(object sender, RoutedEventArgs e)
        {
            PageHolder.MainWindow.State.Dojo[0].Defense += 1000000;
            PageHolder.MainWindow.State.Dojo[0].DefenseString = PageHolder.MainWindow.State.Dojo[0].Defense.ConvertToString();
            Extensions.UpdateActives();
        }

        private void Health_Click(object sender, RoutedEventArgs e)
        {
            PageHolder.MainWindow.State.Dojo[0].Health += 1000000;
            PageHolder.MainWindow.State.Dojo[0].HealthString = PageHolder.MainWindow.State.Dojo[0].Health.ConvertToString();
            Extensions.UpdateActives();
        }
    }
}
