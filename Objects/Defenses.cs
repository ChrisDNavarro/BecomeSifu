using BecomeSifu.Controls;
using BecomeSifu.Logging;
using BecomeSifu.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Media;

namespace BecomeSifu.Objects
{
    public class Defenses
    {
        public Defenses() { }
        public Defenses(string name, int step)
        {
            ActionsViewModel defense = new ActionsViewModel();
            defense.Name = name;
            if (PageHolder.MainWindow.DojoState.Dojo[0].IsBoxing)
            {
                defense.Step = step + 3;
            }
            else
            {
                defense.Step = (step + 1) * 2;
            }

            defense.LevelInt = 0;
            defense.Level = "Lvl " + (defense.LevelInt + 1).ToString();

            defense.ExpToNext = PageHolder.MainWindow.DojoState.Dojo[0].EnergyToUnlock(defense.Step);
            defense.ExpString = defense.ExpToNext.ConvertToString();
            defense.LevelUp = $"Learn\r\n{defense.ExpString} Eng";

            if (step % 2 != 0)
            {
                defense.BackgroundColor = Colors.LightSteelBlue;
                defense.ForegroundColor = Colors.DimGray;
            }
            else
            {
                defense.ForegroundColor = Colors.RoyalBlue;
                defense.BackgroundColor = Colors.Silver;
            }

            PageHolder.MainWindow.DojoState.AddDefense(defense);
        }

        public static void TryLevelUp(ActionsViewModel defense)
        {
            try
            {
                if (!defense.Learned)
                {
                    if (PageHolder.MainWindow.DojoState.Dojo[0].Energy >= defense.ExpToNext)
                    {
                        LogIt.Write($"Learning {defense.Name}");
                        defense.Learned = true;
                        defense.Learning = true;
                        PageHolder.MainWindow.DojoState.Dojo[0].SpendEnergy(defense.ExpToNext);
                        CompleteLevelUp(defense);
                    }
                }
                else
                {
                    if (PageHolder.MainWindow.DojoState.Dojo[0].Exp >= defense.ExpToNext && !defense.MaxLevel)
                    {
                        LogIt.Write($"Leveling up {defense.Name}");
                        PageHolder.MainWindow.DojoState.Dojo[0].SpendExp(defense.ExpToNext);
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
                        if (defense.Learning)
                        {
                            defense.LevelInt++;
                            defense.Learning = false;
                        }
                        else
                        {
                            defense.LevelInt += BoostsController.Boost;
                        }
                    }
                    if (defense.LevelInt == 500)
                    {
                        LogIt.Write($"{defense.Name} has reached Max Level");
                        defense.MaxLevel = true;
                        defense.LevelUp = "Max Level";
                        
                    }
                    else
                    {
                        defense.ExpToNext = PageHolder.MainWindow.DojoState.Dojo[0].AttacksExpToNext(defense.Step, defense.LevelInt);
                        defense.ExpString = defense.ExpToNext.ConvertToString();
                        defense.Level = "Lvl " + defense.LevelInt.ToString();
                        defense.LevelUp = $"Level Up \r\n{defense.ExpString} Exp";
                    }

                    PageHolder.MainWindow.DojoState.Dojo[0].CalculateAll();
                    
                    
                    Extensions.UpdateActives();

                }
                else
                {
                    LogIt.Write($"{defense.Name} is at Max Level");
                    Extensions.SendMessage($"{defense.Name} is at Max Level");
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
