using BecomeSifu.Interfaces;
using BecomeSifu.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BecomeSifu.Abstracts
{
    public abstract class FightsViewModelAbstract : FightsViewModel, IFightsViewModel
    {
        public abstract CommandAbstract StartFighting { get; }
        public abstract string FightName { get; set; }
    }
}
