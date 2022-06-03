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
        public ICommand EmptyYourCup;
        public ImageSource Imagesource { get; set; } =
                        new BitmapImage(new Uri(@"pack://application:,,,/Resources/CupIsEmpty.png"));
        public string CurrentBonus { get; set; } = "No Bonus";

        private void EmptyingCup()
        {
            
        }

    }
}
