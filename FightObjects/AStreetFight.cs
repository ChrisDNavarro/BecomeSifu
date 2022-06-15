using BecomeSifu.Logging;
using BecomeSifu.Objects;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using BecomeSifu.Controls;
using BecomeSifu.Abstracts;

namespace BecomeSifu.FightObjects
{
    public class AStreetFight : AllFightsAbstract
    {
        public CommandAbstract StartFighting => new RelayCommand(x => Begin());

        public AStreetFight()
        {

            PageHolder.MainWindow.State.FightsVMs[0].Wins = 0;
            PageHolder.MainWindow.State.FightsVMs[0].Health = ((decimal)PageHolder.MainWindow.State.FightsVMs[0].Wins + 1) * 1000;
            PageHolder.MainWindow.State.FightsVMs[0].Attack = ((decimal)PageHolder.MainWindow.State.FightsVMs[0].Wins + 1) * 100;
            PageHolder.MainWindow.State.FightsVMs[0].HealthString = PageHolder.MainWindow.State.FightsVMs[0].Health.ConvertToString();
            PageHolder.MainWindow.State.FightsVMs[0].AttackString = PageHolder.MainWindow.State.FightsVMs[0].Attack.ConvertToString();
            PageHolder.MainWindow.State.FightsVMs[0].FightName = "Street Fight";
            PageHolder.MainWindow.State.FightsVMs[0].Background = new SolidColorBrush(Colors.Silver);
        }

        public void Won(int win)
        {
            try
            {
                PageHolder.MainWindow.State.FightsVMs[0].Wins += win;
                LogIt.Write($"Finalizing Results: fight complete with {win} wins for a total of {PageHolder.MainWindow.State.FightsVMs[1].Wins} wins");
                PageHolder.MainWindow.State.FightsVMs[0].Health = ((decimal)PageHolder.MainWindow.State.FightsVMs[0].Wins + 1) * 1000;
                PageHolder.MainWindow.State.FightsVMs[0].Attack = ((decimal)PageHolder.MainWindow.State.FightsVMs[0].Wins + 1) * 100;
                PageHolder.MainWindow.State.FightsVMs[0].HealthString = PageHolder.MainWindow.State.FightsVMs[0].Health.ConvertToString();
                PageHolder.MainWindow.State.FightsVMs[0].AttackString = PageHolder.MainWindow.State.FightsVMs[0].Attack.ConvertToString();
                LogIt.Write($"Reset Healt and attack for enemy.");
                if (win == 1)
                {
                    PageHolder.MainWindow.State.Dojo[0].EnergyGainMultiplier += .01M;
                }
                if (PageHolder.MainWindow.State.FightsVMs[0].Wins == 5)
                {
                    PageHolder.MainWindow.State.Dojo[0].CanAutoMeditate = Visibility.Visible;
                    PageHolder.MainWindow.State.Dojo.Refresh();
                }


                PageHolder.MainWindow.State.Fights.Refresh();
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
        public override async void Begin()
        {
            try
            {
                bool first = Convert.ToBoolean(RNG.Next(0, 2));
                LogIt.Write($"--------------FIGHT----------------");
                LogIt.Write($"Starting Street Fight");
                Won(await Task.Run(() => Fight(PageHolder.MainWindow.State.FightsVMs[0].Health, PageHolder.MainWindow.State.FightsVMs[0].Attack)));
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
    }
}
