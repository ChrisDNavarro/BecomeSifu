using BecomeSifu.Controls;
using BecomeSifu.Logging;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace BecomeSifu.Objects
{
    public class Specials : Buttons
    {
        public ICommand LevelUpCommand
        {
            get
            {
                return new RelayCommand(() => TryLevelUp());
            }
        }
        public Specials(string name, int step)
        {
            AttackName = name;
            Step = step + 1;

            LevelInt = 0;
            Level = "Lvl " + (LevelInt + 1).ToString();

            ExpToNext = Dojos.Dojo[0].EnergyToUnlock(Step);
            ExpString = ExpToNext.ConvertToString();
            LevelUp = $"Learn\r\n{ExpString} Eng";

            if (Step % 2 == 0)
            {
                BackgroundColor = new SolidColorBrush(Colors.LightSteelBlue);
                ForegroundColor = new SolidColorBrush(Colors.DimGray);
            }
            else
            {
                ForegroundColor = new SolidColorBrush(Colors.RoyalBlue);
                BackgroundColor = new SolidColorBrush(Colors.Silver);
            }
        }

        public void TryLevelUp()
        {
            try
            {
                if (!Learned)
                {
                    if (Dojos.Dojo[0].Energy >= ExpToNext)
                    {
                        LogIt.Write($"Learning {AttackName}");
                        Learned = true;
                        Dojos.Dojo[0].TotalSteps++;
                        Dojos.Dojo[0].Energy -= ExpToNext;
                        Dojos.Dojo.Refresh();
                        CompleteLevelUp();
                    }
                }
                else
                {
                    if (Dojos.Dojo[0].Exp >= ExpToNext && !MaxLevel)
                    {
                        LogIt.Write($"Leveling up {AttackName}");
                        Dojos.Dojo[0].Exp -= ExpToNext;
                        Dojos.Dojo.Refresh();
                        CompleteLevelUp();
                    }
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        private void CompleteLevelUp()
        {
            try
            {
                if (LevelInt <= 500)
                {
                    if (500 - LevelInt <= BoostsController.Boost)
                    {
                        LevelInt = 500;
                    }
                    else
                    {
                        LevelInt += BoostsController.Boost;
                    }
                    if (LevelInt == 500)
                    {
                        LogIt.Write($"{AttackName} has reached Max Level");
                        Extensions.SendMessage($"{AttackName} has reached Max Level");
                        MaxLevel = true;
                        LevelUp = "Max Level";
                        Dojos.Specials.Refresh();
                    }

                    ExpToNext = Dojos.Dojo[0].AttacksExpToNext(Step + 1, LevelInt);
                    ExpString = ExpToNext.ConvertToString();


                    Level = "Lvl " + LevelInt.ToString();

                    Dojos.Dojo[0].TotalLevels++;
                    if (Dojos.Dojo[0].Perks[3].Active)
                    {
                        Dojos.Dojo[0].AttackSpeedModifier = .0004M * Dojos.Dojo[0].TotalLevels++;
                    }
                    LevelUp = $"Level Up \r\n{ExpString} Exp";
                    Dojos.Dojo.Refresh();
                    Dojos.Specials.Refresh();

                    Extensions.UpdateActives();
                }
                else
                {
                    LogIt.Write($"{AttackName} is at Max Level");
                    Extensions.SendMessage($"{AttackName} is at Max Level");
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

    }
}
