using BecomeSifu.Controls;
using BecomeSifu.Logging;
using BecomeSifu.ViewModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace BecomeSifu.Objects
{
    public class Defenses
    {
        public Defenses(string name, int step)
        {
            ActionsViewModel defense = new ActionsViewModel();
            defense.Name = name;
            if (Dojos.Dojo[0].IsBoxing)
            {
                defense.Step = step + 3;
            }
            else
            {
                defense.Step = (step + 1) * 2;
            }

            defense.LevelInt = 0;
            defense.Level = "Lvl " + (defense.LevelInt + 1).ToString();

            defense.ExpToNext = Dojos.Dojo[0].EnergyToUnlock(defense.Step);
            defense.ExpString = defense.ExpToNext.ConvertToString();
            defense.LevelUp = $"Learn\r\n{defense.ExpString} Eng";

            if (step % 2 != 0)
            {
                defense.BackgroundColor = new SolidColorBrush(Colors.LightSteelBlue);
                defense.ForegroundColor = new SolidColorBrush(Colors.DimGray);
            }
            else
            {
                defense.ForegroundColor = new SolidColorBrush(Colors.RoyalBlue);
                defense.BackgroundColor = new SolidColorBrush(Colors.Silver);
            }

            Dojos.AddDefense(defense);
        }

        public static void TryLevelUp(ActionsViewModel defense)
        {
            try
            {
                if (!defense.Learned)
                {
                    if (Dojos.Dojo[0].Energy >= defense.ExpToNext)
                    {
                        LogIt.Write($"Learning {defense.Name}");
                        defense.Learned = true;
                        Dojos.Dojo[0].TotalSteps++;
                        Dojos.Dojo[0].Energy -= defense.ExpToNext;
                        CompleteLevelUp(defense);
                    }
                }
                else
                {
                    if (Dojos.Dojo[0].Exp >= defense.ExpToNext && !defense.MaxLevel)
                    {
                        LogIt.Write($"Leveling up {defense.Name}");
                        Dojos.Dojo[0].Exp -= defense.ExpToNext;
                        CompleteLevelUp(defense);
                    }
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        private static void CompleteLevelUp(ActionsViewModel defense)
        {
            try
            {
                if (defense.LevelInt <= 500)
                {
                    if (500 - defense.LevelInt <= BoostsController.Boost)
                    {
                        defense.LevelInt = 500;
                    }
                    else
                    {
                        defense.LevelInt += BoostsController.Boost;
                    }
                    if (defense.LevelInt == 500)
                    {
                        LogIt.Write($"{defense.Name} has reached Max Level");
                        defense.MaxLevel = true;
                        defense.LevelUp = "Max Level";
                        Dojos.Defenses.Refresh();
                    }


                    defense.ExpToNext = Dojos.Dojo[0].AttacksExpToNext(defense.Step, defense.LevelInt);
                    defense.ExpString = defense.ExpToNext.ConvertToString();


                    defense.Level = "Lvl " + defense.LevelInt.ToString();

                    Dojos.Dojo[0].TotalLevels++;
                    defense.LevelUp = $"Level Up \r\n{defense.ExpString} Exp";
                    Dojos.Dojo.Refresh();
                    Dojos.Defenses.Refresh();
                    Extensions.UpdateActives();

                }
                else
                {
                    LogIt.Write($"{defense.Name} is at Max Level");

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
