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

namespace BecomeSifu.FightObjects
{
    public class BTournament : AllFightsAbstract
    {
        public CommandAbstract StartFighting => new RelayCommand(x => Begin());
        public BTournament()
        {
            PageHolder.MainWindow.State.FightsVMs[1].Wins = 0;
            PageHolder.MainWindow.State.FightsVMs[1].Health = ((decimal)PageHolder.MainWindow.State.FightsVMs[1].Wins + 1) * 10000;
            PageHolder.MainWindow.State.FightsVMs[1].Attack = ((decimal)PageHolder.MainWindow.State.FightsVMs[1].Wins + 1) * 1000;
            PageHolder.MainWindow.State.FightsVMs[1].HealthString = PageHolder.MainWindow.State.FightsVMs[1].Health.ConvertToString();
            PageHolder.MainWindow.State.FightsVMs[1].AttackString = PageHolder.MainWindow.State.FightsVMs[1].Attack.ConvertToString();
            PageHolder.MainWindow.State.FightsVMs[1].FightName = "Tournament Bout";
            PageHolder.MainWindow.State.FightsVMs[1].Background = new SolidColorBrush(Colors.LightSteelBlue);
        }
        public void Won(int win)
        {
            try
            {
                PageHolder.MainWindow.State.FightsVMs[1].Wins += win;
                LogIt.Write($"Finalizing Results: fight complete with {win} wins for a total of {PageHolder.MainWindow.State.FightsVMs[1].Wins} wins");
                PageHolder.MainWindow.State.FightsVMs[1].Health = ((decimal)PageHolder.MainWindow.State.FightsVMs[1].Wins + 1) * 10000;
                PageHolder.MainWindow.State.FightsVMs[1].Attack = ((decimal)PageHolder.MainWindow.State.FightsVMs[1].Wins + 1) * 1000;
                PageHolder.MainWindow.State.FightsVMs[1].HealthString = PageHolder.MainWindow.State.FightsVMs[1].Health.ConvertToString();
                PageHolder.MainWindow.State.FightsVMs[1].AttackString = PageHolder.MainWindow.State.FightsVMs[1].Attack.ConvertToString();
                LogIt.Write($"Reset Healt and attack for enemy.");
                if (PageHolder.MainWindow.State.FightsVMs[1].Wins >= 1 && PageHolder.MainWindow.State.FightsVMs[1].Wins < 1000)
                {
                    PageHolder.MainWindow.State.Dojo[0].AutoSpeedMultiplier = 1M - (.001M * PageHolder.MainWindow.State.FightsVMs[1].Wins);
                    PageHolder.MainWindow.State.Dojo.Refresh();
                }
                if (PageHolder.MainWindow.State.FightsVMs[1].Wins > 0 && PageHolder.MainWindow.State.FightsVMs[1].Wins % 5 == 0)
                {
                    PageHolder.MainWindow.State.FightsVMs[2].IsActive = true;
                    if (PageHolder.MainWindow.State.FightsVMs[1].Wins / 5 == 1)
                    {
                        if (PageHolder.MainWindow.State.Dojo[0].Perks[1].Active)
                        {
                            Extensions.CreateMessage("Championship Tae Kwon Do", true);
                        }
                        else
                        {
                            Extensions.CreateMessage("Championship", true);
                        }
                    }
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
                LogIt.Write($"Starting Tournament");
                Won(await Task.Run(() => Fight(PageHolder.MainWindow.State.FightsVMs[1].Health, PageHolder.MainWindow.State.FightsVMs[1].Attack)));
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
    }
}
