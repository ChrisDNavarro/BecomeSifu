using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace BecomeSifu.Objects
{
    public class Specials : Buttons
    {
        public ICommand LevelUpCommand
        {
            get
            {
                return new RelayCommand(() => TryLevelUp());
            }
        }
        public Specials(string name, int step)
        {
            AttackName = name;
            Step = step + 1;

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
            };
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
                

                ExpToNext = Dojos.BoundDojo[0].AttacksExpToNext(Step+1, LevelInt);
                ExpString = ExpToNext.ConvertToString();

                LevelInt++;
                Level = "Lvl " + LevelInt.ToString();

                Dojos.BoundDojo[0].TotalLevels++;
                LevelUp = $"Level Up \r\n{ExpString} Exp";
                Dojos.BoundDojo.Refresh();
                Dojos.Specials.Refresh();
            }
            else
            {
                MaxLevel = true;
                LevelUp = "Max Level";
                Dojos.Specials.Refresh();
            }
        }

    }
}
