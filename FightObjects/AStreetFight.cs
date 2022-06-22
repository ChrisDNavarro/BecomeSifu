using BecomeSifu.Logging;
using BecomeSifu.Objects;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using BecomeSifu.Controls;
using BecomeSifu.Abstracts;
using System.Windows.Media.Animation;

namespace BecomeSifu.FightObjects
{
    public class AStreetFight : AllFightsAbstract
    {
        public CommandAbstract StartFighting => new RelayCommand(x => Begin());

        public AStreetFight()
        {

            PageHolder.MainWindow.DojoState.FightsVMs[0].Wins = 0;
            PageHolder.MainWindow.DojoState.FightsVMs[0].Health = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[0].Wins + 1) * 1000;
            PageHolder.MainWindow.DojoState.FightsVMs[0].Attack = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[0].Wins + 1) * 100;
            PageHolder.MainWindow.DojoState.FightsVMs[0].HealthString = PageHolder.MainWindow.DojoState.FightsVMs[0].Health.ConvertToString();
            PageHolder.MainWindow.DojoState.FightsVMs[0].AttackString = PageHolder.MainWindow.DojoState.FightsVMs[0].Attack.ConvertToString();
            PageHolder.MainWindow.DojoState.FightsVMs[0].FightName = "Street Fight";
            PageHolder.MainWindow.DojoState.FightsVMs[0].BackgroundColor = Colors.Silver;
            PageHolder.MainWindow.DojoState.FightsVMs[0].ForegroundColor = Colors.Silver;
        }

        public static void Won(int win)
        {
            try
            {
                if (PageHolder.MainWindow.DojoState.FightsVMs[0].Fought)
                {
                    PageHolder.MainWindow.DojoState.FightsVMs[0].Wins += win;
                    LogIt.Write($"Finalizing Results: fight complete with {win} wins for a total of {PageHolder.MainWindow.DojoState.FightsVMs[1].Wins} wins");
                    PageHolder.MainWindow.DojoState.FightsVMs[0].Health = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[0].Wins + 1) * 1000;
                    PageHolder.MainWindow.DojoState.FightsVMs[0].Attack = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[0].Wins + 1) * 100;
                    PageHolder.MainWindow.DojoState.FightsVMs[0].HealthString = PageHolder.MainWindow.DojoState.FightsVMs[0].Health.ConvertToString();
                    PageHolder.MainWindow.DojoState.FightsVMs[0].AttackString = PageHolder.MainWindow.DojoState.FightsVMs[0].Attack.ConvertToString();
                    LogIt.Write($"Reset Healt and attack for enemy.");
                    if (win == 1)
                    {
                        PageHolder.MainWindow.DojoState.FightsVMs[0].Gif = $"streetfightwin.gif";
                        PageHolder.MainWindow.DojoState.FightsVMs[0].Fighting = new RepeatBehavior(1);
                        PageHolder.MainWindow.DojoState.FightsVMs[0].Fought = false;
                        PageHolder.MainWindow.DojoState.Dojo[0].EnergyGainMultiplier += .01M;
                    }
                    else
                    {
                        PageHolder.MainWindow.DojoState.FightsVMs[0].Gif = $"streetfightlose.gif";
                        PageHolder.MainWindow.DojoState.FightsVMs[0].Fighting = new RepeatBehavior(1);
                        PageHolder.MainWindow.DojoState.FightsVMs[0].Fought = false;
                    }
                    if (PageHolder.MainWindow.DojoState.FightsVMs[0].Wins == 5)
                    {
                        PageHolder.MainWindow.DojoState.Practice[0].CanAutoMeditate = Visibility.Visible;

                    }
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
        public static new async void Begin()
        {
            try
            {
                bool first = Convert.ToBoolean(RNG.Next(0, 2));
                LogIt.Write($"--------------FIGHT----------------");
                LogIt.Write($"Starting Street Fight");
                Won(await Task.Run(() => Fight(PageHolder.MainWindow.DojoState.FightsVMs[0].Health, PageHolder.MainWindow.DojoState.FightsVMs[0].Attack)));
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
    }
}
