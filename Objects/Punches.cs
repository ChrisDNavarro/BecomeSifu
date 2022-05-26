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

            ExpToNext = Dojos.BoundDojo[0].EnergyToUnlock(Step);
            ExpString = ConvertExpToString(ExpToNext);
            LevelUp = $"Learn\r\n{ExpString} Eng";

            if(Step == 1)
            {
                AttackEnabled = true;
            }

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

                if(Step != 1 && Step < Dojos.Punches.Count && !Dojos.Punches[Step].AttackEnabled && Convert.ToInt32(Level) >= 5)
                {
                    Dojos.Punches[Step].AttackEnabled = true;
                }

                if (!AllDefense || !AllKicks)
                {
                    ActivateDefense();
                }

                LevelUp = $"Level Up \r\n{ExpString} Exp";

                if (Dojos.BoundDojo[0].Exp < ExpToNext)
                {
                    AttackEnabled = false;
                }

                Dojos.BoundDojo.Refresh();
                Dojos.Punches.Refresh();
            }
            else
            {
                MaxLevel = true;
                LevelUp = "Max Level";
                Dojos.Punches.Refresh();
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

        private void ActivateDefense()
        {
            if (!Dojos.BoundDojo[0].IsBoxing)
            {
                if (Step == 1 && !Dojos.Kicks[Step - 1].AttackEnabled && !AllKicks)
                {
                    Dojos.Kicks[Step - 1].AttackEnabled = true;
                    Dojos.Kicks.Refresh();
                }

                if (Step % 2 == 0 && Step / 2 < +Dojos.Defenses.Count && !Dojos.Defenses[Step - (Step / 2 - 1)].DefenseEnabled && !AllDefense)
                {
                    Dojos.Defenses[Step - (Step / 2 - 1)].DefenseEnabled = true;
                }
            }
            else
            {
                if (!AllKicks)
                {
                    foreach (Kicks kick in Dojos.Kicks)
                    {
                        if (Step >= 10 && AttackEnabled)
                        {
                            kick.AttackEnabled = true;
                            Dojos.Kicks.Refresh();
                        }
                    }
                }
                if (!AllDefense)
                {
                    foreach (Defenses defense in Dojos.Defenses)
                    {
                        if (Step > 3 && AttackEnabled)
                        {
                            defense.DefenseEnabled = true;
                            Dojos.Defenses.Refresh();
                        }
                    } 
                }
            }
        }
    }
}
