using BecomeSifu.Abstracts;
using BecomeSifu.Controls;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;


namespace BecomeSifu.MartialArts
{
    public class Perk
    {
        public CommandAbstract PickThisOne => new RelayCommand(x => StorePerk());

        private void StorePerk()
        {
            Stored = true;
            PageHolder.MainWindow.State.Dojo[0].Perks.Refresh();
            PageHolder.MainWindow.Setup();
        }

        public List<string> PerksList = new List<string>{
             "Kicks generate 50% more attack power.",
            "All Specials available after learning first kick.",
            "Punches generate 100& more attack power.",
            "Every level in specials increases attack speed by .04% (100% at max).",
            "Every Attack generates 10% more attack power.",
            "Increase Mediation gains by 50%"
        };
        public static int Count { get; } = 6;

        public string Name { get; set; }
        public Visibility Visible { get; set; } = Visibility.Collapsed;
        public bool Active { get; set; }
        public bool Stored { get; set; }

        public Perk(int perk, bool active)
        {
            Name = PerksList[perk];
            if (active)
            {
                Active = active;
                Visible = Visibility.Visible;
            }
        }
        public Perk() { }



    }
}
