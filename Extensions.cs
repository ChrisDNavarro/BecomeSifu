using BecomeSifu.Controls;
using BecomeSifu.Logging;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        public static object StackFrame { get; private set; }

        public static void Refresh<T>(this ObservableCollection<T> value)
        {
            CollectionViewSource.GetDefaultView(value).Refresh();
        }

        public static void UpdateActives()
        {
            try
            {

                for (int i = 0; i < Dojos.Punches.Count; i++)
                {
                    Dojos.Punches[i].Enabled = i > 0
                        ? Dojos.Punches[i].Learned
                            ? Dojos.Dojo[0].Exp >= Dojos.Punches[i].ExpToNext
                            : Dojos.Punches[i - 1].LevelInt >= 5 && Dojos.Dojo[0].Energy >= Dojos.Punches[i].ExpToNext
                        : Dojos.Dojo[0].Exp >= Dojos.Punches[i].ExpToNext;
                    Dojos.Punches.Refresh();
                }
                for (int i = 0; i < Dojos.Kicks.Count; i++)
                {
                    Dojos.Kicks[i].Enabled = i > 0
                        ? Dojos.Kicks[i].Learned
                            ? Dojos.Dojo[0].Exp >= Dojos.Kicks[i].ExpToNext
                            : Dojos.Kicks[i - 1].LevelInt >= 5 && Dojos.Dojo[0].Energy >= Dojos.Kicks[i].ExpToNext
                        : Dojos.Kicks[i].Learned
                            ? Dojos.Dojo[0].Exp >= Dojos.Kicks[i].ExpToNext
                            : Dojos.Dojo[0].Energy >= Dojos.Kicks[i].ExpToNext;
                    Dojos.Kicks.Refresh();
                }
                for (int i = 0; i < Dojos.Specials.Count; i++)
                {
                    if (!Dojos.Dojo[0].Perks[1].Active)
                    {
                        Dojos.Specials[i].Enabled = i > 0
                            ? Dojos.Specials[i].Learned
                                ? Dojos.Dojo[0].Exp >= Dojos.Specials[i].ExpToNext
                                : Dojos.Specials[i - 1].LevelInt >= 5 && Dojos.Dojo[0].Energy >= Dojos.Specials[i].ExpToNext
                            : Dojos.Dojo[0].Exp >= Dojos.Specials[i].ExpToNext;
                    }
                    else
                    {
                        Dojos.Specials[i].Enabled = Dojos.Specials[i].Learned
                            && Dojos.Dojo[0].Exp >= Dojos.Specials[i].ExpToNext;
                    }
                    Dojos.Specials.Refresh();
                }
                for (int i = 0; i < Dojos.Defenses.Count; i++)
                {
                    Dojos.Defenses[i].Enabled = i > 0
                        ? Dojos.Defenses[i].Learned
                            ? Dojos.Dojo[0].Exp >= Dojos.Defenses[i].ExpToNext
                            : Dojos.Defenses[i - 1].LevelInt >= 5 && Dojos.Dojo[0].Energy >= Dojos.Defenses[i].ExpToNext
                        : Dojos.Dojo[0].Exp >= Dojos.Defenses[i].ExpToNext;
                    Dojos.Defenses.Refresh();
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        public static void UpdateBoostedEXP()
        {
            for (int i = 0; i < Dojos.Punches.Count; i++)
            {
                Punches.LevelUpExp(Dojos.Punches[i]);
            }
            //foreach (Kicks kick in Dojos.Kicks)
            //{
            //    kick.ExpToNext = Dojos.Dojo[0].AttacksExpToNext(kick.Step, kick.LevelInt);
            //    kick.ExpString = kick.ExpToNext.ConvertToString();
            //}
            //foreach (Specials special in Dojos.Specials)
            //{
            //    special.ExpToNext = Dojos.Dojo[0].AttacksExpToNext(special.Step, special.LevelInt);
            //    special.ExpString = special.ExpToNext.ConvertToString();
            //}
            //foreach (Defenses def in Dojos.Defenses)
            //{
            //    def.ExpToNext = Dojos.Dojo[0].AttacksExpToNext(def.Step, def.LevelInt);
            //    def.ExpString = def.ExpToNext.ConvertToString();
            //}
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
            try
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
                LogIt.Write($"Sent {file} for {new StackFrame(1).GetMethod().DeclaringType.Name}.{new StackFrame(1).GetMethod().Name}");
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

    }
}
;