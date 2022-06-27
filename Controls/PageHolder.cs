using BecomeSifu.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BecomeSifu.Controls
{
    public static class PageHolder
    {
        public static MainWindow MainWindow { get; set; }
        public static MainClient MainClient { get; set; }
        public static MessagePopUp MessagePopUp { get; set; }
        public static DojoPicker DojoPicker { get; set; }
        public static PickArtsBonus PickArtsBonus { get; set; }
        public static LoadSavePage LoadSavePage { get; set; }

    }
}
