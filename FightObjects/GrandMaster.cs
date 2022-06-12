using BecomeSifu.Controls;
using BecomeSifu.Logging;
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
        public ICommand StartFighting => new RelayCommand(() => Begin());
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
            try
            {
                Wins += win;
                LogIt.Write($"Finalizing Results: fight complete with {win} wins for a total of {Wins} wins");
                Health = ((decimal)Wins + 1) * 10000000;
                Attack = ((decimal)Wins + 1) * 1000000;
                HealthString = Health.ConvertToString();
                AttackString = Attack.ConvertToString();
                LogIt.Write($"Reset Healt and attack for enemy.");
                if(win == 1)
                {
                    EmptyCupControl.DefeatedGrandMaster = true;
                }

                IsActive = false;
                Dojos.Fights.Refresh();
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
        public async void Begin()
        {
            try
            {
                bool first = Convert.ToBoolean(RNG.Next(0, 2));
                LogIt.Write($"--------------FIGHT----------------");
                LogIt.Write($"Starting GrandMaster Fight");
                Won(await Task.Run(() => Fight()));
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
    }
}
