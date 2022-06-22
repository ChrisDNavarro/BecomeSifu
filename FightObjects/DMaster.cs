using BecomeSifu.Logging;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using BecomeSifu.Abstracts;
using BecomeSifu.Controls;
using System.Windows.Media.Animation;

namespace BecomeSifu.FightObjects
{
    public class DMaster : AllFightsAbstract
    {
        public CommandAbstract StartFighting => new RelayCommand(x => Begin());
        public DMaster()
        {
            PageHolder.MainWindow.DojoState.FightsVMs[3].Wins = 0;
            PageHolder.MainWindow.DojoState.FightsVMs[3].Health = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[3].Wins + 1) * 1000000;
            PageHolder.MainWindow.DojoState.FightsVMs[3].Attack = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[3].Wins + 1) * 100000;
            PageHolder.MainWindow.DojoState.FightsVMs[3].HealthString = PageHolder.MainWindow.DojoState.FightsVMs[3].Health.ConvertToString();
            PageHolder.MainWindow.DojoState.FightsVMs[3].AttackString = PageHolder.MainWindow.DojoState.FightsVMs[3].Attack.ConvertToString();
            PageHolder.MainWindow.DojoState.FightsVMs[3].FightName = "Master";
            PageHolder.MainWindow.DojoState.FightsVMs[3].BackgroundColor = Colors.LightSteelBlue;
            PageHolder.MainWindow.DojoState.FightsVMs[3].ForegroundColor = Colors.Purple;
        }
        public static void Won(int win)
        {
            try
            {
                if (PageHolder.MainWindow.DojoState.FightsVMs[3].Fought)
                {
                    PageHolder.MainWindow.DojoState.FightsVMs[3].Wins += win;
                    LogIt.Write($"Finalizing Results: fight complete with {win} wins for a total of {PageHolder.MainWindow.DojoState.FightsVMs[3].Wins} wins");
                    PageHolder.MainWindow.DojoState.FightsVMs[3].Health = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[3].Wins + 1) * 1000000;
                    PageHolder.MainWindow.DojoState.FightsVMs[3].Attack = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[3].Wins + 1) * 100000;
                    PageHolder.MainWindow.DojoState.FightsVMs[3].HealthString = PageHolder.MainWindow.DojoState.FightsVMs[3].Health.ConvertToString();
                    PageHolder.MainWindow.DojoState.FightsVMs[3].AttackString = PageHolder.MainWindow.DojoState.FightsVMs[3].Attack.ConvertToString();
                    LogIt.Write($"Reset Healt and attack for enemy.");
                    if (win == 1)
                    {
                        PageHolder.MainWindow.DojoState.FightsVMs[3].Gif = $"masterwin.gif";
                        PageHolder.MainWindow.DojoState.FightsVMs[3].Fighting = new RepeatBehavior(1);
                        PageHolder.MainWindow.DojoState.FightsVMs[3].Fought = false;
                        PageHolder.MainWindow.DojoState.Dojo[0].ExpGainMultiplier += .1M;
                    }
                    else
                    {
                        PageHolder.MainWindow.DojoState.FightsVMs[3].Gif = $"masterwin.gif";
                        PageHolder.MainWindow.DojoState.FightsVMs[3].Fighting = new RepeatBehavior(1);
                        PageHolder.MainWindow.DojoState.FightsVMs[3].Fought = false;
                    }

                    if (PageHolder.MainWindow.DojoState.FightsVMs[3].Wins > 0 && PageHolder.MainWindow.DojoState.FightsVMs[3].Wins % 5 == 0)
                    {
                        PageHolder.MainWindow.DojoState.FightsVMs[4].IsActive = true;
                        if (PageHolder.MainWindow.DojoState.FightsVMs[3].Wins / 5 == 1)
                        {
                            Extensions.CreateMessage("GrandMaster", true);
                        }
                    }

                    if (PageHolder.MainWindow.DojoState.FightsVMs[2].Wins / 5 > PageHolder.MainWindow.DojoState.FightsVMs[3].Wins)
                    {
                        PageHolder.MainWindow.DojoState.FightsVMs[3].IsActive = false;
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
                LogIt.Write($"Starting Master Fight");
                Won(await Task.Run(() => Fight(PageHolder.MainWindow.DojoState.FightsVMs[3].Health, PageHolder.MainWindow.DojoState.FightsVMs[3].Attack)));
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
    }
}
