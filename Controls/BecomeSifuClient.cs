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

namespace BecomeSifu.Controls
{
    public class BecomeSifuClient
    {
        private ItemCollection Tabs;
        private ItemCollection PracticeTabs;
        private ItemCollection AdvancedTabs;
        private List<int> Bonuses = new List<int>();
        public BecomeSifuClient(List<int> bonuses)
        {
            try
            {
                Tabs = PageHolder.MainClient.ActionTabControl.Items;
                PracticeTabs = PageHolder.MainClient.PracticeTabControl.Items;
                AdvancedTabs = PageHolder.MainClient.AdvancedTabControl.Items;

                
                _ = new GenerateFights();
                LogIt.Write($"Generated Fights");
                _ = new GenerateContent();
                LogIt.Write($"Generated Content");
                _ = new GenerateTabs(Tabs);
                LogIt.Write($"Generated Tabs");
                _ = new GeneratePracticeTabs(PracticeTabs);
                LogIt.Write($"Generated Practice Tabs");
                _ = new GenerateAdvancedTabs(AdvancedTabs);
                LogIt.Write($"Generated Advanced Tabs");
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

                var gif = new BitmapImage();
                gif.BeginInit();
                gif.UriSource = new Uri("pack://application:,,,/Animations/Kicks.gif");
                gif.EndInit();
                ImageBehavior.SetAnimatedSource(PageHolder.MainClient.Aniamtion, gif);
                ImageBehavior.SetRepeatBehavior(PageHolder.MainClient.Aniamtion, RepeatBehavior.Forever);
                LogIt.Write($"Started Animation");
            }
            catch (Exception e)
            {
                LogIt.Write($"Error catch: {e}");
                throw;
            }
        }

        public void UpdateBonuses()
        {
            try
            {
                PageHolder.MainWindow.State.Cup[0].UpdateBonuses(Bonuses);
                PageHolder.MainWindow.State.Dojo[0].UpdateBonuses(Bonuses);
            }
            catch (Exception e)
            {
                LogIt.Write($"Error catch: {e}");
                throw;
            }
        }
    }
}
