using BecomeSifu.Objects;
using BecomeSifu.UserControls;
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
                foreach (Punches punch in Dojos.Punches)
                {
                    if(punch.Learned && punch.ExpToNext <= Dojos.Dojo[0].Exp)
                    {
                        punch.TryLevelUp();
                    }
                }
                foreach (Kicks kick in Dojos.Kicks)
                {
                    if (kick.Learned && kick.ExpToNext <= Dojos.Dojo[0].Exp)
                    {
                        kick.TryLevelUp();
                    }
                }
                foreach (Specials special in Dojos.Specials)
                {
                    if (special.Learned && special.ExpToNext <= Dojos.Dojo[0].Exp)
                    {
                        special.TryLevelUp();
                    }
                }
                foreach (Defenses def in Dojos.Defenses)
                {
                    if (def.Learned && def.ExpToNext <= Dojos.Dojo[0].Exp)
                    {
                        def.TryLevelUp();
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
