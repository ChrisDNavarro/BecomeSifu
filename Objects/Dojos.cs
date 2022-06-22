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
using System.Xml.Serialization;

namespace BecomeSifu.Objects

{
    public class Dojos
    {
        
        public List<ArtsAbstract> Dojo { get; set; } = new List<ArtsAbstract>();

        
        public List<PracticeViewModel> Practice { get; set; } = new List<PracticeViewModel>();

        
        public List<EmptyCupViewModel> Cup { get; set; } = new List<EmptyCupViewModel>();

        
        public List<FightsViewModelAbstract> FightsVMs { get; set; } = new List<FightsViewModelAbstract>();

       
        public List<ActionsViewModel> Punches { get; set; } = new List<ActionsViewModel>();

        
        public List<ActionsViewModel> Kicks { get; set; } = new List<ActionsViewModel>();

        
        public List<ActionsViewModel> Specials { get; set; } = new List<ActionsViewModel>();

        
        public List<ActionsViewModel> Defenses { get; set; } = new List<ActionsViewModel>();
        


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
            AddPractice(new PracticeViewModel(), dojo.ToString());
            AddCup(new EmptyCupViewModel());
            PageHolder.MainWindow.Start();
            PageHolder.MainWindow.Client.StartingMessages();
            BecomeSifuClient.UpdateBonuses();
        }

        private void AddPractice(PracticeViewModel practiceViewModel, string dojo)
        {
            practiceViewModel.Source = $"{dojo.Substring(dojo.LastIndexOf('.') + 1)}.gif";
            Practice.Add(practiceViewModel);
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

        public void AddFightVM(FightsViewModelAbstract fight)
        {
            FightsVMs.Add(fight);
        }

        public void AddCup(EmptyCupViewModel cup)
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
        }

    }
}
