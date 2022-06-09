using BecomeSifu.MartialArts;
using BecomeSifu.Objects;
using BecomeSifu.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

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
            Tabs = PageHolder.MainClient.ActionTabControl.Items;
            PracticeTabs = PageHolder.MainClient.PracticeTabControl.Items;
            AdvancedTabs = PageHolder.MainClient.AdvancedTabControl.Items;
            

            _ = new GenerateFights();
            _ = new GenerateContent();
            _ = new GenerateTabs(Tabs);
            _ = new GeneratePracticeTabs(PracticeTabs);
            _ = new GenerateAdvancedTabs(AdvancedTabs);
            Bonuses = bonuses;
        }

        public void StartingMessages()
        {
            Extensions.CreateMessage("You have chosen well", false);
            Extensions.CreateMessage("The Basics", false);
            Extensions.CreateMessage("Let us Begin", true);

            var gif = new BitmapImage();
            gif.BeginInit();
            gif.UriSource = new Uri("../Animations/Kicks.gif");
            gif.EndInit();
            ImageBehavior.SetAnimatedSource(PageHolder.MainClient.Aniamtion, gif);
        }

        public void UpdateBonuses()
        {
            Dojos.Cup[0].UpdateBonuses(Bonuses);
            Dojos.Dojo[0].UpdateBonuses(Bonuses);
        }
    }
}
