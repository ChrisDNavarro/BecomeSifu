using BecomeSifu.Objects;
using BecomeSifu.UserControls;
using BecomeSifu.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

namespace BecomeSifu.Controls
{
    public static class BoostsController
    {
        public static int Boost { get; set; } = 1;
        public static DispatcherTimer AutoPurchase { get; set; }

        public static void UpdateBoost(int value)
        {
            Boost = value;
            Extensions.UpdateBoostedEXP();
        }

        public static void InitializeTimer()
        {
            AutoPurchase.Tick += AutoBuy;
            AutoPurchase.Interval = TimeSpan.FromMilliseconds(5);
        }

        public async static void AutoBuy(object source, EventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ActionsViewModel punch in PageHolder.MainWindow.DojoState.Punches)
                {
                    if(punch.Learned && punch.ExpToNext <= PageHolder.MainWindow.DojoState.Dojo[0].Exp)
                    {
                        Punches.TryLevelUp(punch);
                    }
                }
                foreach (ActionsViewModel kick in PageHolder.MainWindow.DojoState.Kicks)
                {
                    if (kick.Learned && kick.ExpToNext <= PageHolder.MainWindow.DojoState.Dojo[0].Exp)
                    {
                        Kicks.TryLevelUp(kick);
                    }
                }
                foreach (ActionsViewModel special in PageHolder.MainWindow.DojoState.Specials)
                {
                    if (special.Learned && special.ExpToNext <= PageHolder.MainWindow.DojoState.Dojo[0].Exp)
                    {
                        Specials.TryLevelUp(special);
                    }
                }
                foreach (ActionsViewModel def in PageHolder.MainWindow.DojoState.Defenses)
                {
                    if (def.Learned && def.ExpToNext <= PageHolder.MainWindow.DojoState.Dojo[0].Exp)
                    {
                        Defenses.TryLevelUp(def);
                    }
                }
            });
        }

        public async static void StartTimer()
        {
            await Task.Run(() => AutoPurchase.Start());
        }
        public async static void StopTimer()
        {
            await Task.Run(() => AutoPurchase.Stop());
        }



    }
}
