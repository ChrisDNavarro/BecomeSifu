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
            if (Dojos.BoundDojo[0].IsBoxing)
            {
                Step = 10;
            }
            else
            {
                Step = step + 1;
            }

            LevelInt = 0;
            Level = "Lvl " + (LevelInt + 1).ToString();

            ExpToNext = Dojos.BoundDojo[0].EnergyToUnlock(Step);
            ExpString = ExpToNext.ConvertToString();
            LevelUp = $"Learn\r\n{ExpString} Eng";

            if (Step % 2 == 0)
            {
                BackgroundColor = new SolidColorBrush(Colors.IndianRed);
                ForegroundColor = new SolidColorBrush(Colors.PaleGoldenrod);
            }
            else
            {
                ForegroundColor = new SolidColorBrush(Colors.IndianRed);
                BackgroundColor = new SolidColorBrush(Colors.PaleGoldenrod);
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
                    if(Step >= Dojos.Kicks.Count)
                    {
                        AllKicks = true;
                    }
                    Dojos.BoundDojo[0].Energy -= ExpToNext;
                    Dojos.BoundDojo.Refresh();
                    CompleteLevelUp();
                }
            }
            else
            {
                if (Dojos.BoundDojo[0].Exp >= ExpToNext && !MaxLevel)
                {
                    Dojos.BoundDojo[0].Exp -= ExpToNext;
                    Dojos.BoundDojo.Refresh();
                    CompleteLevelUp();
                }
            }
        }

        private void CompleteLevelUp()
        {
            if (LevelInt <= 500)
            {
                

                ExpToNext = Dojos.BoundDojo[0].AttacksExpToNext(Step, LevelInt);
                ExpString = ExpToNext.ConvertToString();

                LevelInt++;
                Level = "Lvl " + LevelInt.ToString();

                Dojos.BoundDojo[0].TotalLevels++;

                if (Step != 1 && Step <Dojos.Kicks.Count && Dojos.Kicks[Step].AttackEnabled && Convert.ToInt32(Level) >= 5)
                {
                    Dojos.Kicks[Step].AttackEnabled = true;
                }

                if (Step % 2 == 0 && Step / 2 < +Dojos.Defenses.Count && !Dojos.Defenses[Step - (Step / 2 - 1)].DefenseEnabled)
                {
                    Dojos.Defenses[Step - (Step / 2 - 1)].DefenseEnabled = true;
                }


                if (Dojos.BoundDojo[0].Exp < ExpToNext)
                {
                    AttackEnabled = false;
                }

                LevelUp = $"Level Up \r\n{ExpString} Exp";
                Dojos.BoundDojo.Refresh();
                Dojos.Kicks.Refresh();
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
