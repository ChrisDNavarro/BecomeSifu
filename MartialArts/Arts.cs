using BecomeSifu.Controls;
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
using System.Windows;

namespace BecomeSifu.MartialArts
{
    public class Arts : Practicing
    {
        public bool CurrentArt { get; set; }
        public decimal TotalSteps { get; set; }
        public decimal TotalLevels { get; set; }
        public decimal AttackSpeedModifier { get; set; }
        private decimal BonusOne { get; set; }
        private decimal BonusTwo { get; set; }
        private bool Bonuses;

        public Dictionary<int, string> Punches { get; } = new Dictionary<int, string>();
        public Dictionary<int, string> Specials { get; } = new Dictionary<int, string>();
        public Dictionary<int, string> Kicks { get; } = new Dictionary<int, string>();
        public Dictionary<int, string> Defenses { get; } = new Dictionary<int, string>();

        public void UpdateBonuses(List<int> bonuses)
        {
            foreach (int bonus in bonuses)
            {
                if (bonus == 1)
                {
                    BonusOne++;
                }
                if (bonus == 2)
                {
                    BonusTwo++;
                }
            }
            if (BonusOne > 0 || BonusTwo > 0)
            {
                Bonuses = true;
            }
            Dojos.Dojo.Refresh();
        }


        public virtual decimal AttacksExpToNext(int step, int level)
        {
            return step <= 3
                ? (decimal)(4 * Math.Pow(level + 1, 3) / 5)
                : step == 4 || step == 5
                ? (decimal)Math.Pow(level + 2, 3)
                : step == 6 || step == 7
                ? (decimal)((1.2 * Math.Pow(level + 3, 3)) - (15 * Math.Pow(level + 3, 2)) + (100 * (level + 3)) - 140)
                : (decimal)(5 * Math.Pow(level + 4, 3) / 4);
        }



        public virtual decimal EnergyToUnlock(int step)
        {
            return Bonuses && BonusOne > 0 
                ? (decimal)Math.Pow(10, step) * (1 - (.1M * BonusOne)) 
                : (decimal)Math.Pow(10, step);
        }

        public void Practice()
        {
            if (!IsMeditating)
            {
                CalculateEnergyGain();
                Energy += EnergyGain;
                EnergyString = Energy.ConvertToString();
                EnergyGainString = EnergyGain.ConvertToString();

                CalculateExpGain();
                Exp += ExpGain;
                ExpString = Exp.ConvertToString();
                ExpGainString = ExpGain.ConvertToString();

                CalculateAttackGain();
                Attack += AttackGain;
                AttackString = Attack.ConvertToString();
                AttackGainString = AttackGain.ConvertToString();

                CalculateDefenseGain();
                Defense += DefenseGain;
                DefenseString = Defense.ConvertToString();
                DefenseGainString = DefenseGain.ConvertToString();

                Dojos.Dojo.Refresh();

                Extensions.UpdateActives();
            }
        }

        public void CalculateAll()
        {
            CalculateEnergyGain();
            EnergyGainString = EnergyGain.ConvertToString();

            CalculateExpGain();
            ExpGainString = ExpGain.ConvertToString();

            CalculateAttackGain();
            AttackGainString = AttackGain.ConvertToString();

            CalculateDefenseGain();
            DefenseGainString = DefenseGain.ConvertToString();

            CalculateHealthGain();
            HealthGainString = HealthGain.ConvertToString();
        }

        public void StartStopMeditation()
        {
            if (IsMeditating)
            {
                IsMeditating = !IsMeditating;
                IsMeditatingString = "Start Meditating";
                MeditateOption = Visibility.Collapsed;
                Dojos.Dojo.Refresh();
                Extensions.UpdateActives();
            }
            else
            {
                IsMeditating = !IsMeditating;
                IsMeditatingString = "Stop Meditating";
                MeditateOption = Visibility.Visible;
                Dojos.Dojo.Refresh();
                Extensions.UpdateActives();
            }
        }

