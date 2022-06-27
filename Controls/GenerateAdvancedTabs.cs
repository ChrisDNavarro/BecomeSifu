using BecomeSifu.Logging;
using BecomeSifu.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BecomeSifu.Controls
{
    class GenerateAdvancedTabs
    {
        public GenerateAdvancedTabs(ItemCollection advancedTabs)
        {
            try
            {
                advancedTabs.Add(BoostsTab(new TabItem()));
                LogIt.Write($"Added Boosts Tab");
                advancedTabs.Add(DebugTab(new TabItem()));
                advancedTabs.Add(OptionsTab(new TabItem()));
                LogIt.Write($"Added Options Tab");
            }
            catch (Exception e)
            {
                LogIt.Write($"Error catch: {e}");
                throw;
            }
        }

        private TabItem BoostsTab(TabItem tab)
        {
            try
            {
                TextBlock tbk = new TextBlock() { Text = "Boosts", Foreground = new SolidColorBrush(Colors.AliceBlue), FontWeight = FontWeights.Bold };
                tab.Header = tbk;
                tab.Content = new Boosts();
                return tab;
            }
            catch (Exception e)
            {
                LogIt.Write($"Error catch: {e}");
                throw;
            }
        }
        private TabItem DebugTab(TabItem tab)
        {
            try
            {
                TextBlock tbk = new TextBlock() { Text = "Debug", Foreground = new SolidColorBrush(Colors.AliceBlue), FontWeight = FontWeights.Bold };
                tab.Header = tbk;
                tab.Content = new Debug();
                return tab;
            }
            catch (Exception e)
            {
                LogIt.Write($"Error catch: {e}");
                throw;
            }
        }

        private TabItem OptionsTab(TabItem tab)
        {
            try
            {
                TextBlock tbk = new TextBlock() { Text = "Options", Foreground = new SolidColorBrush(Colors.AliceBlue), FontWeight = FontWeights.Bold };
                tab.Header = tbk;
                tab.Content = new Options();
                return tab;
            }
            catch (Exception e)
            {
                LogIt.Write($"Error catch: {e}");
                throw;
            }
        }


    }
}
