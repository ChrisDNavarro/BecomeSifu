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
    public class Defenses : Buttons
    {
        public ICommand LevelUpCommand => new RelayCommand(() => TryLevelUp());
        public string DefenseName { get; set; }
        public bool DefenseEnabled { get; set; }

        public Defenses(string name, int step)
        {
            DefenseName = name;
            if (Dojos.Dojo[0].IsBoxing)
            {
                Step = step + 3;
            }
            else
            {
                Step = (step + 1) * 2;
            }

            LevelInt = 0;
            Level = "Lvl " + (LevelInt + 1).ToString();

            ExpToNext = Dojos.Dojo[0].EnergyToUnlock(Step);
            ExpString = ExpToNext.ConvertToString();
            LevelUp = $"Learn\r\n{ExpString} Eng";

            if (step % 2 != 0)
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
                        LogIt.Write($"Learning {DefenseName}");
                        Learned = true;
                        Dojos.Dojo[0].TotalSteps++;
                        if (Step >= Dojos.Defenses.Count)
                        {
                            AllDefense = true;
                        }
                        Dojos.Dojo[0].Energy -= ExpToNext;
                        CompleteLevelUp();
                    }
                }
                else
                {
                    if (Dojos.Dojo[0].Exp >= ExpToNext && !MaxLevel)
                    {
                        LogIt.Write($"Leveling up {DefenseName}");
                        Dojos.Dojo[0].Exp -= ExpToNext;
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
                        LogIt.Write($"{DefenseName} has reached Max Level");
                        MaxLevel = true;
                        LevelUp = "Max Level";
                        Dojos.Defenses.Refresh();
                    }


                    ExpToNext = Dojos.Dojo[0].AttacksExpToNext(Step, LevelInt);
                    ExpString = ExpToNext.ConvertToString();


                    Level = "Lvl " + LevelInt.ToString();

                    Dojos.Dojo[0].TotalLevels++;
                    LevelUp = $"Level Up \r\n{ExpString} Exp";
                    Dojos.Dojo.Refresh();
                    Dojos.Defenses.Refresh();
                    Extensions.UpdateActives();

                }
                else
                {
                    LogIt.Write($"{DefenseName} is at Max Level");

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
