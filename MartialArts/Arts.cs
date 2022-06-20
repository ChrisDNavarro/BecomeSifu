using BecomeSifu.Controls;
using BecomeSifu.MartialArts;
using System;
using System.Collections.Generic;
using System.Text;
using BecomeSifu;
using BecomeSifu.Objects;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;
using System.Windows;
using System.Collections.ObjectModel;
using BecomeSifu.Logging;
using BecomeSifu.ViewModels;
using System.Windows.Media.Animation;
using WpfAnimatedGif;

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

        public List<string> Punches { get; set; } = new List<string>();
        public List<string> Specials { get; set; } = new List<string>();
        public List<string> Kicks { get; set; } = new List<string>();
        public List<string> Defenses { get; set; } = new List<string>();
        public ObservableCollection<Perk> Perks { get; set; } = new ObservableCollection<Perk>();
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
                if (!PageHolder.MainWindow.DojoState.Practice[0].IsMeditating)
                {
                    CalculateEnergyGain();
                    Energy += EnergyGain;
                    PageHolder.MainWindow.DojoState.Practice[0].EnergyString = Energy.ConvertToString();
                    PageHolder.MainWindow.DojoState.Practice[0].EnergyGainString = EnergyGain.ConvertToString();

                    CalculateExpGain();
                    Exp += ExpGain;
                    PageHolder.MainWindow.DojoState.Practice[0].ExpString = Exp.ConvertToString();
                    PageHolder.MainWindow.DojoState.Practice[0].ExpGainString = ExpGain.ConvertToString();

                    CalculateAttackGain();
                    Attack += AttackGain;
                    PageHolder.MainWindow.DojoState.Practice[0].AttackString = Attack.ConvertToString();
                    PageHolder.MainWindow.DojoState.Practice[0].AttackGainString = AttackGain.ConvertToString();

                    CalculateDefenseGain();
                    Defense += DefenseGain;
                    PageHolder.MainWindow.DojoState.Practice[0].DefenseString = Defense.ConvertToString();
                    PageHolder.MainWindow.DojoState.Practice[0].DefenseGainString = DefenseGain.ConvertToString();

                    Extensions.UpdateActives();

                    if (!PageHolder.MainWindow.DojoState.Practice[0].AutoPractice && !PageHolder.MainWindow.DojoState.Practice[0].Practicing )
                    {
                        PageHolder.MainWindow.DojoState.Practice[0].Practicing = true;
                        PageHolder.MainWindow.DojoState.Practice[0].Practiced = RepeatBehavior.Forever;
                        PageHolder.MainWindow.DojoState.Practice[0].Practiced = new RepeatBehavior(1);
                    }

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
                PageHolder.MainWindow.DojoState.Practice[0].EnergyGainString = EnergyGain.ConvertToString();

                CalculateMeditationEnergyGain();
                PageHolder.MainWindow.DojoState.Practice[0].EnergyMeditationGainString = EnergyMeditationGain.ConvertToString();

                CalculateExpGain();
                PageHolder.MainWindow.DojoState.Practice[0].ExpGainString = ExpGain.ConvertToString();

                CalculateAttackGain();
                PageHolder.MainWindow.DojoState.Practice[0].AttackGainString = AttackGain.ConvertToString();

                CalculateDefenseGain();
                PageHolder.MainWindow.DojoState.Practice[0].DefenseGainString = DefenseGain.ConvertToString();

                CalculateHealthGain();
                PageHolder.MainWindow.DojoState.Practice[0].HealthGainString = HealthGain.ConvertToString();
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

                foreach (ActionsViewModel punch in PageHolder.MainWindow.DojoState.Punches)
                {
                    if (punch.LevelInt == 500)
                    {
                        maxed++;
                    }
                }
                foreach (ActionsViewModel kick in PageHolder.MainWindow.DojoState.Kicks)
                {
                    if (kick.LevelInt == 500)
                    {
                        maxed++;
                    }
                }
                foreach (ActionsViewModel special in PageHolder.MainWindow.DojoState.Specials)
                {
                    if (special.LevelInt == 500)
                    {
                        maxed++;
                    }
                }
                foreach (ActionsViewModel def in PageHolder.MainWindow.DojoState.Defenses)
                {
                    if (def.LevelInt == 500)
                    {
                        maxed++;
                    }
                }
                LogIt.Write();
                return maxed == PageHolder.MainWindow.DojoState.Punches.Count + PageHolder.MainWindow.DojoState.Kicks.Count + PageHolder.MainWindow.DojoState.Specials.Count + PageHolder.MainWindow.DojoState.Defenses.Count;
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
                if (PageHolder.MainWindow.DojoState.Practice[0].IsMeditating)
                {
                    LogIt.Write($"Stop");
                    PageHolder.MainWindow.DojoState.Practice[0].IsMeditating = !PageHolder.MainWindow.DojoState.Practice[0].IsMeditating;
                    PageHolder.MainWindow.DojoState.Practice[0].IsMeditatingString = "Start Meditating";
                    PageHolder.MainWindow.DojoState.Practice[0].MeditateOption = Visibility.Collapsed;
                    MeditateTimer.Stop();
                    PageHolder.MainWindow.DojoState.Practice[0].AutoMeditate = false;
                    
                    Extensions.UpdateActives();
                }
                else
                {
                    LogIt.Write($"Start");
                    PageHolder.MainWindow.DojoState.Practice[0].IsMeditating = !PageHolder.MainWindow.DojoState.Practice[0].IsMeditating;
                    PageHolder.MainWindow.DojoState.Practice[0].IsMeditatingString = "Stop Meditating";
                    PageHolder.MainWindow.DojoState.Practice[0].MeditateOption = Visibility.Visible;
                    
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
                    PageHolder.MainWindow.DojoState.Practice[0].Repeat = RepeatBehavior.Forever;
                    CalculateHealthGain();
                    Health += HealthGain * 1.5M;
                    PageHolder.MainWindow.DojoState.Practice[0].HealthString = Health.ConvertToString();
                    PageHolder.MainWindow.DojoState.Practice[0].HealthGainString = (HealthGain * 1.5M).ConvertToString();

                    CalculateMeditationEnergyGain();
                    Energy += EnergyMeditationGain * 1.5M;
                    PageHolder.MainWindow.DojoState.Practice[0].EnergyString = Energy.ConvertToString();
                    PageHolder.MainWindow.DojoState.Practice[0].EnergyMeditationGainString = (EnergyMeditationGain * 1.5M).ConvertToString();

                    PageHolder.MainWindow.DojoState.Practice[0].Repeat = new RepeatBehavior(1);
                }
                else
                {
                    PageHolder.MainWindow.DojoState.Practice[0].Repeat = RepeatBehavior.Forever;

                    CalculateHealthGain();
                    Health += HealthGain;
                    PageHolder.MainWindow.DojoState.Practice[0].HealthString = Health.ConvertToString();
                    PageHolder.MainWindow.DojoState.Practice[0].HealthGainString = HealthGain.ConvertToString();

                    CalculateMeditationEnergyGain();
                    Energy += EnergyMeditationGain;
                    PageHolder.MainWindow.DojoState.Practice[0].EnergyString = Energy.ConvertToString();
                    PageHolder.MainWindow.DojoState.Practice[0].EnergyMeditationGainString = EnergyMeditationGain.ConvertToString();

                    PageHolder.MainWindow.DojoState.Practice[0].Repeat = new RepeatBehavior(1);
                }

                
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

                    if (PageHolder.MainWindow.DojoState.Practice[0].AutoPractice)
                    {
                        LogIt.Write($"Stop");
                        PageHolder.MainWindow.DojoState.Practice[0].AutoPractice = !PageHolder.MainWindow.DojoState.Practice[0].AutoPractice;
                        PageHolder.MainWindow.DojoState.Practice[0].Rate = "Auto";
                        PageHolder.MainWindow.DojoState.Practice[0].Practiced = new RepeatBehavior(1);
                        Timer.Stop();
                        
                    }
                    else
                    {
                        LogIt.Write($"Start");
                        PageHolder.MainWindow.DojoState.Practice[0].AutoPractice = !PageHolder.MainWindow.DojoState.Practice[0].AutoPractice;
                        PageHolder.MainWindow.DojoState.Practice[0].Rate = (1 / AutoSpeedMultiplier).ConvertToString() + " click(s)/s";
                        Timer.Tick += Timer_Tick;
                        Timer.Interval = TimeSpan.FromMilliseconds((double)(1000 * AutoSpeedMultiplier));
                        PageHolder.MainWindow.DojoState.Practice[0].Practiced = RepeatBehavior.Forever;
                        Timer.Start();
                        
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
            if (!PageHolder.MainWindow.DojoState.Practice[0].IsMeditating)
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
                    if (PageHolder.MainWindow.DojoState.Practice[0].AutoMeditate)
                    {
                        LogIt.Write($"Stop");
                        PageHolder.MainWindow.DojoState.Practice[0].AutoMeditate = !PageHolder.MainWindow.DojoState.Practice[0].AutoMeditate;
                        PageHolder.MainWindow.DojoState.Practice[0].Rate = "Auto";
                        
                        MeditateTimer.Stop();
                        
                    }
                    else
                    {
                        LogIt.Write($"Start");
                        PageHolder.MainWindow.DojoState.Practice[0].AutoMeditate = !PageHolder.MainWindow.DojoState.Practice[0].AutoMeditate;
                        PageHolder.MainWindow.DojoState.Practice[0].Rate = (1 / AutoSpeedMultiplier).ConvertToString() + " click(s)/s";
                        MeditateTimer.Tick += MeditateTimer_Tick;
                        MeditateTimer.Interval = TimeSpan.FromMilliseconds((double)(1000 * AutoSpeedMultiplier));
                        
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
                foreach (ActionsViewModel defense in PageHolder.MainWindow.DojoState.Defenses)
                {
                    DefenseGain += defense.Step * Convert.ToDecimal(defense.LevelInt) * .1M;
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
                    foreach (ActionsViewModel kick in PageHolder.MainWindow.DojoState.Kicks)
                    {
                        foreach (ActionsViewModel punch in PageHolder.MainWindow.DojoState.Punches)
                        {
                            total += kick.LevelInt != 0
                                ? total += punch.Step * punch.LevelInt * 2M * .004M * kick.LevelInt
                                : total += punch.Step * punch.LevelInt * 2M;
                        }
                    }
                }
                else
                {
                    foreach (ActionsViewModel punch in PageHolder.MainWindow.DojoState.Punches)
                    {
                        total += punch.Step * punch.LevelInt;
                    }
                    foreach (ActionsViewModel kick in PageHolder.MainWindow.DojoState.Kicks)
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
                foreach (ActionsViewModel special in PageHolder.MainWindow.DojoState.Specials)
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
            PageHolder.MainWindow.DojoState.Practice[0].EnergyString = Energy.ConvertToString();
            
        }

        public void SpendExp(decimal expCost)
        {
            TotalLevels++;
            Exp -= expCost;
            PageHolder.MainWindow.DojoState.Practice[0].ExpString = Exp.ConvertToString();
            
        }
    }
}
