using BecomeSifu.Controls;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Data;

namespace BecomeSifu
{
    public static class Extensions
    {
        public static void Refresh<T>(this ObservableCollection<T> value)
        {
            CollectionViewSource.GetDefaultView(value).Refresh();
        }

        public static void UpdateActives()
        {
            if (Dojos.Punches[0].Learned)
            {
                for (int i = 0; i < Dojos.Punches.Count; i++)
                {
                    Dojos.Punches[i].AttackEnabled = Dojos.Punches[i].Learned
                        ? Dojos.BoundDojo[0].Exp >= Dojos.Punches[i].ExpToNext
                        : Dojos.Punches[i - 1].LevelInt >= 5 && Dojos.BoundDojo[0].Energy >= Dojos.Punches[i].ExpToNext;
                    Dojos.Punches.Refresh();
                }
            }
            if (Dojos.Kicks[0].Learned)
            {
                for (int i = 0; i < Dojos.Kicks.Count; i++)
                {
                    Dojos.Kicks[i].AttackEnabled = Dojos.Kicks[i].Learned
                        ? Dojos.BoundDojo[0].Exp >= Dojos.Kicks[i].ExpToNext
                        : Dojos.Kicks[i - 1].LevelInt >= 5 && Dojos.BoundDojo[0].Energy >= Dojos.Kicks[i].ExpToNext;
                    Dojos.Kicks.Refresh();
                }
            }
            if (Dojos.Specials[0].Learned)
            {
                for (int i = 0; i < Dojos.Specials.Count; i++)
                {
                    Dojos.Specials[i].AttackEnabled = Dojos.Specials[i].Learned
                        ? Dojos.BoundDojo[0].Exp >= Dojos.Specials[i].ExpToNext
                        : Dojos.Specials[i - 1].LevelInt >= 5 && Dojos.BoundDojo[0].Energy >= Dojos.Specials[i].ExpToNext;
                    Dojos.Specials.Refresh();
                }
            }
            if (Dojos.Defenses[0].Learned)
            {
                for (int i = 0; i < Dojos.Defenses.Count; i++)
                {
                    Dojos.Defenses[i].DefenseEnabled = Dojos.Defenses[i].Learned
                        ? Dojos.BoundDojo[0].Exp >= Dojos.Defenses[i].ExpToNext
                        : Dojos.Defenses[i - 1].LevelInt >= 5 && Dojos.BoundDojo[0].Energy >= Dojos.Defenses[i].ExpToNext;
                    Dojos.Defenses.Refresh();
                }
            }
        }


        public static string ConvertToString(this decimal exp)
        {
             return exp < 1000
                ? exp.ToString("#.##")
                : exp < 1000000
                ? (exp / 1000).ToString("#.##") + "k"
                : exp < 1000000000
                ? (exp / 1000000).ToString("#.##") + "M"
                : (exp / 1000000000).ToString("#.##") + "B";
        }

        public static void SendMessage(string message)
        {
        }
    }
}
