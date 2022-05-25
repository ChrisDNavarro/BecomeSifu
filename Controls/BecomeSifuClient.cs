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
        public BecomeSifuClient()
        {
            Tabs = PageHolder.MainClient.ActionTabControl.Items;
            _ = new GenerateFights();
            _ = new GenerateContent();
            _ = new GenerateTabs(Tabs);

        }

       
    }
}
