using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace BecomeSifu.Objects
{
    public class Defenses : Buttons
    {
        public ICommand LevelUpCommand
        {
            get
            {
                return null;
                //return new RelayCommand(() => TryLevelUp());
            }
        }
        public string DefenseName { get; set; }
        public bool DefenseEnabled { get; set; }

        public Defenses(string name, int step)
        {
            DefenseName = name;
            if (Dojos.BoundDojo[0].IsBoxing)
            {
                Step = step + 3;
            }
            else
            {
                Step = (step + 1) * 2;
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
                    if (Step >= Dojos.Defenses.Count)
                    {
                        AllDefense = true;
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
            if (LevelInt <= 500)
            {
                Dojos.BoundDojo[0].Energy -= ExpToNext;

                ExpToNext = Dojos.BoundDojo[0].AttacksExpToNext(Step, LevelInt);
                ExpString = ExpToNext.ConvertToString();

                LevelInt++;
                Level = "Lvl " + LevelInt.ToString();

                Dojos.BoundDojo[0].TotalLevels++;
                LevelUp = $"Level Up \r\n{ExpString} Exp";
                Dojos.BoundDojo.Refresh();
                Dojos.Defenses.Refresh();
            }
            else
            {
                MaxLevel = true;
                LevelUp = "Max Level";
                Dojos.Defenses.Refresh();
            }
        }

    }
}
