using BecomeSifu.Logging;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

using BecomeSifu.Controls;
using BecomeSifu.Abstracts;
using System.Windows.Media.Animation;

namespace BecomeSifu.FightObjects
{
    public class BTournament : AllFightsAbstract
    {
        public CommandAbstract StartFighting => new RelayCommand(x => Begin());
        public BTournament()
        {
            PageHolder.MainWindow.DojoState.FightsVMs[1].Wins = 0;
            PageHolder.MainWindow.DojoState.FightsVMs[1].Health = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[1].Wins + 1) * 10000;
            PageHolder.MainWindow.DojoState.FightsVMs[1].Attack = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[1].Wins + 1) * 1000;
            PageHolder.MainWindow.DojoState.FightsVMs[1].HealthString = PageHolder.MainWindow.DojoState.FightsVMs[1].Health.ConvertToString();
            PageHolder.MainWindow.DojoState.FightsVMs[1].AttackString = PageHolder.MainWindow.DojoState.FightsVMs[1].Attack.ConvertToString();
            PageHolder.MainWindow.DojoState.FightsVMs[1].FightName = "Tournament Bout";
            PageHolder.MainWindow.DojoState.FightsVMs[1].BackgroundColor = Colors.LightSteelBlue;
            PageHolder.MainWindow.DojoState.FightsVMs[1].ForegroundColor = Colors.Green;
        }
        public static void Won(int win)
        {
            try
            {
                if (PageHolder.MainWindow.DojoState.FightsVMs[1].Fought)
                {
                    PageHolder.MainWindow.DojoState.FightsVMs[1].Wins += win;
                    LogIt.Write($"Finalizing Results: fight complete with {win} wins for a total of {PageHolder.MainWindow.DojoState.FightsVMs[1].Wins} wins");
                    PageHolder.MainWindow.DojoState.FightsVMs[1].Health = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[1].Wins + 1) * 10000;
                    PageHolder.MainWindow.DojoState.FightsVMs[1].Attack = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[1].Wins + 1) * 1000;
                    PageHolder.MainWindow.DojoState.FightsVMs[1].HealthString = PageHolder.MainWindow.DojoState.FightsVMs[1].Health.ConvertToString();
                    PageHolder.MainWindow.DojoState.FightsVMs[1].AttackString = PageHolder.MainWindow.DojoState.FightsVMs[1].Attack.ConvertToString();
                    LogIt.Write($"Reset Healt and attack for enemy.");

                    if (win == 1)
                    {
                        PageHolder.MainWindow.DojoState.FightsVMs[1].Gif = $"tournamentwin.gif";
                        PageHolder.MainWindow.DojoState.FightsVMs[1].Fighting = new RepeatBehavior(1);
                        PageHolder.MainWindow.DojoState.FightsVMs[1].Fought = false;
                    }
                    else
                    {
                        PageHolder.MainWindow.DojoState.FightsVMs[1].Gif = $"tournamentlose.gif";
                        PageHolder.MainWindow.DojoState.FightsVMs[1].Fighting = new RepeatBehavior(1);
                        PageHolder.MainWindow.DojoState.FightsVMs[1].Fought = false;
                    }

                    if (PageHolder.MainWindow.DojoState.FightsVMs[1].Wins >= 1 && PageHolder.MainWindow.DojoState.FightsVMs[1].Wins < 1000)
                    {
                        PageHolder.MainWindow.DojoState.Dojo[0].AutoSpeedMultiplier = 1M - (.001M * PageHolder.MainWindow.DojoState.FightsVMs[1].Wins);

                    }

                    if (PageHolder.MainWindow.DojoState.FightsVMs[1].Wins > 0 && PageHolder.MainWindow.DojoState.FightsVMs[1].Wins % 5 == 0)
                    {
                        PageHolder.MainWindow.DojoState.FightsVMs[2].IsActive = true;
                        if (PageHolder.MainWindow.DojoState.FightsVMs[1].Wins / 5 == 1)
                        {
                            if (PageHolder.MainWindow.DojoState.Dojo[0].Perks[1].Active)
                            {
                                Extensions.CreateMessage("Championship Tae Kwon Do", true);
                            }
                            else
                            {
                                Extensions.CreateMessage("Championship", true);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        public static async void Begin()
        {
            try
            {
                bool first = Convert.ToBoolean(RNG.Next(0, 2));
                LogIt.Write($"--------------FIGHT----------------");
                LogIt.Write($"Starting Tournament");
                Won(await Task.Run(() => Fight(PageHolder.MainWindow.DojoState.FightsVMs[1].Health, PageHolder.MainWindow.DojoState.FightsVMs[1].Attack)));
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
    }
}
