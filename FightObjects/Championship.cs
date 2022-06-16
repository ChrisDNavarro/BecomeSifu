using BecomeSifu.Logging;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using BecomeSifu.Controls;
using BecomeSifu.Abstracts;

namespace BecomeSifu.FightObjects
{
    public class Championship : AllFightsAbstract
    {
        public CommandAbstract StartFighting => new RelayCommand(x => Begin());
        public Championship()
        {
            PageHolder.MainWindow.DojoState.FightsVMs[2].Wins = 0;
            PageHolder.MainWindow.DojoState.FightsVMs[2].Health = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[2].Wins + 1) * 100000;
            PageHolder.MainWindow.DojoState.FightsVMs[2].Attack = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[2].Wins + 1) * 10000;
            PageHolder.MainWindow.DojoState.FightsVMs[2].HealthString = PageHolder.MainWindow.DojoState.FightsVMs[2].Health.ConvertToString();
            PageHolder.MainWindow.DojoState.FightsVMs[2].AttackString = PageHolder.MainWindow.DojoState.FightsVMs[2].Attack.ConvertToString();
            PageHolder.MainWindow.DojoState.FightsVMs[2].FightName = this.GetType().Name;
            PageHolder.MainWindow.DojoState.FightsVMs[2].BackgroundColor = Colors.Silver;
        }
        public static void Won(int win)
        {
            try
            {
                PageHolder.MainWindow.DojoState.FightsVMs[2].Wins += win;
                LogIt.Write($"Finalizing Results: fight complete with {win} wins for a total of {PageHolder.MainWindow.DojoState.FightsVMs[2].Wins} wins");
                PageHolder.MainWindow.DojoState.FightsVMs[2].Health = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[2].Wins + 1) * 100000;
                PageHolder.MainWindow.DojoState.FightsVMs[2].Attack = ((decimal)PageHolder.MainWindow.DojoState.FightsVMs[2].Wins + 1) * 10000;
                PageHolder.MainWindow.DojoState.FightsVMs[2].HealthString = PageHolder.MainWindow.DojoState.FightsVMs[2].Health.ConvertToString();
                PageHolder.MainWindow.DojoState.FightsVMs[2].AttackString = PageHolder.MainWindow.DojoState.FightsVMs[2].Attack.ConvertToString();
                LogIt.Write($"Reset Healt and attack for enemy.");
                if (PageHolder.MainWindow.DojoState.FightsVMs[2].Wins == 1)
                {
                    PageHolder.MainWindow.DojoState.Cup[0].ButtonActive = true;
                    PageHolder.MainWindow.DojoState.Cup[0].ButtonName = "Empty Your Cup";
                    PageHolder.MainWindow.DojoState.Cup[0].ImageSource = @"pack://application:,,,/Resources/CupIsFull.png";
                }
                if (PageHolder.MainWindow.DojoState.FightsVMs[2].Wins > 0 && PageHolder.MainWindow.DojoState.FightsVMs[2].Wins % 5 == 0)
                {
                    if (!PageHolder.MainWindow.DojoState.Dojo[0].Perks[1].Active && ((PageHolder.MainWindow.DojoState.FightsVMs[2].Wins / 5) - 1) < PageHolder.MainWindow.DojoState.Specials.Count)
                    {
                        PageHolder.MainWindow.DojoState.Specials[(PageHolder.MainWindow.DojoState.FightsVMs[2].Wins / 5) - 1].Enabled = true;
                        
                        Extensions.CreateMessage("Specials", true);
                    }
                    PageHolder.MainWindow.DojoState.FightsVMs[3].IsActive = true;
                    if (PageHolder.MainWindow.DojoState.FightsVMs[2].Wins / 5 == 1)
                    {
                        Extensions.CreateMessage("Master", true);
                    }
                }
                if (PageHolder.MainWindow.DojoState.FightsVMs[1].Wins / 5 > PageHolder.MainWindow.DojoState.FightsVMs[2].Wins)
                {
                    PageHolder.MainWindow.DojoState.FightsVMs[2].IsActive = false;
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
                LogIt.Write($"Starting Championship");
                Won(await Task.Run(() => Fight(PageHolder.MainWindow.DojoState.FightsVMs[2].Health, PageHolder.MainWindow.DojoState.FightsVMs[2].Attack)));
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
    }
}
