using BecomeSifu.Interfaces;
using BecomeSifu.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace BecomeSifu.Abstracts
{
    public abstract class FightsViewModelAbstract : FightsViewModel
    {
        public abstract CommandAbstract StartFighting { get; }
        public abstract string FightName { get; set; }
    }
}
