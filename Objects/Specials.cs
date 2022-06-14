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
    public class Specials
    {
        public Specials(string name, int step)
        {
            ActionsViewModel special = new ActionsViewModel();
            special.Name = name;
            special.Step = step + 1;

            special.LevelInt = 0;
            special.Level = "Lvl " + (special.LevelInt + 1).ToString();

            special.ExpToNext = Dojos.Dojo[0].EnergyToUnlock(special.Step);
            special.ExpString = special.ExpToNext.ConvertToString();
            special.LevelUp = $"Learn\r\n{special.ExpString} Eng";

            if (special.Step % 2 == 0)
            {
                special.BackgroundColor = new SolidColorBrush(Colors.LightSteelBlue);
                special.ForegroundColor = new SolidColorBrush(Colors.DimGray);
            }
            else
            {
                special.ForegroundColor = new SolidColorBrush(Colors.RoyalBlue);
                special.BackgroundColor = new SolidColorBrush(Colors.Silver);
            }

            Dojos.AddSpecial(special);
        }

        public static void TryLevelUp(ActionsViewModel special)
        {
            try
            {
                if (!special.Learned)
                {
                    if (Dojos.Dojo[0].Energy >= special.ExpToNext)
                    {
                        LogIt.Write($"Learning {special.Name}");
                        special.Learned = true;
                        Dojos.Dojo[0].TotalSteps++;
                        Dojos.Dojo[0].Energy -= special.ExpToNext;
                        Dojos.Dojo.Refresh();
                        CompleteLevelUp(special);
                    }
                }
                else
                {
                    if (Dojos.Dojo[0].Exp >= special.ExpToNext && !special.MaxLevel)
                    {
                        LogIt.Write($"Leveling up {special.Name}");
                        Dojos.Dojo[0].Exp -= special.ExpToNext;
                        Dojos.Dojo.Refresh();
                        CompleteLevelUp(special);
                    }
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        private static void CompleteLevelUp(ActionsViewModel special)
        {
            try
            {
                if (special.LevelInt <= 500)
                {
                    if (500 - special.LevelInt <= BoostsController.Boost)
                    {
                        special.LevelInt = 500;
                    }
                    else
                    {
                        special.LevelInt += BoostsController.Boost;
                    }
                    if (special.LevelInt == 500)
                    {
                        LogIt.Write($"{special.Name} has reached Max Level");
                        Extensions.SendMessage($"{special.Name} has reached Max Level");
                        special.MaxLevel = true;
                        special.LevelUp = "Max Level";
                        Dojos.Specials.Refresh();
                    }

                    special.ExpToNext = Dojos.Dojo[0].AttacksExpToNext(special.Step + 1, special.LevelInt);
                    special.ExpString = special.ExpToNext.ConvertToString();


                    special.Level = "Lvl " + special.LevelInt.ToString();

                    Dojos.Dojo[0].TotalLevels++;
                    if (Dojos.Dojo[0].Perks[3].Active)
                    {
                        Dojos.Dojo[0].AttackSpeedModifier = .0004M * Dojos.Dojo[0].TotalLevels++;
                    }
                    special.LevelUp = $"Level Up \r\n{special.ExpString} Exp";
                    Dojos.Dojo.Refresh();
                    Dojos.Specials.Refresh();

                    Extensions.UpdateActives();
                }
                else
                {
                    LogIt.Write($"{special.Name} is at Max Level");
                    Extensions.SendMessage($"{special.Name} is at Max Level");
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
