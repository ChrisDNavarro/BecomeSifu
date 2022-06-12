using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BecomeSifu.MartialArts;
using System.Runtime.Remoting;
using BecomeSifu.Objects;
using BecomeSifu.UserControls;
using System.Collections.ObjectModel;
using BecomeSifu.FightObjects;
using BecomeSifu.Controls;
using System.Windows;

namespace BecomeSifu.Objects

{
    public static class Dojos
    {
        public static ObservableCollection<Punches> Punches = new ObservableCollection<Punches>();

        public static ObservableCollection<Kicks> Kicks = new ObservableCollection<Kicks>();

        public static ObservableCollection<Specials> Specials = new ObservableCollection<Specials>();

        public static ObservableCollection<Defenses> Defenses = new ObservableCollection<Defenses>();

        public static ObservableCollection<IFights> Fights = new ObservableCollection<IFights>();

        public static ObservableCollection<IDojo> Dojo = new ObservableCollection<IDojo>();

        public static ObservableCollection<EmptyCupControl> Cup = new ObservableCollection<EmptyCupControl>();



        public static void PickDojo(IDojo dojo)
        {
            if (string.IsNullOrEmpty(PageHolder.MainWindow.OldDojo))
            {
                PageHolder.MainWindow.OldDojo = dojo.ToString();
            }
            else
            {
                if (PageHolder.MainWindow.OldDojo == dojo.ToString())
                {
                    PageHolder.MainWindow.BonusesCollection(1, EmptyCupControl.DefeatedGrandMaster);
                }
                else
                {
                    PageHolder.MainWindow.BonusesCollection(2, EmptyCupControl.DefeatedGrandMaster);
                }

                PageHolder.MainWindow.OldDojo = dojo.ToString();
            }

            foreach(int perkID in PageHolder.MainWindow.ActivePerks)
            {
                dojo.Perks[perkID].Active = true;
                dojo.Perks[perkID].Visible = Visibility.Visible;
                dojo.Perks.Refresh();
            }

            Dojo.Add(dojo);
            AddCup(new EmptyCupControl());
            PageHolder.MainWindow.Start();
            PageHolder.MainWindow.Client.StartingMessages();
            PageHolder.MainWindow.Client.UpdateBonuses();
        }

        public static void AddPunch(Punches newPunch)
        {
            Punches.Add(newPunch);
        }

        public static void AddKick(Kicks newKick)
        {
            Kicks.Add(newKick);
        }

        public static void AddSpecial(Specials newSpecial)
        {
            Specials.Add(newSpecial);
        }

        public static void AddDefense(Defenses newDefense)
        {
            Defenses.Add(newDefense);
        }

        public static void AddFight(IFights fight)
        {
            Fights.Add(fight);
        }

        public static void AddCup(EmptyCupControl cup)
        {
            Cup.Add(cup);
        }

        public static void CleanOut()
        {
            Punches.Clear();
            Kicks.Clear();
            Specials.Clear();
            Defenses.Clear();
            Dojo.Clear();
            Cup.Clear();
            Fights.Clear();

            Punches.Refresh();
            Kicks.Refresh();
            Specials.Refresh();
            Defenses.Refresh();
            Dojo.Refresh();
            Cup.Refresh();
            Fights.Refresh();
        }

    }
}
