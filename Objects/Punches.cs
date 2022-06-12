using BecomeSifu.Controls;
using BecomeSifu.Logging;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace BecomeSifu.Objects
{
    public class Punches : Buttons
    {
        public ICommand LevelUpCommand => new RelayCommand(() => TryLevelUp());

        public Punches(string name, int step)
        {
            AttackName = name;
            Step = step + 1;
            LevelInt = 0;
            Level = "Lvl " + (LevelInt + 1).ToString();

            ExpToNext = Dojos.Dojo[0].EnergyToUnlock(Step);
            ExpString = ExpToNext.ConvertToString();
            LevelUp = $"Learn\r\n{ExpString} Eng";

            if(Step == 1)
            {
                AttackEnabled = true;
            }

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

                        Dojos.Dojo[0].SpendEnergy(ExpToNext);

                        if (Step == 1)
                        {
                            if (Dojos.Dojo[0].Energy >= Dojos.Kicks[0].ExpToNext)
                            {
                                Dojos.Kicks[0].AttackEnabled = true;
                                Dojos.Kicks.Refresh();
                            }
                            Dojos.Fights[0].IsActive = true;
                            Dojos.Fights.Refresh();
                            Extensions.CreateMessage("Kicks", false);
                            Extensions.CreateMessage("Street Fight", true);
                        }
                        if (Step == 5 && !Dojos.Defenses[0].Learned)
                        {
                            Dojos.Defenses[0].DefenseEnabled = true;
                            Dojos.Defenses.Refresh();
                            Extensions.CreateMessage("Defense", true);
                        }
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
                        Dojos.Punches.Refresh();
                    }

                    LevelUpExp();

                    Level = "Lvl " + LevelInt.ToString();

                    LevelUp = $"Level Up \r\n{ExpString} Exp";

                    Dojos.Dojo[0].CalculateAll();

                    Dojos.Dojo.Refresh();
                    

                    Dojos.Punches.Refresh();

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

        public void LevelUpExp()
        {
            if (Learned)
            {
                ExpToNext = Dojos.Dojo[0].AttacksExpToNext(Step, LevelInt);
                ExpString = ExpToNext.ConvertToString();
                Extensions.UpdateActives();
                Dojos.Punches.Refresh();
            }
        }


    }
}
