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
    public class Kicks : Buttons
    {
        public ICommand LevelUpCommand
        {
            get
            {
                return new RelayCommand(() => TryLevelUp());
            }
        }
        public Kicks(string name, int step)
        {
            AttackName = name;
            if (Dojos.Dojo[0].IsBoxing)
            {
                Step = 10;
            }
            else
            {
                Step = step + 1;
            }

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
                        if (Step >= Dojos.Kicks.Count)
                        {
                            AllKicks = true;
                        }
                        if (Step == 1)
                        {
                            if (Dojos.Dojo[0].Perks[1].Active)
                            {
                                Dojos.Specials[0].AttackEnabled = true;
                                Dojos.Specials.Refresh();
                                Extensions.CreateMessage("Tae Kwon Do Specials", false);
                            }
                            Dojos.Fights[1].IsActive = true;
                            Dojos.Fights.Refresh();
                            Extensions.CreateMessage("Tournament", true);
                        }
                        if (Step == 5 && !Dojos.Defenses[0].Learned)
                        {
                            Dojos.Defenses[0].DefenseEnabled = true;
                            Dojos.Defenses.Refresh();
                            Extensions.CreateMessage("Defense", true);
                        }
                        Dojos.Dojo[0].SpendEnergy(ExpToNext);
                        CompleteLevelUp();
                    }
                }
                else
                {
                    if (Dojos.Dojo[0].Exp >= ExpToNext && !MaxLevel)
                    {
                        LogIt.Write($"Leveling up {AttackName}");
                        Dojos.Dojo[0].SpendExp(ExpToNext);
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
                        Dojos.Kicks.Refresh();
                    }



                    Level = "Lvl " + LevelInt.ToString();

                    Dojos.Dojo[0].TotalLevels++;

                    LevelUp = $"Level Up \r\n{ExpString} Exp";



                    Dojos.Dojo.Refresh();
                    Dojos.Kicks.Refresh();

                    LevelUpExp();
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

        public void LevelUpExp()
        {
            ExpToNext = Dojos.Dojo[0].AttacksExpToNext(Step, LevelInt);
            ExpString = ExpToNext.ConvertToString();
            Extensions.UpdateActives();
            Dojos.Kicks.Refresh();
            
        }

    }
}
