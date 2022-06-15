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
using BecomeSifu.Abstracts;

namespace BecomeSifu.Objects

{
    public class Dojos
    {
        public ObservableCollection<ActionsViewModel> Punches = new ObservableCollection<ActionsViewModel>();

        public ObservableCollection<ActionsViewModel> Kicks = new ObservableCollection<ActionsViewModel>();

        public ObservableCollection<ActionsViewModel> Specials = new ObservableCollection<ActionsViewModel>();

        public ObservableCollection<ActionsViewModel> Defenses = new ObservableCollection<ActionsViewModel>();

        public ObservableCollection<AllFightsAbstract> Fights = new ObservableCollection<AllFightsAbstract>();

        public ObservableCollection<FightsViewModelAbstract> FightsVMs = new ObservableCollection<FightsViewModelAbstract>();

        public ObservableCollection<ArtsAbstract> Dojo = new ObservableCollection<ArtsAbstract>();

        public ObservableCollection<EmptyCupControl> Cup = new ObservableCollection<EmptyCupControl>();

        public ObservableCollection<PracticeViewModel> Practice = new ObservableCollection<PracticeViewModel>();

        public DateTime Closed { get; set; }


        public void PickDojo(ArtsAbstract dojo)
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

        public void AddPunch(ActionsViewModel newPunch)
        {
            Punches.Add(newPunch);
        }

        public void AddKick(ActionsViewModel newKick)
        {
            Kicks.Add(newKick);
        }

        public void AddSpecial(ActionsViewModel newSpecial)
        {
            Specials.Add(newSpecial);
        }

        public void AddDefense(ActionsViewModel newDefense)
        {
            Defenses.Add(newDefense);
        }

        public void AddFight(AllFightsAbstract fight)
        {
            Fights.Add(fight);
        }

        public void AddFightVM(FightsViewModelAbstract fight)
        {
            FightsVMs.Add(fight);
        }

        public void AddCup(EmptyCupControl cup)
        {
            Cup.Add(cup);
        }

        public void CleanOut()
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
