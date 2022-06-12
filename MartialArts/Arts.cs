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
using System.Collections.ObjectModel;
using BecomeSifu.Logging;

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
        public ObservableCollection<Perk> Perks { get; } = new ObservableCollection<Perk>();
        public bool Maxed { get; set; }

        public void UpdateBonuses(List<int> bonuses)
        {
            try
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
                LogIt.Write();
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }


        public virtual decimal AttacksExpToNext(int step, int level)
        {
            try
            {
                LogIt.Write();
                decimal exp = 0;
                for (int i = 0; i < BoostsController.Boost; i++)
                {
                    if (level + i <= 500)
                    {
                        exp += step <= 3
                                ? (decimal)(4 * Math.Pow((level + i) + 1, 3) / 5)
                                : step == 4 || step == 5
                                ? (decimal)Math.Pow((level + i) + 2, 3)
                                : step == 6 || step == 7
                                ? (decimal)((1.2 * Math.Pow((level + i) + 3, 3)) - (15 * Math.Pow((level + i) + 3, 2)) + (100 * ((level + i) + 3)) - 140)
                                : (decimal)(5 * Math.Pow((level + i) + 4, 3) / 4);
                    }
                    else
                    {
                        break;
                    }
                }
                return exp;
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        } 



        public virtual decimal EnergyToUnlock(int step)
        {
            try
            {
                LogIt.Write($"With {BonusTwo} stack of empty cup bonus");
                return Bonuses && BonusTwo > 0
                       ? (decimal)Math.Pow(10, step) * (1 - (.1M * BonusOne))
                       : (decimal)Math.Pow(10, step);
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        public void Practice()
        {
            try
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
                    LogIt.Write();
                }
                else
                {
                    LogIt.Write($"Did not Practice as Meditation is started.");
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        public void CalculateAll()
        {
            try
            {
                CalculateEnergyGain();
                EnergyGainString = EnergyGain.ConvertToString();

                CalculateMeditationEnergyGain();
                EnergyMeditationGainString = EnergyMeditationGain.ConvertToString();

                CalculateExpGain();
                ExpGainString = ExpGain.ConvertToString();

                CalculateAttackGain();
                AttackGainString = AttackGain.ConvertToString();

                CalculateDefenseGain();
                DefenseGainString = DefenseGain.ConvertToString();

                CalculateHealthGain();
                HealthGainString = HealthGain.ConvertToString();
                LogIt.Write();
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }            
        }

        public bool CheckForMaxed()
        {
            try
            {
                int maxed = 0;

                foreach (Punches punch in Dojos.Punches)
                {
                    if (punch.LevelInt == 500)
                    {
                        maxed++;
                    }
                }
                foreach (Kicks kick in Dojos.Kicks)
                {
                    if (kick.LevelInt == 500)
                    {
                        maxed++;
                    }
                }
                foreach (Specials special in Dojos.Specials)
                {
                    if (special.LevelInt == 500)
                    {
                        maxed++;
                    }
                }
                foreach (Defenses def in Dojos.Defenses)
                {
                    if (def.LevelInt == 500)
                    {
                        maxed++;
                    }
                }
                LogIt.Write();
                return maxed == Dojos.Punches.Count + Dojos.Kicks.Count + Dojos.Specials.Count + Dojos.Defenses.Count;
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }

        }

        public void StartStopMeditation()
        {
            try
            {
                if (IsMeditating)
                {
                    LogIt.Write($"Stop");
                    IsMeditating = !IsMeditating;
                    IsMeditatingString = "Start Meditating";
                    MeditateOption = Visibility.Collapsed;
                    MeditateTimer.Stop();
                    AutoMeditate = false;
                    Dojos.Dojo.Refresh();
                    Extensions.UpdateActives();
                }
                else
                {
                    LogIt.Write($"Start");
                    IsMeditating = !IsMeditating;
                    IsMeditatingString = "Stop Meditating";
                    MeditateOption = Visibility.Visible;
                    Dojos.Dojo.Refresh();
                    Extensions.UpdateActives();
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        public virtual void Meditation()
        {
            try
            {

                if (Perks[5].Active)
                {
                    CalculateHealthGain();
                    Health += HealthGain * 1.5M;
                    HealthString = Health.ConvertToString();
                    HealthGainString = (HealthGain * 1.5M).ConvertToString();

                    CalculateMeditationEnergyGain();
                    Energy += EnergyMeditationGain * 1.5M;
                    EnergyString = Energy.ConvertToString();
                    EnergyMeditationGainString = (EnergyMeditationGain * 1.5M).ConvertToString();
                }
                else
                {
                    CalculateHealthGain();
                    Health += HealthGain;
                    HealthString = Health.ConvertToString();
                    HealthGainString = HealthGain.ConvertToString();

                    CalculateMeditationEnergyGain();
                    Energy += EnergyMeditationGain;
                    EnergyString = Energy.ConvertToString();
                    EnergyMeditationGainString = EnergyMeditationGain.ConvertToString();
                }

                Dojos.Dojo.Refresh();
                Extensions.UpdateActives();
                LogIt.Write($"With Perk: '{Perks[5].Name}' set to {Perks[5].Active}");
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        public async void StartStopAutoPractice()
        {
            await Task.Run(() =>
            {
                try
                {

                    if (AutoPractice)
                    {
                        LogIt.Write($"Stop");
                        AutoPractice = !AutoPractice;
                        Rate = "Auto";
                        Dojos.Dojo.Refresh();
                        Timer.Stop();
                        Dojos.Dojo.Refresh();
                    }
                    else
                    {
                        LogIt.Write($"Start");
                        AutoPractice = !AutoPractice;
                        Rate = (1 / AutoSpeedMultiplier).ConvertToString() + " click(s)/s";
                        Timer.Tick += Timer_Tick;
                        Timer.Interval = TimeSpan.FromMilliseconds((double)(1000 * AutoSpeedMultiplier));
                        Dojos.Dojo.Refresh();
                        Timer.Start();
                        Dojos.Dojo.Refresh();
                    }
                }
                catch (Exception e)
                {
                    LogIt.Write($"Error Caught: {e}");
                    throw;
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
                try
                {
                    if (AutoMeditate)
                    {
                        LogIt.Write($"Stop");
                        AutoMeditate = !AutoMeditate;
                        Rate = "Auto";
                        Dojos.Dojo.Refresh();
                        MeditateTimer.Stop();
                        Dojos.Dojo.Refresh();
                    }
                    else
                    {
                        LogIt.Write($"Start");
                        AutoMeditate = !AutoMeditate;
                        Rate = (1 / AutoSpeedMultiplier).ConvertToString() + " click(s)/s";
                        MeditateTimer.Tick += MeditateTimer_Tick;
                        MeditateTimer.Interval = TimeSpan.FromMilliseconds((double)(1000 * AutoSpeedMultiplier));
                        Dojos.Dojo.Refresh();
                        MeditateTimer.Start();
                    }
                }
                catch (Exception e)
                {
                    LogIt.Write($"Error Caught: {e}");
                    throw;
                }
            });
        }

        public virtual void CalculateHealthGain()
        {
            try
            {
                decimal percent = (decimal)decimal.Divide(TotalLevels, ((Punches.Count * 500M) + (Kicks.Count * 500M) + (Defenses.Count * 500M) + (Specials.Count * 500M))) * 100M + 1;
                decimal cubed = (decimal)Math.Pow(Convert.ToDouble(percent), 3);
                HealthGain = percent < 50
                        ? (cubed * (100 - percent) / 50) / 1.5M
                        : percent < 68
                        ? cubed * (150 - percent) / 100 / 1.5M
                        : percent < 98
                        ? cubed * ((1911 - (10 * percent)) / 3) / 500M / 1.5M
                        : cubed * (160 - percent) / 100M / 1.5M;
                LogIt.Write();
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        public virtual void CalculateDefenseGain()
        {
            try
            {
                foreach (Defenses defense in Dojos.Defenses)
                {
                    DefenseGain = defense.Step * Convert.ToDecimal(defense.LevelInt) * 10;
                }
                LogIt.Write();
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        public virtual void CalculateAttackGain()
        {
            try
            {
                decimal total = 0;
                if (Perks[2].Active)
                {
                    foreach (Kicks kick in Dojos.Kicks)
                    {
                        foreach (Punches punch in Dojos.Punches)
                        {
                            total += kick.LevelInt != 0
                                ? total += punch.Step * punch.LevelInt * 2M * .004M * kick.LevelInt
                                : total += punch.Step * punch.LevelInt * 2M;
                        }
                    }
                }
                else
                {
                    foreach (Punches punch in Dojos.Punches)
                    {
                        total += punch.Step * punch.LevelInt;
                    }
                    foreach (Kicks kick in Dojos.Kicks)
                    {
                        if (Perks[0].Active)
                        {
                            total += kick.Step * kick.LevelInt * 1.5M;
                        }
                        else
                        {
                            total += kick.Step * kick.LevelInt;
                        }
                    }
                }
                foreach (Specials special in Dojos.Specials)
                {
                    total += special.Step * 10 * special.LevelInt;
                }

                AttackGain = Perks[4].Active
                    ? total * 1.1M
                    : total;
                LogIt.Write($"With Perk: '{Perks[0].Name}' set to {Perks[0].Active} ; '{Perks[2].Name}' set to {Perks[2].Active} ; '{Perks[4].Name}' set to {Perks[4].Active}");
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }

        }

        public virtual void CalculateExpGain()
        {
            try
            {
                ExpGain = Bonuses && BonusOne > 0
                        ? TotalSteps * TotalLevels * 1.2M * (1 + (.5M * BonusOne)) * ExpGainMultiplier
                        : TotalSteps * TotalLevels * 1.2M * ExpGainMultiplier;
                LogIt.Write($"with EXP Multipliet of {ExpGainMultiplier} and {BonusOne} stack of empty cup bonus.");
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        public virtual void CalculateEnergyGain()
        {
            try
            {
                decimal percent = decimal.Divide(TotalLevels, (Punches.Count * 500M) + (Kicks.Count * 500M) + (Defenses.Count * 500M) + (Specials.Count * 500M)) * 100M + 1;
                decimal cubed = (decimal)Math.Pow(Convert.ToDouble(percent), 3);
                EnergyGain = percent < 50
                        ? cubed * (100 - percent) / 50 / 3 * EnergyGainMultiplier
                        : percent < 68
                        ? cubed * (150 - percent) / 100 / 3 * EnergyGainMultiplier
                        : percent < 98
                        ? cubed * ((1911 - (10 * percent)) / 3) / 500M / 3 * EnergyGainMultiplier
                        : cubed * (160 - percent) / 100M / 3 * EnergyGainMultiplier;
                LogIt.Write($"With Energy Multiplier of {EnergyGainMultiplier}");
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        public virtual void CalculateMeditationEnergyGain()
        {
            try
            {
                decimal percent = decimal.Divide(TotalLevels, (Punches.Count * 500M) + (Kicks.Count * 500M) + (Defenses.Count * 500M) + (Specials.Count * 500M)) * 100M + 1;
                decimal cubed = (decimal)Math.Pow(Convert.ToDouble(percent), 3);
                EnergyMeditationGain = percent < 50
                        ? cubed * (100 - percent) / 50 * EnergyGainMultiplier
                        : percent < 68
                        ? cubed * (150 - percent) / 100 * EnergyGainMultiplier
                        : percent < 98
                        ? cubed * ((1911 - (10 * percent)) / 3) / 500M * EnergyGainMultiplier
                        : cubed * (160 - percent) / 100M * EnergyGainMultiplier;
                LogIt.Write($"With Energy Multiplier of {EnergyGainMultiplier}");
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        public void SpendEnergy(decimal energyCost)
        {
            TotalSteps++;
            TotalLevels++;
            Energy -= energyCost;
            EnergyString = Energy.ConvertToString();
            Dojos.Dojo.Refresh();
        }

        public void SpendExp(decimal expCost)
        {
            TotalLevels++;
            Exp -= expCost;
            ExpString = Exp.ConvertToString();
            Dojos.Dojo.Refresh();
        }
    }
}
