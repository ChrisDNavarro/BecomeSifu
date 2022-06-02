using BecomeSifu.Objects;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace BecomeSifu.FightObjects
{
    public class GrandMaster : AllFights , IFights
    {
        public ICommand StartFighting => new RelayCommand(async () => await Task.Run(() => Begin()));
        public GrandMaster()
        {
            Wins = 0;
            Health = ((decimal)Wins + 1) * 10000000;
            Attack = ((decimal)Wins + 1) * 1000000;
            HealthString = Health.ConvertToString();
            AttackString = Attack.ConvertToString();
            FightName = this.GetType().Name;
            Background = new SolidColorBrush(Colors.Silver);
        }
        public void Won(int win)
        {
            Wins = win;
            Health = ((decimal)Wins + 1) * 10000000;
            Attack = ((decimal)Wins + 1) * 1000000;
            HealthString = Health.ConvertToString();
            AttackString = Attack.ConvertToString();

            IsActive = false;
            Dojos.Fights.Refresh();
        }
        public async void Begin()
        {
            bool first = Convert.ToBoolean(RNG.Next(0, 2));
            Won(await Task.Run(() => Fight()));
        }
    }
}
