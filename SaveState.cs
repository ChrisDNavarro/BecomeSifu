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

namespace BecomeSifu
{
    public class SaveState
    {
        private readonly string SavePath = string.Format(@$"c:\Program Files (x86)\BecomeSifu\save\savedstate.bsifu");

        public SaveState()
        {
            Type[] type = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => !t.Name.Contains("Window") && !t.Name.Contains("<") && !t.Namespace.Contains("UserControls") &&
                (t.Namespace.Contains("Abstracts") ||
                t.Namespace.Contains("FightObjects") ||
                t.Namespace.Contains("MartialArts") ||
                t.Namespace.Contains("Objects") ||
                t.Namespace.Contains("ViewModels")
                ))
                .ToArray();

            XmlSerializer saver = new XmlSerializer(typeof(Dojos), type);

            if (!File.Exists(SavePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(SavePath));
            }
            FileStream file = File.Create(SavePath);
            saver.Serialize(file, PageHolder.MainWindow.State);
            file.Close();
            PageHolder.MainWindow.Saved = true;
        }
    }
}
