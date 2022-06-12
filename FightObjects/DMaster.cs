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
    public class DMaster : AllFights , IFights
    {
        public ICommand StartFighting => new RelayCommand(() => Begin());
        public DMaster()
        {
            Wins = 0;
            Health = ((decimal)Wins + 1) * 1000000;
            Attack = ((decimal)Wins + 1) * 100000;
            HealthString = Health.ConvertToString();
            AttackString = Attack.ConvertToString();
            FightName = "Master";
            Background = new SolidColorBrush(Colors.LightSteelBlue);
        }
        public void Won(int win)
        {
            try
            {
                Wins += win;
                LogIt.Write($"Finalizing Results: fight complete with {win} wins for a total of {Wins} wins");
                Health = ((decimal)Wins + 1) * 1000000;
                Attack = ((decimal)Wins + 1) * 100000;
                HealthString = Health.ConvertToString();
                AttackString = Attack.ConvertToString();
                LogIt.Write($"Reset Healt and attack for enemy.");
                Dojos.Dojo[0].ExpGainMultiplier += .1M;
                if (Wins > 0 && Wins % 5 == 0)
                {
                    Dojos.Fights[4].IsActive = true;
                    if (Wins / 5 == 1)
                    {
                        Extensions.CreateMessage("GrandMaster", true);
                    }
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
                LogIt.Write($"Starting Master Fight");
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
