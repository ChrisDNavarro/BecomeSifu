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
        private ItemCollection GifTab;
        private static List<int> Bonuses = new List<int>();
        public BecomeSifuClient(List<int> bonuses, bool fromsaved)
        {
            try
            {
                TabItem ATH = (TabItem)PageHolder.MainClient.ActionTabHolder.Items[0];
                TabControl AT = (TabControl)ATH.Content;
                Tabs = AT.Items;
                TabItem PTH = (TabItem)PageHolder.MainClient.PracticeTabHolder.Items[0];
                TabControl PT = (TabControl)PTH.Content;
                PracticeTabs = PT.Items;
                TabItem AdTH = (TabItem)PageHolder.MainClient.AdvancedTabHolder.Items[0];
                TabControl AdT = (TabControl)AdTH.Content;
                AdvancedTabs = AdT.Items;
                GifTab = PageHolder.MainClient.BackgrounGif.Items;

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

                var x = new TabItem();
                x.Content = new PracticeGif();
                GifTab.Add(x);
                LogIt.Write($"Started Animation");

                string[] schools = { "taekwondo", "boxing", "karate" };
                switch (schools.FirstOrDefault(s => PageHolder.MainWindow.DojoState.Dojo[0].ToString().ToLower().Contains(s)))
                {
                    case "taekwondo":
                        PageHolder.MainClient.TKDTrigrams.Visibility = Visibility.Visible;
                        break;
                    case "boxing":
                        PageHolder.MainClient.KarateLogo.Visibility = Visibility.Visible;
                        break;
                    case "karate":
                        PageHolder.MainClient.BoxingRing.Visibility = Visibility.Visible;
                        break;
                    default:
                        break;
                }

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
