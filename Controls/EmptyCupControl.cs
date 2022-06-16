using BecomeSifu.Abstracts;
using BecomeSifu.Logging;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BecomeSifu.Controls
{
    public class EmptyCupControl
    {
        public static bool DefeatedGrandMaster { get; set; }
        public static bool Emptied { get; set; }
        
        public static string Imagesource { set 
            {
                PageHolder.MainWindow.DojoState.Cup[0].ImageSource = value;
            } 
        }
        private static string _CurrentBonus = "No Bonus";
        public static string CurrentBonus
        {
            get => _CurrentBonus;
            set
            {
                _CurrentBonus = value;
                PageHolder.MainWindow.DojoState.Cup[0].CurrentBonus = value;
            }
        }

        private static string _ButtonName = "First, fill your cup.";
        public static string ButtonName
        {
            get => _ButtonName;
            set 
            {
                _ButtonName = value;
                PageHolder.MainWindow.DojoState.Cup[0].ButtonName = value;
            }
        }

        private bool _ButtonActive;
        public bool ButtonActive
        {
            get => _ButtonActive;
            set
            {
                _ButtonActive = value;
                PageHolder.MainWindow.DojoState.Cup[0].ButtonActive = value;
            }
        }

        public static void EmptyingCup()
        {
            try
            {
                if (Emptied)
                {
                    ButtonName = "Empty Your Cup";
                    Emptied = false;
                    LogIt.Write($"Selection confirmed");
                    if (PageHolder.MainWindow.DojoState.Dojo[0].CheckForMaxed())
                    {
                        
                        LogIt.Write($"Skills are Maxed, Continuing to Perk selection");
                        PageHolder.MainWindow.StorePerk();
                    }
                    else
                    {
                        LogIt.Write($"SKills are not Maxed, Reloading Game");
                        PageHolder.MainWindow.Setup();
                    }
                }
                else
                {
                    LogIt.Write($"Confirming Selection for EmptyCup");
                    ButtonName = "Are You Sure?";
                    Emptied = true;
                    
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error catch: {e}");
                throw;
            }
        }

        public static void UpdateBonuses(List<int> bonuses)
        {
            try
            {
                decimal bonusOne = 0;
                decimal bonusTwo = 0;

                StringBuilder bonusUpdates = new StringBuilder();

                foreach (int bonus in bonuses)
                {
                    if (bonus == 1)
                    {
                        bonusOne++;
                        LogIt.Write($"Increasing Bonus One multiplier");
                    }
                    if (bonus == 2)
                    {
                        bonusTwo++;
                        LogIt.Write($"Increasing Bonus Two multiplier");
                    }
                }

                if (bonusOne > 0)
                {

                    bonusUpdates.AppendLine($@"You earn {50 * bonusOne}% more experience per practice.");
                    Imagesource = @"pack://application:,,,/Resources/CupIsHalf.png";
                    bonusUpdates.AppendLine("");
                    LogIt.Write($"Displaying Bonus One entry: You earn {50 * bonusOne}% more experience per practice.");
                }

                if (bonusTwo > 0)
                {
                    bonusUpdates.AppendLine($@"Attacks and Defenses cast {10 * bonusTwo}% less Energy to learn. ");
                    Imagesource = @"pack://application:,,,/Resources/CupIsHalf.png";
                    LogIt.Write($"Displaying Bonus One entry: Attacks and Defenses cast {10 * bonusTwo}% less Energy to learn.");
                }

                CurrentBonus = string.IsNullOrEmpty(bonusUpdates.ToString())
                    ? "No Bonus"
                    : bonusUpdates.ToString();
                
            }
            catch (Exception e)
            {
                LogIt.Write($"Error catch: {e}");
                throw;
            }
        }

    }
}
