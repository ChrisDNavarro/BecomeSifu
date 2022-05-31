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
            advancedTabs.Add(BoostsTab(new TabItem()));
            advancedTabs.Add(DebugTab(new TabItem()));
        }

        private TabItem BoostsTab(TabItem tab)
        {
            tab.Header = "Boosts";
            tab.Content = new Boosts();
            return tab;
        }
        private TabItem DebugTab(TabItem tab)
        {
            tab.Header = "Debug";
            tab.Content = new Debug();
            return tab;
        }
    }
}
