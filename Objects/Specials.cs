using BecomeSifu.Controls;
using BecomeSifu.Logging;
using BecomeSifu.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Media;

namespace BecomeSifu.Objects
{
    public class Specials
    {
        public Specials() { }
        public Specials(string name, int step)
        {
            ActionsViewModel special = new ActionsViewModel();
            special.Name = name;
            special.Step = step + 1;

            special.LevelInt = 0;
            special.Level = "Lvl " + (special.LevelInt + 1).ToString();

            special.ExpToNext = PageHolder.MainWindow.DojoState.Dojo[0].EnergyToUnlock(special.Step);
            special.ExpString = special.ExpToNext.ConvertToString();
            special.LevelUp = $"Learn\r\n{special.ExpString} Eng";

            if (special.Step % 2 == 0)
            {
                special.BackgroundColor = Colors.LightSteelBlue;
                special.ForegroundColor = Colors.DimGray;
            }
            else
            {
                special.ForegroundColor = Colors.RoyalBlue;
                special.BackgroundColor = Colors.Silver;
            }

            PageHolder.MainWindow.DojoState.AddSpecial(special);
        }

        public static void TryLevelUp(ActionsViewModel special)
        {
            try
            {
                if (!special.Learned)
                {
                    if (PageHolder.MainWindow.DojoState.Dojo[0].Energy >= special.ExpToNext)
                    {
                        LogIt.Write($"Learning {special.Name}");
                        special.Learned = true;
                        special.Learning = true;
                        PageHolder.MainWindow.DojoState.Dojo[0].SpendEnergy(special.ExpToNext);
                        
                        CompleteLevelUp(special);
                    }
                }
                else
                {
                    if (PageHolder.MainWindow.DojoState.Dojo[0].Exp >= special.ExpToNext && !special.MaxLevel)
                    {
                        LogIt.Write($"Leveling up {special.Name}");
                        PageHolder.MainWindow.DojoState.Dojo[0].SpendExp(special.ExpToNext);
                        
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
                        if (special.Learning)
                        {
                            special.LevelInt++;
                            special.Learning = false;
                        }
                        else
                        {
                            special.LevelInt += BoostsController.Boost;
                        }
                    }
                    if (special.LevelInt == 500)
                    {
                        LogIt.Write($"{special.Name} has reached Max Level");
                        Extensions.SendMessage($"{special.Name} has reached Max Level");
                        special.MaxLevel = true;
                        special.LevelUp = "Max Level";
                        
                    }
                    else
                    {

                        special.ExpToNext = PageHolder.MainWindow.DojoState.Dojo[0].AttacksExpToNext(special.Step + 1, special.LevelInt);
                        special.ExpString = special.ExpToNext.ConvertToString();
                        special.Level = "Lvl " + special.LevelInt.ToString();
                    }

                    if (PageHolder.MainWindow.DojoState.Dojo[0].Perks[3].Active)
                    {
                        PageHolder.MainWindow.DojoState.Dojo[0].AttackSpeedModifier = .0004M * PageHolder.MainWindow.DojoState.Dojo[0].TotalLevels++;
                    }

                    PageHolder.MainWindow.DojoState.Dojo[0].CalculateAll();

                    
                    

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
