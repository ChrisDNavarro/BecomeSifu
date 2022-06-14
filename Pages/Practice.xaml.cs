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
    /// Interaction logic for Growth.xaml
    /// </summary>
    public partial class Practice : UserControl
    {
        public Practice()
        {
            InitializeComponent();
            Dojos.Dojo[0].Timer = new DispatcherTimer();
            PracticeIC.ItemsSource = Dojos.Practice;
        }
    }
}
