using BecomeSifu.Logging;
using BecomeSifu.Objects;
using BecomeSifu.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfAnimatedGif;

namespace BecomeSifu.Controls
{
    public class GeneratePracticeTabs
    {
        public GeneratePracticeTabs(ItemCollection practicetabs)
        {
            try
            {
                practicetabs.Add(PracticeTab(new TabItem()));
                LogIt.Write($"Populated Practice tab");
                practicetabs.Add(MeditationTab(new TabItem()));
                LogIt.Write($"Populated Meditation tab");
                practicetabs.Add(EmptyCupTab(new TabItem()));
                LogIt.Write($"Populated Cup of Knowledge tab");
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        private TabItem PracticeTab(TabItem tab)
        {
            try
            {
                TextBlock tbk = new TextBlock() { Text = "Practice", Foreground = new SolidColorBrush(Colors.AliceBlue), FontWeight = FontWeights.Bold };
                tab.Header = tbk;
                tab.Content = new Practice();
                return tab;
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        private TabItem MeditationTab(TabItem tab)
        {
            try
            {
                TextBlock tbk = new TextBlock() { Text = "Meditate", Foreground = new SolidColorBrush(Colors.AliceBlue), FontWeight = FontWeights.Bold };
                tab.Header = tbk;
                tab.Content = new Meditate();
                return tab;
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
        private TabItem EmptyCupTab(TabItem tab)
        {
            try
            {
                TextBlock tbk = new TextBlock() { Text = "Cup Of Knowledge", Foreground = new SolidColorBrush(Colors.AliceBlue), FontWeight = FontWeights.Bold };
                tab.Header = tbk;
                tab.Content = new EmptyCup();
                return tab;
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

    }
}
