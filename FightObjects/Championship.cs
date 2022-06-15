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
            PageHolder.MainWindow.State.FightsVMs[2].Wins = 0;
            PageHolder.MainWindow.State.FightsVMs[2].Health = ((decimal)PageHolder.MainWindow.State.FightsVMs[2].Wins + 1) * 100000;
            PageHolder.MainWindow.State.FightsVMs[2].Attack = ((decimal)PageHolder.MainWindow.State.FightsVMs[2].Wins + 1) * 10000;
            PageHolder.MainWindow.State.FightsVMs[2].HealthString = PageHolder.MainWindow.State.FightsVMs[2].Health.ConvertToString();
            PageHolder.MainWindow.State.FightsVMs[2].AttackString = PageHolder.MainWindow.State.FightsVMs[2].Attack.ConvertToString();
            PageHolder.MainWindow.State.FightsVMs[2].FightName = this.GetType().Name;
            PageHolder.MainWindow.State.FightsVMs[2].Background = new SolidColorBrush(Colors.Silver);
        }
        public void Won(int win)
        {
            try
            {
                PageHolder.MainWindow.State.FightsVMs[2].Wins += win;
                LogIt.Write($"Finalizing Results: fight complete with {win} wins for a total of {PageHolder.MainWindow.State.FightsVMs[2].Wins} wins");
                PageHolder.MainWindow.State.FightsVMs[2].Health = ((decimal)PageHolder.MainWindow.State.FightsVMs[2].Wins + 1) * 100000;
                PageHolder.MainWindow.State.FightsVMs[2].Attack = ((decimal)PageHolder.MainWindow.State.FightsVMs[2].Wins + 1) * 10000;
                PageHolder.MainWindow.State.FightsVMs[2].HealthString = PageHolder.MainWindow.State.FightsVMs[2].Health.ConvertToString();
                PageHolder.MainWindow.State.FightsVMs[2].AttackString = PageHolder.MainWindow.State.FightsVMs[2].Attack.ConvertToString();
                LogIt.Write($"Reset Healt and attack for enemy.");
                if (PageHolder.MainWindow.State.FightsVMs[2].Wins == 1)
                {
                    PageHolder.MainWindow.State.Cup[0].ButtonActive = true;
                    PageHolder.MainWindow.State.Cup[0].ButtonName = "Empty Your Cup";
                    PageHolder.MainWindow.State.Cup[0].Imagesource = new BitmapImage(new Uri(@"pack://application:,,,/Resources/CupIsFull.png"));
                }
                if (PageHolder.MainWindow.State.FightsVMs[2].Wins > 0 && PageHolder.MainWindow.State.FightsVMs[2].Wins % 5 == 0)
                {
                    if (!PageHolder.MainWindow.State.Dojo[0].Perks[1].Active && ((PageHolder.MainWindow.State.FightsVMs[2].Wins / 5) - 1) < PageHolder.MainWindow.State.Specials.Count)
                    {
                        PageHolder.MainWindow.State.Specials[(PageHolder.MainWindow.State.FightsVMs[2].Wins / 5) - 1].Enabled = true;
                        PageHolder.MainWindow.State.Specials.Refresh();
                        Extensions.CreateMessage("Specials", true);
                    }
                    PageHolder.MainWindow.State.FightsVMs[3].IsActive = true;
                    if (PageHolder.MainWindow.State.FightsVMs[2].Wins / 5 == 1)
                    {
                        Extensions.CreateMessage("Master", true);
                    }
                }
                if (PageHolder.MainWindow.State.FightsVMs[1].Wins / 5 > PageHolder.MainWindow.State.FightsVMs[2].Wins)
                {
                    PageHolder.MainWindow.State.FightsVMs[2].IsActive = false;
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
                LogIt.Write($"Starting Championship");
                Won(await Task.Run(() => Fight(PageHolder.MainWindow.State.FightsVMs[2].Health, PageHolder.MainWindow.State.FightsVMs[2].Attack)));
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
    }
}
