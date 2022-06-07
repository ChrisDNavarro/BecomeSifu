﻿using BecomeSifu.Objects;
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
    /// Interaction logic for PickArtsBonus.xaml
    /// </summary>
    public partial class PickArtsBonus : UserControl
    {
        public PickArtsBonus()
        {
            InitializeComponent();
            PerkIC.ItemsSource = Dojos.Dojo[0].Perks;
        }
    }
}