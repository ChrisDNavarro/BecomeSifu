using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;

using BecomeSifu.Controls;
using BecomeSifu.Abstracts;

namespace BecomeSifu.ViewModels
{
    public class BTournamentViewModel : FightsViewModelAbstract
    {
        public override CommandAbstract StartFighting => new RelayCommand(x => PageHolder.MainWindow.State.Fights[1].Begin());


        private string _FightName;
        public override string FightName
        {
            get => _FightName;
            set => SetProperty(ref _FightName, value);
        }
    }
}
