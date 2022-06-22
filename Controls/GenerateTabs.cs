using BecomeSifu.Abstracts;
using BecomeSifu.Interfaces;
using BecomeSifu.Logging;
using BecomeSifu.MartialArts;
using BecomeSifu.Objects;
using BecomeSifu.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
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
                    TextBlock tbk = new TextBlock() { Text = type.Name, Foreground = new SolidColorBrush(Colors.AliceBlue), FontWeight = FontWeights.Bold };
                    TabItem tabItem = new TabItem();
                    if (type.Name.Contains("Attacks"))
                    {
                        tbk.Text = "Attacks";
                        tabItem.Header = tbk;
                        if (!Attacks)
                        {
                            Tabs.Add(tabItem);
                            Attacks = true;
                        }
                    }
                    else
                    {
                        tabItem.Header = tbk;
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
                    TextBlock tabName = (TextBlock)tab.Header;
                    if (tabName.Text.Contains("Attacks"))
                    {
                        BuildBottomTabs(tab);
                    }
                    else
                    {
                        UserControl control = (UserControl)Activator.CreateInstance(Assembly.GetExecutingAssembly().ToString(), $"BecomeSifu.UserControls.{tabName.Text}").Unwrap();
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
                BottomTabs bottoms = new BottomTabs();

                List<PropertyInfo> bottomTabs = typeof(IDojo).GetProperties().ToList();
                foreach (PropertyInfo pI in bottomTabs)
                {
                    string name = pI.Name;
                    if (!name.Contains("Perk"))
                    {
                        if (!name.Contains("Defenses") && pI.PropertyType.ToString().Contains("List"))
                        {
                            TextBlock tbk = new TextBlock() { Text = name, Foreground = new SolidColorBrush(Colors.AliceBlue), FontWeight = FontWeights.Bold };
                            TabItem bottomTab = new TabItem();
                            if (PageHolder.MainWindow.DojoState.Dojo[0].IsBoxing && name.Contains("Kicks"))
                            {
                                tbk.Text = "To The Body";
                            }

                            bottomTab.Header = tbk;                            
                            UserControl control = (UserControl)Activator.CreateInstance(Assembly.GetExecutingAssembly().ToString(), $"BecomeSifu.UserControls.Attacks{name}").Unwrap();
                            bottomTab.Content = control;
                            bottoms.Tabs.Items.Add(bottomTab);
                        }
                    }
                }
                LogIt.Write($"Created bottom tabs and content");

                tab.Content = bottoms;
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
    }
}
