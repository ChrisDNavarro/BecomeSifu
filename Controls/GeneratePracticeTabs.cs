using BecomeSifu.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace BecomeSifu.Controls
{
    public class GeneratePracticeTabs
    {
        public GeneratePracticeTabs(ItemCollection practicetabs )
        {
            practicetabs.Add(PracticeTab(new TabItem()));
            practicetabs.Add(MeditationTab(new TabItem()));
            practicetabs.Add(EmptyCupTab(new TabItem()));
        }

        private TabItem PracticeTab(TabItem tab)
        {
            tab.Header = "Pratice";
            tab.Content = new Practice();
            return tab;
        }

        private TabItem MeditationTab(TabItem tab)
        {
            tab.Header = "Meditation";
            tab.Content = new Meditate();
            return tab;
        }
        private TabItem EmptyCupTab(TabItem tab)
        {
            tab.Header = "Cup Of Knowledge";
            tab.Content = new EmptyCup();
            return tab;
        }

    }
}
