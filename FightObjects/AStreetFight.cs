using BecomeSifu.Objects;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace BecomeSifu.FightObjects
{
    public class AStreetFight : AllFights, IFights
    {
        public ICommand StartFighting => new RelayCommand(() => Begin());

        public new bool IsActive = true;

        public AStreetFight()
        {
            Wins = 0;
            Health = ((decimal)Wins + 1) * 1000;
            Attack = ((decimal)Wins + 1) * 100;
            HealthString = Health.ConvertToString();
            AttackString = Attack.ConvertToString();
            FightName = "Street Fight";
            Background = new SolidColorBrush(Colors.Silver);
        }

        public void Won(int win)
        {
            Wins += win;
            Health = ((decimal)Wins + 1) * 1000;
            Attack = ((decimal)Wins + 1) * 100;
            HealthString = Health.ConvertToString();
            AttackString = Attack.ConvertToString();
            Dojos.Dojo[0].EnergyGainMultiplier += .01M;

            if (Wins == 5)
            {
                Dojos.Dojo[0].CanAutoMeditate = Visibility.Visible;
                Dojos.Dojo.Refresh();
            }


            Dojos.Fights.Refresh();
        }
        public async void Begin()
        {
            bool first = Convert.ToBoolean(RNG.Next(0, 2));
            Won(await Task.Run(() => Fight()));
        }
    }
}
