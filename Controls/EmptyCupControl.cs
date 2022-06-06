using BecomeSifu.Objects;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BecomeSifu.Controls
{
    public class EmptyCupControl
    {
        public bool Emptied { get; set; }
        public ICommand EmptyYourCup => new RelayCommand(() => Dojos.Cup[0].EmptyingCup());
        public ImageSource Imagesource { get; set; } =
                        new BitmapImage(new Uri(@"pack://application:,,,/Resources/CupIsEmpty.png"));
        public string CurrentBonus { get; set; } = "No Bonus";
        public string ButtonName { get; set; } = "Locked";
        public bool ButtonActive { get; set; }

        public void EmptyingCup()
        {
            if (Emptied)
            {
                Dojos.CleanOut();
                PageHolder.MainWindow.Setup();
                ButtonName = "Empty Your Cup";
                Emptied = false;
            }
            else
            {
                ButtonName = "Are You Sure?";
                Emptied = true;
                Dojos.Cup.Refresh();
            }
        }

        public void UpdateBonuses(List<int> bonuses)
        {
            decimal bonusOne = 0;
            decimal bonusTwo = 0;

            StringBuilder bonusUpdates = new StringBuilder();

            foreach (int bonus in bonuses)
            {
                if(bonus == 1)
                {
                    bonusOne++;
                }
                if(bonus == 2)
                {
                    bonusTwo++;
                }
            }

            if(bonusOne > 0)
            {
                bonusUpdates.AppendLine($@"Attacks and Defenses cast {10 * bonusOne}% less Energy to learn. ");
                bonusUpdates.AppendLine("");
            }

            if(bonusTwo > 0)
            {
                bonusUpdates.AppendLine($@"You earn {50 * bonusTwo}% more experience per practice.");
            }

            CurrentBonus = bonusUpdates.ToString();
            Dojos.Cup.Refresh();
        }

    }
}
