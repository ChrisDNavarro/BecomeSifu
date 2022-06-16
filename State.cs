using BecomeSifu.Controls;
using BecomeSifu.FightObjects;
using BecomeSifu.MartialArts;
using BecomeSifu.Objects;
using BecomeSifu.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Media;
using System.Reflection;
using System.Linq;
using System.Windows.Media.Imaging;
using System.Text.Json;

namespace BecomeSifu
{
    public class State
    {
        public static string SavePath = string.Format(@$"c:\Program Files (x86)\BecomeSifu\save\savedstate.bsifu");

        public static void Save()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => !t.FullName.Contains("<") && t.Namespace.Contains("BecomeSifu") &&
                            (t.Namespace.Contains("Abstracts") ||
                            t.Namespace.Contains("ViewModels") ||
                            t.Namespace.Contains("MartialArts")))
                .ToArray();
            XmlSerializer saver = new XmlSerializer(typeof(Dojos), types);

            if (!File.Exists(SavePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(SavePath));
            }

            FileStream file = File.Create(SavePath);
            saver.Serialize(file, PageHolder.MainWindow.DojoState);
            file.Close();
        }
    }
}
