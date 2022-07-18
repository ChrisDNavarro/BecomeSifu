using BecomeSifu.Controls;
using BecomeSifu.Logging;
using BecomeSifu.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Media;

namespace BecomeSifu.Objects
{
    public class Kicks
    {
        public Kicks()
        {

        }
        public Kicks(string name, int step)
        {
            ActionsViewModel kick = new ActionsViewModel();
            kick.Name = name;
            if (PageHolder.MainWindow.DojoState.Dojo[0].IsBoxing)
            {
                kick.Step = 10;
            }
            else
            {
                kick.Step = step + 1;
            }

            kick.LevelInt = 0;
            kick.Level = "Lvl " + kick.LevelInt.ToString();

            kick.ExpToNext = PageHolder.MainWindow.DojoState.Dojo[0].EnergyToUnlock(kick.Step);
            kick.ExpString = kick.ExpToNext.ConvertToString();
            kick.LevelUp = $"Learn\r\n{kick.ExpString} Eng";

            if (kick.Step % 2 == 0)
            {
                kick.BackgroundColor = Colors.LightSteelBlue;
                kick.ForegroundColor = Colors.DimGray;
            }
            else
            {
                kick.ForegroundColor = Colors.RoyalBlue;
                kick.BackgroundColor = Colors.Silver;
            }


            PageHolder.MainWindow.DojoState.AddKick(kick);
        }

        public static void TryLevelUp(ActionsViewModel kick)
        {
            try
            {
                if (!kick.Learned)
                {
                    if (PageHolder.MainWindow.DojoState.Dojo[0].Energy >= kick.ExpToNext)
                    {
                        LogIt.Write($"Learning {kick.Name}");
                        kick.Learned = true;
                        kick.Learning = true;
                        if (kick.Step == 1)
                        {
                            if (PageHolder.MainWindow.DojoState.Dojo[0].Perks[1].Active)
                            {
                                PageHolder.MainWindow.DojoState.Specials[0].Enabled = true;
                                
                                Extensions.CreateMessage("Specials Tae Kwon Do", false);
                            }
                            Extensions.CreateMessage("Tournament", true);
                        }
                        if (kick.Step == 5 && !PageHolder.MainWindow.DojoState.Defenses[0].Learned)
                        {
                            PageHolder.MainWindow.DojoState.Defenses[0].Enabled = true;

                            Extensions.CreateMessage("Defense", true);
                        }
                        if (!PageHolder.MainWindow.DojoState.FightsVMs[1].IsActive)
                        {
                            PageHolder.MainWindow.DojoState.FightsVMs[1].IsActive = true;
                        }
                        PageHolder.MainWindow.DojoState.Dojo[0].SpendEnergy(kick.ExpToNext);
                        CompleteLevelUp(kick);
                    }
                }
                else
                {
                    if (PageHolder.MainWindow.DojoState.Dojo[0].Exp >= kick.ExpToNext && !kick.MaxLevel)
                    {
                        LogIt.Write($"Leveling up {kick.Name}");
                        PageHolder.MainWindow.DojoState.Dojo[0].SpendExp(kick.ExpToNext);
                        CompleteLevelUp(kick);
                    }
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        private static void CompleteLevelUp(ActionsViewModel kick)
        {
            try
            {
                if (kick.LevelInt <= 500)
                {
                    if (500 - kick.LevelInt <= BoostsController.Boost)
                    {
                        kick.LevelInt = 500;
                    }
                    else
                    {
                        if (kick.Learning)
                        {
                            kick.LevelInt++;
                            kick.Learning = false;
                        }
                        else
                        {
                            kick.LevelInt += BoostsController.Boost;
                        }
                    }
                    if (kick.LevelInt == 500)
                    {
                        LogIt.Write($"{kick.Name} has reached Max Level");
                        Extensions.SendMessage($"kick.{kick.Name} has reached Max Level");
                        kick.MaxLevel = true;
                        kick.LevelUp = "Max Level";
                        
                    }
                    else
                    {
                        LevelUpExp(kick);

                        kick.Level = "Lvl " + kick.LevelInt.ToString();

                        kick.LevelUp = $"Level Up \r\n{kick.ExpString} Exp";
                    }

                    
                                        
                }
                else
                {
                    LogIt.Write($"{kick.Name} is at Max Level");
                    Extensions.SendMessage($"{kick.Name} is at Max Level");
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        public static void LevelUpExp(ActionsViewModel kick)
        {
            kick.ExpToNext = PageHolder.MainWindow.DojoState.Dojo[0].AttacksExpToNext(kick.Step, kick.LevelInt);
            kick.ExpString = kick.ExpToNext.ConvertToString();
            Extensions.UpdateActives();
                        
        }

    }
}
