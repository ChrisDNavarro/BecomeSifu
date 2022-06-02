using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace BecomeSifu.Objects
{
    public class Punches : Buttons
    {
        public ICommand LevelUpCommand
        {
            get
            {
                return new RelayCommand(() => TryLevelUp());
            }
        }

        public Punches(string name, int step)
        {
            AttackName = name;
            Step = step + 1;
            LevelInt = 0;
            Level = "Lvl " + (LevelInt + 1).ToString();

            ExpToNext = Dojos.BoundDojo[0].EnergyToUnlock(Step);
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
            if (!Learned)
            {
                if (Dojos.BoundDojo[0].Energy >= ExpToNext)
                {
                    Learned = true;
                    Dojos.BoundDojo[0].TotalSteps++;
                    Dojos.BoundDojo[0].Energy -= ExpToNext;
                    if (Step == 1)
                    {
                        Dojos.Kicks[0].AttackEnabled = true;
                        Dojos.Kicks.Refresh();
                        Dojos.Fights[0].IsActive = true;
                        Dojos.Fights.Refresh();
                    }
                    if (Step == 5 && !Dojos.Defenses[0].Learned)
                    {
                        Dojos.Defenses[0].DefenseEnabled = true;
                        Dojos.Defenses.Refresh();
                    }
                    CompleteLevelUp();
                }
            }
            else
            {
                if (Dojos.BoundDojo[0].Exp >= ExpToNext && !MaxLevel)
                {
                    Dojos.BoundDojo[0].Exp -= ExpToNext;
                    CompleteLevelUp();
                }
            }
        }

        private void CompleteLevelUp()
        {
            if (LevelInt <= 500)
            {
                LevelInt++;

                ExpToNext = Dojos.BoundDojo[0].AttacksExpToNext(Step, LevelInt);
                ExpString = ExpToNext.ConvertToString();

                
                Level = "Lvl " + LevelInt.ToString();

                Dojos.BoundDojo[0].TotalLevels++;

                LevelUp = $"Level Up \r\n{ExpString} Exp";

                Dojos.BoundDojo[0].CalculateAll();

                Dojos.BoundDojo.Refresh();
                Dojos.Punches.Refresh();

                Extensions.UpdateActives();
            }
            else
            {
                MaxLevel = true;
                LevelUp = "Max Level";
                Dojos.Punches.Refresh();
            }
        }
    }
}
