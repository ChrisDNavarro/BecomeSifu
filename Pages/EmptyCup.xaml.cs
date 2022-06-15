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

namespace BecomeSifu.Pages
{
    /// <summary>
    /// Interaction logic for EmptyCup.xaml
    /// </summary>
    public partial class EmptyCup : UserControl
    {
        
        public EmptyCup()
        {
            InitializeComponent();
            CupIC.ItemsSource = PageHolder.MainWindow.State.Cup;
        }
    }
}
