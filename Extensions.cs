using BecomeSifu.Controls;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BecomeSifu
{
    public static class Extensions
    {
        private static List<string> NextMessage = new List<string>();
        public static void Refresh<T>(this ObservableCollection<T> value)
        {
            CollectionViewSource.GetDefaultView(value).Refresh();
        }

        public static void UpdateActives()
        {
            for (int i = 0; i < Dojos.Punches.Count; i++)
            {
                Dojos.Punches[i].AttackEnabled = i > 0
                    ? Dojos.Punches[i].Learned
                        ? Dojos.Dojo[0].Exp >= Dojos.Punches[i].ExpToNext
                        : Dojos.Punches[i - 1].LevelInt >= 5 && Dojos.Dojo[0].Energy >= Dojos.Punches[i].ExpToNext
                    : Dojos.Dojo[0].Exp >= Dojos.Punches[i].ExpToNext;
                Dojos.Punches.Refresh();
            }
            for (int i = 0; i < Dojos.Kicks.Count; i++)
            {
                Dojos.Kicks[i].AttackEnabled = i > 0
                    ? Dojos.Kicks[i].Learned
                        ? Dojos.Dojo[0].Exp >= Dojos.Kicks[i].ExpToNext
                        : Dojos.Kicks[i - 1].LevelInt >= 5 && Dojos.Dojo[0].Energy >= Dojos.Kicks[i].ExpToNext
                    : Dojos.Dojo[0].Exp >= Dojos.Kicks[i].ExpToNext;
                Dojos.Kicks.Refresh();
            }
            for (int i = 0; i < Dojos.Specials.Count; i++)
            {
                Dojos.Specials[i].AttackEnabled = i > 0
                    ? Dojos.Specials[i].Learned
                        ? Dojos.Dojo[0].Exp >= Dojos.Specials[i].ExpToNext
                        : Dojos.Specials[i - 1].LevelInt >= 5 && Dojos.Dojo[0].Energy >= Dojos.Specials[i].ExpToNext
                    : Dojos.Dojo[0].Exp >= Dojos.Specials[i].ExpToNext;
                Dojos.Specials.Refresh();
            }
            for (int i = 0; i < Dojos.Defenses.Count; i++)
            {
                Dojos.Defenses[i].DefenseEnabled = i > 0
                    ? Dojos.Defenses[i].Learned
                        ? Dojos.Dojo[0].Exp >= Dojos.Defenses[i].ExpToNext
                        : Dojos.Defenses[i - 1].LevelInt >= 5 && Dojos.Dojo[0].Energy >= Dojos.Defenses[i].ExpToNext
                    : Dojos.Dojo[0].Exp >= Dojos.Defenses[i].ExpToNext;
                Dojos.Defenses.Refresh();
            }
        }


        public static string ConvertToString(this decimal exp)
        {
            return exp == 0
                    ? "0"
                    : exp < 1000
                    ? exp.ToString("#.##")
                    : exp < 1000000
                    ? (exp / 1000).ToString("#.##") + "k"
                    : exp < 1000000000
                    ? (exp / 1000000).ToString("#.##") + "M"
                    : (exp / 1000000000).ToString("#.##") + "B";
        }

        public static void SendMessage(string message)
        {
            PageHolder.MainClient.Message.Text = message;
            PageHolder.MainClient.MessagePopUp.IsOpen = true;
        }

        public static void SendNextMessage()
        {
            PageHolder.MainClient.MessagePopUp.IsOpen = false;
            if (NextMessage.Count > 0)
            {
                if (!string.IsNullOrEmpty(NextMessage[0]))
                {
                    SendMessage(NextMessage[0]);
                    NextMessage.RemoveAt(0);
                }
            }
        }

        public static void CreateMessage(string file, bool send)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames()
                                    .Single(str => str.EndsWith($"{file}.txt"));

             
            string result;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            NextMessage.Add(result);

            if (send)
            {
                SendMessage(NextMessage[0]);
                NextMessage.RemoveAt(0);
            }
        }

    }
}
;