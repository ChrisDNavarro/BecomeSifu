﻿using BecomeSifu.Objects;
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
using System.Windows.Threading;
using BecomeSifu.Controls;
using System.Xml.Serialization;

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
            PageHolder.MainWindow.DojoState.Dojo[0].Timer = new DispatcherTimer();
            PracticeIC.ItemsSource = PageHolder.MainWindow.DojoState.Practice;
        }
    }
}