        public virtual void Meditation()
        {
            CalculateHealthGain();
            Health += HealthGain;
            HealthString = Health.ConvertToString();
            HealthGainString = HealthGain.ConvertToString();

            CalculateEnergyGain();
            Energy += EnergyGain;
            EnergyString = Energy.ConvertToString();
            EnergyGainString = EnergyGain.ConvertToString();

            Dojos.Dojo.Refresh();
            Extensions.UpdateActives();
        }

        public async void StartStopAutoPractice()
        {
            await Task.Run(() =>
            {
                if (AutoPractice)
                {
                    AutoPractice = !AutoPractice;
                    Rate = "Auto";
                    Dojos.Dojo.Refresh();
                    Timer.Stop();
                    Dojos.Dojo.Refresh();
                }
                else
                {
                    AutoPractice = !AutoPractice;
                    Rate = (1 / Multiplier).ConvertToString() + " click(s)/s";
                    Timer.Tick += Timer_Tick;
                    Timer.Interval = TimeSpan.FromMilliseconds((double)(1000 * Multiplier));
                    Dojos.Dojo.Refresh();
                    Timer.Start();
                    Dojos.Dojo.Refresh();
                }
            });
        }

        public void Timer_Tick(object source, EventArgs e)
        {
            if (!IsMeditating)
            {
                Practice();
            }
        }

        public void MeditateTimer_Tick(object source, EventArgs e)
        {
            Meditation();
        }

        public async void StartStopAutoMeditate()
        {
            await Task.Run(() =>
            {
                if (AutoMeditate)
                {
                    AutoMeditate = !AutoMeditate;
                    Rate = "Auto";
                }
                else
                {
                    AutoMeditate = !AutoMeditate;
                    Rate = (1 / Multiplier).ConvertToString() + " click(s)/s";
                    MeditateTimer.Tick += MeditateTimer_Tick;
                    MeditateTimer.Interval = TimeSpan.FromMilliseconds((double)(1000 * Multiplier));
                    Dojos.Dojo.Refresh();
                    MeditateTimer.Start();
                }
            });
        }

        public virtual void CalculateHealthGain()
        {
            decimal x = TotalSteps * TotalLevels / 10;
            HealthGain = x < 50
                ? decimal.Add((decimal)Math.Pow(Convert.ToDouble(x), 3) * (100 - x) / 50 / 2, 0.01M)
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
                DefenseGain = defense.Step * Convert.ToDecimal(defense.LevelInt) * 10;
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
            AttackGain = total;
        }

        public virtual void CalculateExpGain()
        {
            ExpGain = Bonuses && BonusTwo > 0 
                ? TotalSteps * TotalLevels * ( 1 + (.5M * BonusTwo)) 
                : TotalSteps * TotalLevels;
        }

        public virtual void CalculateEnergyGain()
        {
            decimal x = TotalSteps * TotalLevels / 2;
            EnergyGain = IsMeditating
                ? x < 50
                ? (decimal)Math.Pow(Convert.ToDouble(x), 3) * (100 - x) / 50 
                : x < 68
                ? (decimal)Math.Pow(Convert.ToDouble(x), 3) * (150 - x) / 100
                : x < 98
                ? (decimal)Math.Pow(Convert.ToDouble(x), 3) * ((1911 - 10 * x) / 500) / 100
                : (decimal)Math.Pow(Convert.ToDouble(x), 3) * .6M / 100 * (x / 100)
                : x < 50
                ? (decimal)Math.Pow(Convert.ToDouble(x), 3) * (100 - x) / 50 / 3
                : x < 68
                ? (decimal)Math.Pow(Convert.ToDouble(x), 3) * (150 - x) / 100 / 3
                : x < 98
                ? (decimal)Math.Pow(Convert.ToDouble(x), 3) * ((1911 - 10 * x) / 500) / 100 / 3
                : (decimal)Math.Pow(Convert.ToDouble(x), 3) * .6M / 100 * (x / 100) / 3;
        }


    }
}
