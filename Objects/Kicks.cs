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
    public class Kicks
    {
        public Kicks(string name, int step)
        {
            ActionsViewModel kick = new ActionsViewModel();
            kick.Name = name;
            if (Dojos.Dojo[0].IsBoxing)
            {
                kick.Step = 10;
            }
            else
            {
                kick.Step = step + 1;
            }

            kick.LevelInt = 0;
            kick.Level = "Lvl " + kick.LevelInt.ToString();

            kick.ExpToNext = Dojos.Dojo[0].EnergyToUnlock(kick.Step);
            kick.ExpString = kick.ExpToNext.ConvertToString();
            kick.LevelUp = $"Learn\r\n{kick.ExpString} Eng";

            if (kick.Step % 2 == 0)
            {
                kick.BackgroundColor = new SolidColorBrush(Colors.LightSteelBlue);
                kick.ForegroundColor = new SolidColorBrush(Colors.DimGray);
            }
            else
            {
                kick.ForegroundColor = new SolidColorBrush(Colors.RoyalBlue);
                kick.BackgroundColor = new SolidColorBrush(Colors.Silver);
            }


            Dojos.AddKick(kick);
        }

        public static void TryLevelUp(ActionsViewModel kick)
        {
            try
            {
                if (!kick.Learned)
                {
                    if (Dojos.Dojo[0].Energy >= kick.ExpToNext)
                    {
                        LogIt.Write($"Learning {kick.Name}");
                        kick.Learned = true;
                        if (kick.Step == 1)
                        {
                            if (Dojos.Dojo[0].Perks[1].Active)
                            {
                                Dojos.Specials[0].Enabled = true;
                                Dojos.Specials.Refresh();
                                Extensions.CreateMessage("Tae Kwon Do Specials", false);
                            }
                            Dojos.Fights[1].IsActive = true;
                            Dojos.Fights.Refresh();
                            Extensions.CreateMessage("Tournament", true);
                        }
                        if (kick.Step == 5 && !Dojos.Defenses[0].Learned)
                        {
                            Dojos.Defenses[0].Enabled = true;
                            Dojos.Defenses.Refresh();
                            Extensions.CreateMessage("Defense", true);
                        }
                        Dojos.Dojo[0].SpendEnergy(kick.ExpToNext);
                        CompleteLevelUp(kick);
                    }
                }
                else
                {
                    if (Dojos.Dojo[0].Exp >= kick.ExpToNext && !kick.MaxLevel)
                    {
                        LogIt.Write($"Leveling up {kick.Name}");
                        Dojos.Dojo[0].SpendExp(kick.ExpToNext);
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
                        kick.LevelInt += BoostsController.Boost;
                    }
                    if (kick.LevelInt == 500)
                    {
                        LogIt.Write($"{kick.Name} has reached Max Level");
                        Extensions.SendMessage($"kick.{kick.Name} has reached Max Level");
                        kick.MaxLevel = true;
                        kick.LevelUp = "Max Level";
                        Dojos.Kicks.Refresh();
                    }



                    kick.Level = "Lvl " + kick.LevelInt.ToString();

                    Dojos.Dojo[0].TotalLevels++;

                    kick.LevelUp = $"Level Up \r\n{kick.ExpString} Exp";



                    Dojos.Dojo.Refresh();
                    Dojos.Kicks.Refresh();

                    LevelUpExp(kick);
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
            kick.ExpToNext = Dojos.Dojo[0].AttacksExpToNext(kick.Step, kick.LevelInt);
            kick.ExpString = kick.ExpToNext.ConvertToString();
            Extensions.UpdateActives();
            Dojos.Kicks.Refresh();            
        }

    }
}
