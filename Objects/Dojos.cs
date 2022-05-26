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

namespace BecomeSifu.Objects

{
    public static class Dojos
    {
        public static IDojo Dojo;

        public static ObservableCollection<Punches> Punches = new ObservableCollection<Punches>();

        public static ObservableCollection<Kicks> Kicks = new ObservableCollection<Kicks>();

        public static ObservableCollection<Specials> Specials = new ObservableCollection<Specials>();

        public static ObservableCollection<Defenses> Defenses = new ObservableCollection<Defenses>();

        public static ObservableCollection<IFights> Fights = new ObservableCollection<IFights>();

        public static ObservableCollection<Practicing> Practicing = new ObservableCollection<Practicing>();
        public static ObservableCollection<IDojo> BoundDojo = new ObservableCollection<IDojo>();



        public static void PickDojo(IDojo dojo)
        {
            Dojo = dojo;
            Dojo.CurrentArt = true;
            BoundDojo.Add(Dojo);
            PageHolder.MainWindow.Start();
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





    }
}
