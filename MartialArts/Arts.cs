using BecomeSifu.Controls;
using BecomeSifu.MartialArts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BecomeSifu.MartialArts
{
    public class Arts : Practicing
    {

        public bool CurrentArt { get; set; }
        public decimal TotalSteps { get; set; }
        public decimal TotalLevels { get; set; }


        public Dictionary<int, string> Punches { get; } = new Dictionary<int, string>();
        public Dictionary<int, string> Specials { get; } = new Dictionary<int, string>();
        public Dictionary<int, string> Kicks { get; } = new Dictionary<int, string>();
        public Dictionary<int, string> Defenses { get; } = new Dictionary<int, string>();


        public decimal AttacksExpToNext(int step, decimal previousExp)
        {
            return step <= 3
                ? (decimal)Math.Pow(.8 * step, 3) + previousExp + 1
                : step == 4 || step == 5
                ? (decimal)Math.Pow(step, 3) + previousExp
                : step == 6 || step == 7
                ? decimal.Subtract((decimal)Math.Pow(1.2 * step, 3), (decimal)Math.Pow(15 * step, 2)) - 100 * step - 140 + previousExp
                : (decimal)Math.Pow(1.25 * step, 3) + previousExp;
        }

        public decimal EnergyToUnlock(int step)
        {
            return (decimal)Math.Pow(10, step);
        }
    }
}
