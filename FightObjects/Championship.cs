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
    public class Championship : AllFights , IFights
    {
        public ICommand StartFighting => new RelayCommand(() => Begin());
        public Championship()
        {
            Wins = 0;
            Health = ((decimal)Wins + 1) * 100000;
            Attack = ((decimal)Wins + 1) * 10000;
            HealthString = Health.ConvertToString();
            AttackString = Attack.ConvertToString();
            FightName = this.GetType().Name;
            Background = new SolidColorBrush(Colors.Silver);
        }
        public void Won(int win)
        {
            Wins = win;
            Health = ((decimal)Wins + 1) * 100000;
            Attack = ((decimal)Wins + 1) * 10000;
            HealthString = Health.ConvertToString();
            AttackString = Attack.ConvertToString();
            if (Wins > 0 && Wins % 5 == 0)
            {
                if (!Dojos.BoundDojo[0].IsTaekwondo)
                {
                    Dojos.Specials[0].AttackEnabled = true;
                    Dojos.Specials.Refresh();
                }
                Dojos.Fights[2].IsActive = true;
            }
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
