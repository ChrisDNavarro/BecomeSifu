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
    public class BTournament : AllFights , IFights
    {
        public ICommand StartFighting => new RelayCommand(() => Begin());
        public BTournament()
        {
            Wins = 0;
            Health = ((decimal)Wins + 1) * 10000;
            Attack = ((decimal)Wins + 1) * 1000;
            HealthString = Health.ConvertToString();
            AttackString = Attack.ConvertToString();
            FightName = "Tournament Bout";
            Background = new SolidColorBrush(Colors.LightSteelBlue);
        }
        public void Won(int win)
        {
            Wins += win;
            Health = ((decimal)Wins + 1) * 10000;
            Attack = ((decimal)Wins + 1) * 1000;
            HealthString = Health.ConvertToString();
            AttackString = Attack.ConvertToString();
            if (Wins >= 1 && Wins < 1000)
            {
                Dojos.Dojo[0].AutoSpeedMultiplier = 1M - (.001M * Wins);
                Dojos.Dojo.Refresh();
            }
            if (Wins > 0 && Wins % 5 == 0)
            {
                Dojos.Fights[2].IsActive = true;
                if (Wins / 5 == 1)
                {
                    Extensions.CreateMessage("Championship", true);
                }
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
