using BecomeSifu.Controls;
using BecomeSifu.Logging;
using BecomeSifu.Objects;
using BecomeSifu.ViewModels;
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
            //CollectionViewSource.GetDefaultView(value).Refresh();
        }

        public static void UpdateActives()
        {
            try
            {

                for (int i = 0; i < PageHolder.MainWindow.DojoState.Punches.Count; i++)
                {
                    PageHolder.MainWindow.DojoState.Punches[i].Enabled = i > 0
                        ? PageHolder.MainWindow.DojoState.Punches[i].Learned
                            ? PageHolder.MainWindow.DojoState.Dojo[0].Exp >= PageHolder.MainWindow.DojoState.Punches[i].ExpToNext
                            : PageHolder.MainWindow.DojoState.Punches[i-1].LevelInt >= 5
                                ? PageHolder.MainWindow.DojoState.Dojo[0].Energy >= PageHolder.MainWindow.DojoState.Punches[i].ExpToNext
                                : false
                        : PageHolder.MainWindow.DojoState.Punches[i].Learned
                            ? PageHolder.MainWindow.DojoState.Dojo[0].Exp >= PageHolder.MainWindow.DojoState.Punches[i].ExpToNext
                            : PageHolder.MainWindow.DojoState.Dojo[0].Energy >= PageHolder.MainWindow.DojoState.Punches[i].ExpToNext;
                }
                for (int i = 0; i < PageHolder.MainWindow.DojoState.Kicks.Count; i++)
                {
                    PageHolder.MainWindow.DojoState.Kicks[i].Enabled = i > 0
                        ? PageHolder.MainWindow.DojoState.Kicks[i].Learned
                            ? PageHolder.MainWindow.DojoState.Dojo[0].Exp >= PageHolder.MainWindow.DojoState.Kicks[i].ExpToNext
                            : PageHolder.MainWindow.DojoState.Kicks[i - 1].LevelInt >= 5
                                ? PageHolder.MainWindow.DojoState.Dojo[0].Energy >= PageHolder.MainWindow.DojoState.Kicks[i].ExpToNext
                                : false
                        : PageHolder.MainWindow.DojoState.Kicks[i].Learned
                            ? PageHolder.MainWindow.DojoState.Dojo[0].Exp >= PageHolder.MainWindow.DojoState.Kicks[i].ExpToNext
                            : PageHolder.MainWindow.DojoState.Punches[i].Learned
                                ? PageHolder.MainWindow.DojoState.Dojo[0].Energy >= PageHolder.MainWindow.DojoState.Kicks[i].ExpToNext
                                : false;
                }
                for (int i = 0; i < PageHolder.MainWindow.DojoState.Specials.Count; i++)
                {
                    if (PageHolder.MainWindow.DojoState.Dojo[0].Perks[1].Active)
                    {
                        if (PageHolder.MainWindow.DojoState.Kicks[0].Learned)
                        {
                            PageHolder.MainWindow.DojoState.Specials[i].Enabled = i > 0
                            ? PageHolder.MainWindow.DojoState.Specials[i].Learned
                                ? PageHolder.MainWindow.DojoState.Dojo[0].Exp >= PageHolder.MainWindow.DojoState.Specials[i].ExpToNext
                                : PageHolder.MainWindow.DojoState.Specials[i - 1].LevelInt >= 5
                                    ? PageHolder.MainWindow.DojoState.Dojo[0].Energy >= PageHolder.MainWindow.DojoState.Specials[i].ExpToNext
                                    : false
                            : PageHolder.MainWindow.DojoState.Specials[i].Learned
                                ? PageHolder.MainWindow.DojoState.Dojo[0].Exp >= PageHolder.MainWindow.DojoState.Specials[i].ExpToNext
                                : PageHolder.MainWindow.DojoState.Dojo[0].Energy >= PageHolder.MainWindow.DojoState.Specials[i].ExpToNext;
                        }
                    }
                    else
                    {
                        PageHolder.MainWindow.DojoState.Specials[i].Enabled = i > PageHolder.MainWindow.DojoState.FightsVMs[2].Wins
                            ? PageHolder.MainWindow.DojoState.Specials[i].Learned
                                ? PageHolder.MainWindow.DojoState.Dojo[0].Exp >= PageHolder.MainWindow.DojoState.Specials[i].ExpToNext
                                : PageHolder.MainWindow.DojoState.Dojo[0].Energy >= PageHolder.MainWindow.DojoState.Specials[i].ExpToNext
                            : false;
                    }
                }
                for (int i = 0; i < PageHolder.MainWindow.DojoState.Defenses.Count; i++)
                {
                    if ((!PageHolder.MainWindow.DojoState.Dojo[0].IsBoxing && PageHolder.MainWindow.DojoState.Kicks[4].Learned) || PageHolder.MainWindow.DojoState.Punches[4].Learned)
                    {
                        PageHolder.MainWindow.DojoState.Defenses[i].Enabled = i > 0
                            ? PageHolder.MainWindow.DojoState.Defenses[i].Learned
                                ? PageHolder.MainWindow.DojoState.Dojo[0].Exp >= PageHolder.MainWindow.DojoState.Defenses[i].ExpToNext
                                : PageHolder.MainWindow.DojoState.Defenses[i - 1].LevelInt >= 5
                                    ? PageHolder.MainWindow.DojoState.Dojo[0].Energy >= PageHolder.MainWindow.DojoState.Defenses[i].ExpToNext
                                    : false
                            : PageHolder.MainWindow.DojoState.Defenses[i].Learned
                                ? PageHolder.MainWindow.DojoState.Dojo[0].Exp >= PageHolder.MainWindow.DojoState.Defenses[i].ExpToNext
                                : PageHolder.MainWindow.DojoState.Dojo[0].Energy >= PageHolder.MainWindow.DojoState.Defenses[i].ExpToNext;
                    }
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
            foreach (ActionsViewModel punch in PageHolder.MainWindow.DojoState.Punches)
            {
                if (punch.Learned)
                {
                    punch.ExpToNext = PageHolder.MainWindow.DojoState.Dojo[0].AttacksExpToNext(punch.Step, punch.LevelInt);
                    punch.ExpString = punch.ExpToNext.ConvertToString();
                    punch.LevelUp = $"Level Up \r\n{punch.ExpString} Exp";
                }
            }
            foreach (ActionsViewModel kick in PageHolder.MainWindow.DojoState.Kicks)
            {
                if (kick.Learned)
                {
                    kick.ExpToNext = PageHolder.MainWindow.DojoState.Dojo[0].AttacksExpToNext(kick.Step, kick.LevelInt);
                    kick.ExpString = kick.ExpToNext.ConvertToString();
                    kick.LevelUp = $"Level Up \r\n{kick.ExpString} Exp";
                }
            }
            foreach (ActionsViewModel special in PageHolder.MainWindow.DojoState.Specials)
            {
                if (special.Learned)
                {
                    special.ExpToNext = PageHolder.MainWindow.DojoState.Dojo[0].AttacksExpToNext(special.Step, special.LevelInt);
                    special.ExpString = special.ExpToNext.ConvertToString();
                    special.LevelUp = $"Level Up \r\n{special.ExpString} Exp";
                }
            }
            foreach (ActionsViewModel def in PageHolder.MainWindow.DojoState.Defenses)
            {
                if (def.Learned)
                {
                    def.ExpToNext = PageHolder.MainWindow.DojoState.Dojo[0].AttacksExpToNext(def.Step, def.LevelInt);
                    def.ExpString = def.ExpToNext.ConvertToString();
                    def.LevelUp = $"Level Up \r\n{def.ExpString} Exp";
                }
            }
            Extensions.UpdateActives();
        }


        public static string ConvertToString(this decimal exp)
        {
            return exp == 0
                    ? "0"
                    : exp < 1000
                    ? exp.ToString("#.##")
                    : exp < 1000000
                    ? (Math.Truncate(100 * (exp / 1000)) / 100).ToString() + "k"
                    : exp < 1000000000
                    ? (Math.Truncate(100 * (exp / 1000000)) / 100).ToString() + "M"
                    : (Math.Truncate(100 * (exp / 1000000000)) / 100).ToString() + "B";
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
                Assembly assembly = Assembly.GetExecutingAssembly();
                string resourceName = assembly.GetManifestResourceNames()
                                        .Single(str => str.Contains($"{file}.txt"));


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