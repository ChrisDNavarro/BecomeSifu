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
using System.Windows.Threading;

namespace BecomeSifu.Pages
{
    /// <summary>
    /// Interaction logic for Meditate.xaml
    /// </summary>
    public partial class Meditate : UserControl
    {
        public Meditate()
        {
            InitializeComponent();
            Dojos.BoundDojo[0].MeditateTimer = new DispatcherTimer();
            MeditateIC.ItemsSource = Dojos.BoundDojo;
        }
    }
}
