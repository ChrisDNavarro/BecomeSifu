using BecomeSifu.Logging;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using BecomeSifu.Abstracts;
using BecomeSifu.Controls;

namespace BecomeSifu.FightObjects
{
    public class DMaster : AllFightsAbstract
    {
        public CommandAbstract StartFighting => new RelayCommand(x => Begin());
        public DMaster()
        {
            PageHolder.MainWindow.State.FightsVMs[3].Wins = 0;
            PageHolder.MainWindow.State.FightsVMs[3].Health = ((decimal)PageHolder.MainWindow.State.FightsVMs[3].Wins + 1) * 1000000;
            PageHolder.MainWindow.State.FightsVMs[3].Attack = ((decimal)PageHolder.MainWindow.State.FightsVMs[3].Wins + 1) * 100000;
            PageHolder.MainWindow.State.FightsVMs[3].HealthString = PageHolder.MainWindow.State.FightsVMs[3].Health.ConvertToString();
            PageHolder.MainWindow.State.FightsVMs[3].AttackString = PageHolder.MainWindow.State.FightsVMs[3].Attack.ConvertToString();
            PageHolder.MainWindow.State.FightsVMs[3].FightName = "Master";
            PageHolder.MainWindow.State.FightsVMs[3].Background = new SolidColorBrush(Colors.LightSteelBlue);
        }
        public void Won(int win)
        {
            try
            {
                PageHolder.MainWindow.State.FightsVMs[3].Wins += win;
                LogIt.Write($"Finalizing Results: fight complete with {win} wins for a total of {PageHolder.MainWindow.State.FightsVMs[3].Wins} wins");
                PageHolder.MainWindow.State.FightsVMs[3].Health = ((decimal)PageHolder.MainWindow.State.FightsVMs[3].Wins + 1) * 1000000;
                PageHolder.MainWindow.State.FightsVMs[3].Attack = ((decimal)PageHolder.MainWindow.State.FightsVMs[3].Wins + 1) * 100000;
                PageHolder.MainWindow.State.FightsVMs[3].HealthString = PageHolder.MainWindow.State.FightsVMs[3].Health.ConvertToString();
                PageHolder.MainWindow.State.FightsVMs[3].AttackString = PageHolder.MainWindow.State.FightsVMs[3].Attack.ConvertToString();
                LogIt.Write($"Reset Healt and attack for enemy.");
                PageHolder.MainWindow.State.Dojo[0].ExpGainMultiplier += .1M;
                if (PageHolder.MainWindow.State.FightsVMs[3].Wins > 0 && PageHolder.MainWindow.State.FightsVMs[3].Wins % 5 == 0)
                {
                    PageHolder.MainWindow.State.FightsVMs[4].IsActive = true;
                    if (PageHolder.MainWindow.State.FightsVMs[3].Wins / 5 == 1)
                    {
                        Extensions.CreateMessage("GrandMaster", true);
                    }
                }
                if (PageHolder.MainWindow.State.FightsVMs[2].Wins / 5 > PageHolder.MainWindow.State.FightsVMs[3].Wins)
                {
                    PageHolder.MainWindow.State.FightsVMs[3].IsActive = false;
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
                LogIt.Write($"Starting Master Fight");
                Won(await Task.Run(() => Fight(PageHolder.MainWindow.State.FightsVMs[3].Health, PageHolder.MainWindow.State.FightsVMs[3].Attack)));
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
    }
}
