using BecomeSifu.Abstracts;
using BecomeSifu.Interfaces;
using BecomeSifu.Logging;
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
            try
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
                LogIt.Write($"Created Tabs for Content");
                PopulateTabs();
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        private void PopulateTabs()
        {
            try
            {
                foreach (TabItem tab in Tabs)
                {
                    if (tab.Header.ToString().Contains("Attacks"))
                    {
                        BuildBottomTabs(tab);
                    }
                    else
                    {
                        UserControl control = (UserControl)Activator.CreateInstance(Assembly.GetExecutingAssembly().ToString(), $"BecomeSifu.UserControls.{tab.Header}").Unwrap();
                        tab.Content = control;
                    }
                }
                LogIt.Write($"Created top tabs and content");
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        private void BuildBottomTabs(TabItem tab)
        {
            try
            {

                TabControl attackTabs = new TabControl
                {
                    TabStripPlacement = Dock.Bottom,
                };

                List<PropertyInfo> bottomTabs = typeof(IDojo).GetProperties().ToList();
                foreach (PropertyInfo pI in bottomTabs)
                {
                    string name = pI.Name;
                    if (!name.Contains("Perk"))
                    {
                        if (!name.Contains("Defenses") && pI.PropertyType.ToString().Contains("List"))
                        {
                            TabItem bottomTab = new TabItem
                            {
                                Header = name,
                            };
                            if (PageHolder.MainWindow.DojoState.Dojo[0].IsBoxing && name.Contains("Kicks"))
                            {
                                bottomTab.Header = "To The Body";
                            }
                            UserControl control = (UserControl)Activator.CreateInstance(Assembly.GetExecutingAssembly().ToString(), $"BecomeSifu.UserControls.Attacks{name}").Unwrap();
                            bottomTab.Content = control;
                            attackTabs.Items.Add(bottomTab);
                        }
                    }
                }
                LogIt.Write($"Created bottom tabs and content");

                tab.Content = attackTabs;
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
    }
}
