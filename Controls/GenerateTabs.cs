using BecomeSifu.MartialArts;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace BecomeSifu.Controls
{
    public class GenerateTabs
    {
        private ItemCollection Tabs;
        private bool Attacks;

        public GenerateTabs(ItemCollection tabs)
        {
            Tabs = tabs;

            IEnumerable<Type> types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.FullName.Contains("UserControls") && !t.Name.Contains("<>c"));

            foreach (Type type in types)
            {
                TabItem tabItem = new TabItem();
                if (type.Name.Contains("Attacks"))
                {
                    tabItem.Header = "Attacks";
                    if (!Attacks)
                    {
                        Tabs.Add(tabItem);
                        Attacks = true;
                    }
                }
                else
                {                                      
                    tabItem.Header = type.Name;
                    Tabs.Add(tabItem);
                }

            }

            PopulateTabs();
        }

        private void PopulateTabs()
        {
            foreach (TabItem tab in Tabs)
            {
                if (tab.Header.ToString().Contains("Attacks"))
                {
                    BuildBottomTabs(tab);
                }
                else
                {                   
                    UserControl control = (UserControl)Activator.CreateInstance("BecomeSifu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", $"BecomeSifu.UserControls.{tab.Header}").Unwrap();
                    tab.Content = control;
                }
            }
        }

        private void BuildBottomTabs(TabItem tab)
        {
            TabControl attackTabs = new TabControl
            {
                TabStripPlacement = Dock.Bottom,
            };

            List<PropertyInfo> bottomTabs = typeof(IDojo).GetProperties().ToList();
            foreach (PropertyInfo pI in bottomTabs)
            {
                string name = pI.Name;
                if (!name.Contains("Defenses") && pI.PropertyType.ToString().Contains("Dictionary"))
                {
                    TabItem bottomTab = new TabItem
                    {
                        Header = name,
                    };
                    if (Dojos.BoundDojo[0].IsBoxing && name.Contains("Kicks"))
                    {
                        bottomTab.Header = "To The Body";
                    }
                    UserControl control = (UserControl)Activator.CreateInstance("BecomeSifu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", $"BecomeSifu.UserControls.Attacks{name}").Unwrap();
                    bottomTab.Content = control;
                    attackTabs.Items.Add(bottomTab);
                }
            }

            tab.Content = attackTabs;
        }
    }
}
