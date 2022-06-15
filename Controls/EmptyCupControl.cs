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
        public bool Emptied { get; set; }
        public CommandAbstract EmptyYourCup => new RelayCommand(x => PageHolder.MainWindow.State.Cup[0].EmptyingCup());
        public ImageSource Imagesource { get; set; } =
                        new BitmapImage(new Uri(@"pack://application:,,,/Resources/CupIsEmpty.png"));
        public string CurrentBonus { get; set; } = "No Bonus";
        public string ButtonName { get; set; } = "Locked";
        public bool ButtonActive { get; set; }

        public void EmptyingCup()
        {
            try
            {
                if (Emptied)
                {
                    ButtonName = "Empty Your Cup";
                    Emptied = false;
                    LogIt.Write($"Selection confirmed");
                    if (PageHolder.MainWindow.State.Dojo[0].CheckForMaxed())
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
                    PageHolder.MainWindow.State.Cup.Refresh();
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error catch: {e}");
                throw;
            }
        }

        public void UpdateBonuses(List<int> bonuses)
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
                    Imagesource = new BitmapImage(new Uri(@"pack://application:,,,/Resources/CupIsHalf.png"));
                    bonusUpdates.AppendLine("");
                    LogIt.Write($"Displaying Bonus One entry: You earn {50 * bonusOne}% more experience per practice.");
                }

                if (bonusTwo > 0)
                {
                    bonusUpdates.AppendLine($@"Attacks and Defenses cast {10 * bonusTwo}% less Energy to learn. ");
                    Imagesource = new BitmapImage(new Uri(@"pack://application:,,,/Resources/CupIsHalf.png"));
                    LogIt.Write($"Displaying Bonus One entry: Attacks and Defenses cast {10 * bonusTwo}% less Energy to learn.");
                }

                CurrentBonus = bonusUpdates.ToString();
                PageHolder.MainWindow.State.Cup.Refresh();
            }
            catch (Exception e)
            {
                LogIt.Write($"Error catch: {e}");
                throw;
            }
        }

    }
}
