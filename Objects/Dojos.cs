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
using BecomeSifu.ViewModels;

namespace BecomeSifu.Objects

{
    public static class Dojos
    {
        public static ObservableCollection<ActionsViewModel> Punches = new ObservableCollection<ActionsViewModel>();

        public static ObservableCollection<ActionsViewModel> Kicks = new ObservableCollection<ActionsViewModel>();

        public static ObservableCollection<ActionsViewModel> Specials = new ObservableCollection<ActionsViewModel>();

        public static ObservableCollection<ActionsViewModel> Defenses = new ObservableCollection<ActionsViewModel>();

        public static ObservableCollection<IFights> Fights = new ObservableCollection<IFights>();

        public static ObservableCollection<IDojo> Dojo = new ObservableCollection<IDojo>();

        public static ObservableCollection<EmptyCupControl> Cup = new ObservableCollection<EmptyCupControl>();

        public static ObservableCollection<PracticeViewModel> Practice = new ObservableCollection<PracticeViewModel>();



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
            Practice.Add(new PracticeViewModel());
            AddCup(new EmptyCupControl());
            PageHolder.MainWindow.Start();
            PageHolder.MainWindow.Client.StartingMessages();
            PageHolder.MainWindow.Client.UpdateBonuses();
        }

        public static void AddPunch(ActionsViewModel newPunch)
        {
            Punches.Add(newPunch);
        }

        public static void AddKick(ActionsViewModel newKick)
        {
            Kicks.Add(newKick);
        }

        public static void AddSpecial(ActionsViewModel newSpecial)
        {
            Specials.Add(newSpecial);
        }

        public static void AddDefense(ActionsViewModel newDefense)
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
