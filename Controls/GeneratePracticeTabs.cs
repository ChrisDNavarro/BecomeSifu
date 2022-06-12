using BecomeSifu.Logging;
using BecomeSifu.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

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
                tab.Header = "Pratice";
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
                tab.Header = "Meditation";
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
                tab.Header = "Cup Of Knowledge";
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
