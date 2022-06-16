using BecomeSifu.Abstracts;
using BecomeSifu.Controls;
using BecomeSifu.Logging;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BecomeSifu.FightObjects
{
    public class GrandMaster : AllFightsAbstract
    {
        public CommandAbstract StartFighting => new RelayCommand(x => Begin());
        public GrandMaster()
        {
            PageHolder.MainWindow.DojoState.FightsVMs[4].Wins = 0;
            PageHolder.MainWindow.DojoState.FightsVMs[4].Health = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[4].Wins + 1) * 10000000;
            PageHolder.MainWindow.DojoState.FightsVMs[4].Attack = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[4].Wins + 1) * 1000000;
            PageHolder.MainWindow.DojoState.FightsVMs[4].HealthString = PageHolder.MainWindow.DojoState.FightsVMs[4].Health.ConvertToString();
            PageHolder.MainWindow.DojoState.FightsVMs[4].AttackString = PageHolder.MainWindow.DojoState.FightsVMs[4].Attack.ConvertToString();
            PageHolder.MainWindow.DojoState.FightsVMs[4].FightName = this.GetType().Name;
            PageHolder.MainWindow.DojoState.FightsVMs[4].BackgroundColor = Colors.Silver;
        }
        public static void Won(int win)
        {
            try
            {
                PageHolder.MainWindow.DojoState.FightsVMs[4].Wins += win;
                LogIt.Write($"Finalizing Results: fight complete with {win} wins for a total of {PageHolder.MainWindow.DojoState.FightsVMs[4].Wins} wins");
                PageHolder.MainWindow.DojoState.FightsVMs[4].Health = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[4].Wins + 1) * 10000000;
                PageHolder.MainWindow.DojoState.FightsVMs[4].Attack = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[4].Wins + 1) * 1000000;
                PageHolder.MainWindow.DojoState.FightsVMs[4].HealthString = PageHolder.MainWindow.DojoState.FightsVMs[4].Health.ConvertToString();
                PageHolder.MainWindow.DojoState.FightsVMs[4].AttackString = PageHolder.MainWindow.DojoState.FightsVMs[4].Attack.ConvertToString();
                LogIt.Write($"Reset Healt and attack for enemy.");
                if(win == 1)
                {
                    EmptyCupControl.DefeatedGrandMaster = true;
                }

                if (PageHolder.MainWindow.DojoState.FightsVMs[3].Wins / 5 > PageHolder.MainWindow.DojoState.FightsVMs[4].Wins)
                {
                    PageHolder.MainWindow.DojoState.FightsVMs[4].IsActive = false;
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
                LogIt.Write($"Starting GrandMaster Fight");
                Won(await Task.Run(() => Fight(PageHolder.MainWindow.DojoState.FightsVMs[4].Health, PageHolder.MainWindow.DojoState.FightsVMs[4].Attack)));
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
    }
}
