﻿using BecomeSifu.Controls;
using BecomeSifu.MartialArts;
using System;
using System.Collections.Generic;
using System.Text;
using BecomeSifu;
using BecomeSifu.Objects;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Threading;

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


        public virtual decimal AttacksExpToNext(int step, int level)
        {
            return step <= 3
                ? LowStep(level)
                : step == 4 || step == 5
                ? LowMidStep(level)
                : step == 6 || step == 7
                ? HighMidStep(level)
                : HighStep(level);
        }

        private decimal LowStep(int level)
        {
            return level < 50
                ? (decimal)Math.Pow(.8 * level, 3) + 10 + 1
                : level < 68
                ? (decimal)Math.Pow(level, 3) + 10
                : level < 98
                ? decimal.Subtract((decimal)Math.Pow(1.2 * level, 3), (decimal)Math.Pow(15 * level, 2)) - 100 * level - 140 + 10
                : (decimal)Math.Pow(1.25 * level, 3) + 10;
        }

        private decimal LowMidStep(int level)
        {
            return level < 50
                ? decimal.Multiply((decimal)Math.Pow(.8 * level, 3), (decimal)1.5)
                : level < 68
                ? decimal.Multiply((decimal)Math.Pow(level, 3), (decimal)1.5)
                : level < 98
                ? decimal.Multiply(decimal.Subtract((decimal)Math.Pow(1.2 * level, 3), (decimal)Math.Pow(15 * level, 2)) - 100 * level - 140, (decimal)1.5)
                : decimal.Multiply((decimal)Math.Pow(1.25 * level, 3), (decimal)1.5);
        }

        private decimal HighMidStep(int level)
        {
            return level < 50
                ? decimal.Multiply((decimal)Math.Pow(.8 * level, 3), (decimal)3)
                : level < 68
                ? decimal.Multiply((decimal)Math.Pow(level, 3), (decimal)3)
                : level < 98
                ? decimal.Multiply(decimal.Subtract((decimal)Math.Pow(1.2 * level, 3), (decimal)Math.Pow(15 * level, 2)) - 100 * level - 140, (decimal)3)
                : decimal.Multiply((decimal)Math.Pow(1.25 * level, 3), (decimal)3);
        }

        private decimal HighStep(int level)
        {
            return level < 50
                ? decimal.Multiply((decimal)Math.Pow(.8 * level, 3), (decimal)9)
                : level < 68
                ? decimal.Multiply((decimal)Math.Pow(level, 3), (decimal)9)
                : level < 98
                ? decimal.Multiply(decimal.Subtract((decimal)Math.Pow(1.2 * level, 3), (decimal)Math.Pow(15 * level, 2)) - 100 * level - 140, (decimal)9)
                : decimal.Multiply((decimal)Math.Pow(1.25 * level, 3), (decimal)9);
        }



        public virtual decimal EnergyToUnlock(int step)
        {
            return (decimal)Math.Pow(10, step);
        }

        public void Practice()
        {
            if (!Dojos.BoundDojo[0].IsMeditating)
            {
                Dojos.BoundDojo[0].CalculateEnergyGain();
                Dojos.BoundDojo[0].Energy += Dojos.BoundDojo[0].EnergyGain;
                Dojos.BoundDojo[0].EnergyString = Dojos.BoundDojo[0].Energy.ConvertToString();
                Dojos.BoundDojo[0].EnergyGainString = Dojos.BoundDojo[0].EnergyGain.ConvertToString();

                Dojos.BoundDojo[0].CalculateExpGain();
                Dojos.BoundDojo[0].Exp += Dojos.BoundDojo[0].ExpGain;
                Dojos.BoundDojo[0].ExpString = Dojos.BoundDojo[0].Exp.ConvertToString();
                Dojos.BoundDojo[0].ExpGainString = Dojos.BoundDojo[0].ExpGain.ConvertToString();

                Dojos.BoundDojo[0].CalculateAttackGain();
                Dojos.BoundDojo[0].Attack += Dojos.BoundDojo[0].AttackGain;
                Dojos.BoundDojo[0].AttackString = Dojos.BoundDojo[0].Attack.ConvertToString();
                Dojos.BoundDojo[0].AttackGainString = Dojos.BoundDojo[0].AttackGain.ConvertToString();

                Dojos.BoundDojo[0].CalculateDefenseGain();
                Dojos.BoundDojo[0].Defense += Dojos.BoundDojo[0].DefenseGain;
                Dojos.BoundDojo[0].DefenseString = Dojos.BoundDojo[0].Defense.ConvertToString();
                Dojos.BoundDojo[0].DefenseGainString = Dojos.BoundDojo[0].DefenseGain.ConvertToString();

                Dojos.BoundDojo.Refresh();

                Extensions.UpdateActives();
            }
        }
        public void StartStopMeditation()
        {
            if (Dojos.BoundDojo[0].IsMeditating)
            {
                Dojos.BoundDojo[0].IsMeditating = false;
            }
            else
            {
                Dojos.BoundDojo[0].IsMeditating = true;
            }
        }

        public void Meditation()
        {
            Dojos.BoundDojo[0].CalculateHealthGain();
            Dojos.BoundDojo[0].Health += Dojos.BoundDojo[0].HealthGain;
            Dojos.BoundDojo[0].HealthString = Dojos.BoundDojo[0].HealthGain.ConvertToString();

            Dojos.BoundDojo[0].CalculateEnergyGain();
            Dojos.BoundDojo[0].Energy += Dojos.BoundDojo[0].EnergyGain / 2;
            Dojos.BoundDojo[0].EnergyString = Dojos.BoundDojo[0].EnergyGain.ConvertToString();

            Dojos.BoundDojo.Refresh();
        }

        public void StartStopAutoPractice()
        {
            if (Dojos.BoundDojo[0].AutoPractice)
            {
                Dojos.BoundDojo[0].AutoPractice = !Dojos.BoundDojo[0].AutoPractice;
                Dojos.BoundDojo[0].Timer.Stop();
                Dojos.BoundDojo.Refresh();
            }
            else
            {
                Dojos.BoundDojo[0].AutoPractice = !Dojos.BoundDojo[0].AutoPractice;
                Dojos.BoundDojo[0].Timer.Tick += Dojos.BoundDojo[0].Timer_Tick;
                Dojos.BoundDojo[0].Timer.Interval = TimeSpan.FromMilliseconds((double)(1000 * Dojos.BoundDojo[0].Multiplier));
                Dojos.BoundDojo.Refresh();
                Dojos.BoundDojo[0].Timer.Start();
            }
        }

        public void Timer_Tick(object source, EventArgs e)
        {
            Dojos.BoundDojo[0].Practice();
        }

        public void StartStopAutoMeditate()
        {
            if (Dojos.BoundDojo[0].AutoMeditate)
            {
                Dojos.BoundDojo[0].AutoMeditate = !Dojos.BoundDojo[0].AutoMeditate;
            }
            else
            {
                Dojos.BoundDojo[0].AutoMeditate = !Dojos.BoundDojo[0].AutoMeditate;
                Dojos.BoundDojo[0].Rate = (1 / Dojos.BoundDojo[0].Multiplier).ConvertToString() + " click(s)/s";
                _ = Dojos.BoundDojo[0].RunAutoMeditate(Dojos.BoundDojo[0].Multiplier);
            }
        }

        public async Task RunAutoMeditate(decimal multiplier)
        {
            while (Dojos.BoundDojo[0].AutoMeditate)
            {
                await Task.Run(() =>
                {
                    Dojos.BoundDojo[0].Meditation();
                    Thread.Sleep((int)decimal.Multiply(1000, multiplier));
                });
            }
        }

        public virtual void CalculateHealthGain()
        {
            decimal x = Dojos.BoundDojo[0].TotalSteps * Dojos.BoundDojo[0].TotalLevels / 1000;
            Dojos.BoundDojo[0].HealthGain = x < 50
                ? (decimal)Math.Pow(Convert.ToDouble(x), 3) * (100 - x) / 50 / 2
                : x < 68
                ? (decimal)Math.Pow(Convert.ToDouble(x), 3) * (150 - x) / 100 / 2
                : x < 98
                ? (decimal)Math.Pow(Convert.ToDouble(x), 3) * ((1911 - 10 * x) / 500) / 100 / 2
                : (decimal)Math.Pow(Convert.ToDouble(x), 3) * .6M / 100 * (x / 100) / 2;
        }

        public virtual void CalculateDefenseGain()
        {
            foreach (Defenses defense in Dojos.Defenses)
            {
                Dojos.BoundDojo[0].DefenseGain = defense.Step * Convert.ToDecimal(defense.LevelInt);
            }
        }

        public virtual void CalculateAttackGain()
        {
            decimal total = 0;
            foreach (Punches punch in Dojos.Punches)
            {
                total += punch.Step * punch.LevelInt;
            }
            foreach (Kicks kick in Dojos.Kicks)
            {
                total += kick.Step * kick.LevelInt;
            }
            foreach (Specials special in Dojos.Specials)
            {
                total += special.Step * 10 * special.LevelInt;
            }
            Dojos.BoundDojo[0].AttackGain = total;
        }

        public virtual void CalculateExpGain()
        {
            decimal x = Dojos.BoundDojo[0].TotalSteps * Dojos.BoundDojo[0].TotalLevels;
            Dojos.BoundDojo[0].ExpGain = x < 50
                ? (decimal)Math.Pow(.8 * (double)x/1.75, 3)
                : x < 68
                ? (decimal)Math.Pow((double)x, 3)
                : x < 98
                ? decimal.Subtract((decimal)Math.Pow(15 * (double)x, 2), (decimal)Math.Pow(1.2 * (double)x, 3)) - 100 * x - 140
                : (decimal)Math.Pow(1.25 * (double)x, 3);
        }

        public virtual void CalculateEnergyGain()
        {
            
            decimal x = Dojos.BoundDojo[0].TotalSteps * Dojos.BoundDojo[0].TotalLevels;
            if (!Dojos.BoundDojo[0].IsMeditating)
            {
                Dojos.BoundDojo[0].EnergyGain = x < 50
                ? (decimal)Math.Pow(Convert.ToDouble(x), 3) * (100 - x) / 50
                : x < 68
                ? (decimal)Math.Pow(Convert.ToDouble(x), 3) * (150 - x) / 100
                : x < 98
                ? (decimal)Math.Pow(Convert.ToDouble(x), 3) * ((1911 - 10 * x) / 500) / 100
                : (decimal)Math.Pow(Convert.ToDouble(x), 3) * .6M / 100 * (x / 100);
            }
            else
            {
                Dojos.BoundDojo[0].EnergyGain = x < 50
                ? (decimal)Math.Pow(Convert.ToDouble(x), 3) * (100 - x) / 50 / 2
                : x < 68
                ? (decimal)Math.Pow(Convert.ToDouble(x), 3) * (150 - x) / 100 / 2
                : x < 98
                ? (decimal)Math.Pow(Convert.ToDouble(x), 3) * ((1911 - 10 * x) / 500) / 100 / 2
                : (decimal)Math.Pow(Convert.ToDouble(x), 3) * .6M / 100 * (x / 100) / 2;
            }
        }


    }
}
