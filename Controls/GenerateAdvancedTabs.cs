using BecomeSifu.Logging;
using BecomeSifu.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

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
                tab.Header = "Boosts";
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
                tab.Header = "Debug";
                tab.Content = new Debug();
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
