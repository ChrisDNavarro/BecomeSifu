using BecomeSifu.MartialArts;
using BecomeSifu.Objects;
using BecomeSifu.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;
using BecomeSifu.Logging;
using System.Windows.Media.Animation;
using BecomeSifu.Pages;

namespace BecomeSifu.Controls
{
    public class BecomeSifuClient
    {
        private ItemCollection Tabs;
        private ItemCollection PracticeTabs;
        private ItemCollection AdvancedTabs;
        private static List<int> Bonuses = new List<int>();
        public BecomeSifuClient(List<int> bonuses, bool fromsaved)
        {
            try
            {
                Tabs = PageHolder.MainClient.ActionTabControl.Items;
                var x = (TabItem)PageHolder.MainClient.PracticeTabHolder.Items[0];
                var y = (TabControl)x.Content;
                PracticeTabs = y.Items;
                AdvancedTabs = PageHolder.MainClient.AdvancedTabControl.Items;

                if (!fromsaved)
                {
                    _ = new GenerateFights();
                    LogIt.Write($"Generated Fights");
                    _ = new GenerateContent();
                    LogIt.Write($"Generated Content");
                }

                
                _ = new GenerateTabs(Tabs);
                LogIt.Write($"Generated Tabs");
                _ = new GeneratePracticeTabs(PracticeTabs);
                LogIt.Write($"Generated Practice Tabs");
                _ = new GenerateAdvancedTabs(AdvancedTabs);
                LogIt.Write($"Generated Advanced Tabs");

                PageHolder.MainClient.BackgrounGif.Content = new PracticeGif();



                LogIt.Write($"Started Animation");

                Bonuses = bonuses;
            }
            catch (Exception e)
            {
                LogIt.Write($"Error catch: {e}");
                throw;
            }
        }

        public void StartingMessages()
        {
            try
            {
                Extensions.CreateMessage("You have chosen well", false);
                Extensions.CreateMessage("The Basics", false);
                Extensions.CreateMessage("Let us Begin", true);
            }
            catch (Exception e)
            {
                LogIt.Write($"Error catch: {e}");
                throw;
            }
        }

        public static void UpdateBonuses()
        {
            try
            {
                EmptyCupControl.UpdateBonuses(Bonuses);
                PageHolder.MainWindow.DojoState.Dojo[0].UpdateBonuses(Bonuses);
            }
            catch (Exception e)
            {
                LogIt.Write($"Error catch: {e}");
                throw;
            }
        }
    }
}
