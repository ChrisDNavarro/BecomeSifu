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

            ExpToNext = Dojos.BoundDojo[0].EnergyToUnlock(Step);
            ExpString = ConvertExpToString(ExpToNext);
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
                    CompleteLevelUp();
                }
            }
            else
            {
                if (Dojos.BoundDojo[0].Exp >= ExpToNext && !MaxLevel)
                {
                    CompleteLevelUp();
                }
            }
        }

        private void CompleteLevelUp()
        {
            if (Convert.ToInt32(Level) <= 500)
            {
                Dojos.BoundDojo[0].Energy -= ExpToNext;

                ExpToNext = Dojos.BoundDojo[0].AttacksExpToNext(Step, ExpToNext);
                ExpString = ConvertExpToString(ExpToNext);

                Level = "Lvl " + (Convert.ToInt32(Level) + 1).ToString();

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

        private string ConvertExpToString(decimal exp)
        {
            return exp < 1000
                ? exp.ToString("#.##")
                : exp < 1000000
                ? (exp / 1000).ToString("#.##") + "k"
                : exp < 1000000000
                ? (exp / 1000000).ToString("#.##") + "M"
                : (exp / 1000000000).ToString("#.##") + "B";
        }


    }
}
