using BecomeSifu.MartialArts;
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
        private bool TabColor;
        private bool contentcolor;

        public GenerateTabs(ItemCollection tabs)
        {
            Tabs = tabs;

            IEnumerable<Type> types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.FullName.Contains("UserControls") && !t.Name.Contains("<>c"));

            foreach (Type type in types)
            {
                TabItem tabItem = new TabItem();
                if (type.Name.Contains("Attacks"))
                {
                    tabItem.Name = "AttacksTabItem";
                    tabItem.Header = "Attacks";
                    if (TabColor)
                    {
                        tabItem.Background = new SolidColorBrush(Colors.Crimson);
                        TabColor = false;
                    }
                    else
                    {
                        tabItem.Background = new SolidColorBrush(Colors.Goldenrod);
                        TabColor = true;
                    }
                    if (!Attacks)
                    {
                        Tabs.Add(tabItem);
                        Attacks = true;
                    }
                }
                else
                {
                    tabItem.Name = $"{type.Name}TabItem";
                    tabItem.Header = type.Name;
                    if (TabColor)
                    {
                        tabItem.Background = new SolidColorBrush(Colors.Crimson);                        
                        TabColor = false;
                    }
                    else
                    {
                        tabItem.Background = new SolidColorBrush(Colors.Goldenrod);
                        TabColor = true;
                    }
                    Tabs.Add(tabItem);
                }

            }

            PopulateTabs();
        }

        private void PopulateTabs()
        {
            foreach (TabItem tab in Tabs)
            {
                if (tab.Name.Contains("Attacks"))
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
                        Name = name + "AttackTab"
                    };
                    UserControl control = (UserControl)Activator.CreateInstance("BecomeSifu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", $"BecomeSifu.UserControls.Attacks{bottomTab.Header}").Unwrap();
                    bottomTab.Content = control;
                    if (TabColor)
                    {
                        bottomTab.Background = new SolidColorBrush(Colors.Crimson);
                        TabColor = false;
                    }
                    else
                    {
                        bottomTab.Background = new SolidColorBrush(Colors.Goldenrod);
                        TabColor = true;
                    }
                    attackTabs.Items.Add(bottomTab);
                }
            }

            tab.Content = attackTabs;
        }
    }
}
