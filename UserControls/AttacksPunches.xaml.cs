using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace BecomeSifu.UserControls
{
    /// <summary>
    /// Interaction logic for AttacksPunches.xaml
    /// </summary>
    public partial class AttacksPunches : UserControl
    {
        public AttacksPunches()
        {
            InitializeComponent();
            PunchesIC.ItemsSource = Dojos.Punches;
        }
    }
}
