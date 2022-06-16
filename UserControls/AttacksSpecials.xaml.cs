﻿using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace BecomeSifu.UserControls
{
    /// <summary>
    /// Interaction logic for AttacksSpecials.xaml
    /// </summary>
    public partial class AttacksSpecials : UserControl
    {

        public AttacksSpecials()
        {
            InitializeComponent();
            SpecialsIC.ItemsSource = PageHolder.MainWindow.DojoState.Specials;
        }
    }
}
