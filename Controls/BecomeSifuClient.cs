using BecomeSifu.MartialArts;
using BecomeSifu.Objects;
using BecomeSifu.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Controls;

namespace BecomeSifu.Controls
{
    public class BecomeSifuClient
    {
        private ItemCollection Tabs;
        private ItemCollection PracticeTabs;
        private ItemCollection AdvancedTabs;
        public BecomeSifuClient()
        {
            Tabs = PageHolder.MainClient.ActionTabControl.Items;
            PracticeTabs = PageHolder.MainClient.PracticeTabControl.Items;
            AdvancedTabs = PageHolder.MainClient.AdvancedTabControl.Items;
            

            _ = new GenerateFights();
            _ = new GenerateContent();
            _ = new GenerateTabs(Tabs);
            _ = new GeneratePracticeTabs(PracticeTabs);
            _ = new GenerateAdvancedTabs(AdvancedTabs);

        }
    }
}
