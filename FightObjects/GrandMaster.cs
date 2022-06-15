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
            PageHolder.MainWindow.State.FightsVMs[4].Wins = 0;
            PageHolder.MainWindow.State.FightsVMs[4].Health = ((decimal)PageHolder.MainWindow.State.FightsVMs[4].Wins + 1) * 10000000;
            PageHolder.MainWindow.State.FightsVMs[4].Attack = ((decimal)PageHolder.MainWindow.State.FightsVMs[4].Wins + 1) * 1000000;
            PageHolder.MainWindow.State.FightsVMs[4].HealthString = PageHolder.MainWindow.State.FightsVMs[4].Health.ConvertToString();
            PageHolder.MainWindow.State.FightsVMs[4].AttackString = PageHolder.MainWindow.State.FightsVMs[4].Attack.ConvertToString();
            PageHolder.MainWindow.State.FightsVMs[4].FightName = this.GetType().Name;
            PageHolder.MainWindow.State.FightsVMs[4].Background = new SolidColorBrush(Colors.Silver);
        }
        public void Won(int win)
        {
            try
            {
                PageHolder.MainWindow.State.FightsVMs[4].Wins += win;
                LogIt.Write($"Finalizing Results: fight complete with {win} wins for a total of {PageHolder.MainWindow.State.FightsVMs[4].Wins} wins");
                PageHolder.MainWindow.State.FightsVMs[4].Health = ((decimal)PageHolder.MainWindow.State.FightsVMs[4].Wins + 1) * 10000000;
                PageHolder.MainWindow.State.FightsVMs[4].Attack = ((decimal)PageHolder.MainWindow.State.FightsVMs[4].Wins + 1) * 1000000;
                PageHolder.MainWindow.State.FightsVMs[4].HealthString = PageHolder.MainWindow.State.FightsVMs[4].Health.ConvertToString();
                PageHolder.MainWindow.State.FightsVMs[4].AttackString = PageHolder.MainWindow.State.FightsVMs[4].Attack.ConvertToString();
                LogIt.Write($"Reset Healt and attack for enemy.");
                if(win == 1)
                {
                    EmptyCupControl.DefeatedGrandMaster = true;
                }

                if (PageHolder.MainWindow.State.FightsVMs[3].Wins / 5 > PageHolder.MainWindow.State.FightsVMs[4].Wins)
                {
                    PageHolder.MainWindow.State.FightsVMs[4].IsActive = false;
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
                LogIt.Write($"Starting GrandMaster Fight");
                Won(await Task.Run(() => Fight(PageHolder.MainWindow.State.FightsVMs[4].Health, PageHolder.MainWindow.State.FightsVMs[4].Attack)));
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
    }
}
