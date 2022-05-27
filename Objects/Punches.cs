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
                    Dojos.BoundDojo[0].Energy -= ExpToNext;
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


                if (!AllDefense || !AllKicks)
                {
                    ActivateDefense();
                }

                LevelUp = $"Level Up \r\n{ExpString} Exp";

                

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

        private void ActivateDefense()
        {
            if (!Dojos.BoundDojo[0].IsBoxing)
            {
                if (Step == 1 && !Dojos.Kicks[Step - 1].AttackEnabled && !AllKicks)
                {
                    Dojos.Kicks[Step - 1].AttackEnabled = true;
                    Dojos.Kicks.Refresh();
                }

                if (Step % 2 == 0 && Step / 2 < +Dojos.Defenses.Count && !Dojos.Defenses[Step - (Step / 2) - 1].DefenseEnabled && !AllDefense)
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
