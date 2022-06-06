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
            if (!Learned)
            {
                if (Dojos.Dojo[0].Energy >= ExpToNext)
                {
                    Learned = true;
                    Dojos.Dojo[0].TotalSteps++;
                    if(Step >= Dojos.Kicks.Count)
                    {
                        AllKicks = true;
                    }
                    if (Step == 1)
                    {
                        if (Dojos.Dojo[0].IsTaekwondo)
                        {
                            Dojos.Specials[0].AttackEnabled = true;
                            Dojos.Specials.Refresh();
                        }
                        Dojos.Fights[1].IsActive = true;
                        Dojos.Fights.Refresh(); 
                    }
                    if (Step == 5 && !Dojos.Defenses[0].Learned)
                    {
                        Dojos.Defenses[0].DefenseEnabled = true;
                        Dojos.Defenses.Refresh();
                    }
                    Dojos.Dojo[0].Energy -= ExpToNext;
                    Dojos.Dojo.Refresh();
                    CompleteLevelUp();
                }
            }
            else
            {
                if (Dojos.Dojo[0].Exp >= ExpToNext && !MaxLevel)
                {
                    Dojos.Dojo[0].Exp -= ExpToNext;
                    Dojos.Dojo.Refresh();
                    CompleteLevelUp();
                }
            }
        }

        private void CompleteLevelUp()
        {
            if (LevelInt <= 500)
            {
                LevelInt++;
                ExpToNext = Dojos.Dojo[0].AttacksExpToNext(Step, LevelInt);
                ExpString = ExpToNext.ConvertToString();

                
                Level = "Lvl " + LevelInt.ToString();

                Dojos.Dojo[0].TotalLevels++;

                LevelUp = $"Level Up \r\n{ExpString} Exp";



                Dojos.Dojo.Refresh();
                Dojos.Punches.Refresh();

                Extensions.UpdateActives();
            }
            else
            {
                MaxLevel = true;
                LevelUp = "Max Level";
                Dojos.Kicks.Refresh();
            }
        }

    }
}
