using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using BecomeSifu.Controls;
using BecomeSifu.Logging;
using BecomeSifu.MartialArts;
using BecomeSifu.Objects;
using BecomeSifu.Pages;
using Newtonsoft.Json;

namespace BecomeSifu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> Bonuses = new List<int>();
        public string OldDojo { get; set; }
        public BecomeSifuClient Client { get; set; }
        public bool Maxed { get; set; }
        public Dojos DojoState { get; set; }

        public List<int> ActivePerks = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
            DojoState = new Dojos();
            LogIt.Write("***********************************************************************");
            LogIt.Write("***********************************************************************");

            Setup();
        }

        public void BonusesCollection(int bonus, bool keep)
        {
            if (keep)
            {
                Bonuses.Add(bonus);
            }
            else
            {
                Bonuses.Clear();
                Bonuses.Add(bonus);
            }
        }

        public void Setup()
        {
            LogIt.Write("***********************************************************************");
            try
            {
                if (ActivePerks.Count > 0)
                {
                    foreach (int perkID in PageHolder.MainWindow.ActivePerks)
                    {
                        if (!PageHolder.MainWindow.DojoState.Dojo[0].Perks[perkID].Stored)
                        {
                            PageHolder.MainWindow.ActivePerks.RemoveAt(PageHolder.MainWindow.ActivePerks.IndexOf(perkID));
                        }
                    }
                }
                if (!string.IsNullOrEmpty(OldDojo))
                {
                    DojoState.CleanOut();
                }

                PageHolder.MainWindow = this;
                PageHolder.MainClient = new MainClient();
                PageHolder.DojoPicker = new DojoPicker();
                PageHolder.MessagePopUp = new MessagePopUp();

                if (!File.Exists(State.SavePath))
                {
                    PageHolder.DojoPicker.Height = ContentArea.Height;
                    PageHolder.DojoPicker.Width = ContentArea.Width;
                    ContentArea.Content = PageHolder.DojoPicker;
                }
                else
                {
                    LoadState();
                }
                LogIt.Write();
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        public void Start()
        {

            try
            {
                PageHolder.MainClient.Height = ContentArea.Height;
                PageHolder.MainClient.Width = ContentArea.Width;
                ContentArea.Content = PageHolder.MainClient;
                Client = !File.Exists(State.SavePath)
                    ? new BecomeSifuClient(Bonuses, false) 
                    : new BecomeSifuClient(Bonuses, true);
                LogIt.Write();
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        private void LoadState()
        {
            
            string[] files = Directory.GetFiles(@$"c:\Program Files (x86)\BecomeSifu\save\", $@"*.bsifu");
            if (files != null)
            {
                foreach (string file in files)
                {
                    Type[] types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => !t.FullName.Contains("<") && t.Namespace.Contains("BecomeSifu") &&
                            (t.Namespace.Contains("Abstracts") ||
                            t.Namespace.Contains("ViewModels") ||
                            t.Namespace.Contains("MartialArts")))
                .ToArray();
                    XmlSerializer loader = new XmlSerializer(typeof(Dojos), types);
                    FileStream f;
                    try
                    {
                         f = File.Open(file, FileMode.Open);
                    }
                    catch (Exception e)
                    {
                        LogIt.Write($"Error Caught: {e}");
                        throw;
                    }
                    DojoState = (Dojos)loader.Deserialize(f);
                    f.Close();
                }
            }

            if (string.IsNullOrEmpty(PageHolder.MainWindow.OldDojo))
            {
                PageHolder.MainWindow.OldDojo = DojoState.Dojo[0].ToString();
            }
            else
            {
                if (PageHolder.MainWindow.OldDojo == DojoState.Dojo[0].ToString())
                {
                    PageHolder.MainWindow.BonusesCollection(1, EmptyCupControl.DefeatedGrandMaster);
                }
                else
                {
                    PageHolder.MainWindow.BonusesCollection(2, EmptyCupControl.DefeatedGrandMaster);
                }

                PageHolder.MainWindow.OldDojo = DojoState.Dojo[0].ToString();
            }

            Start();            
            BecomeSifuClient.UpdateBonuses();
        }

        public void StorePerk()
        {
            try
            {
                PageHolder.PickArtsBonus = new PickArtsBonus();
                PageHolder.PickArtsBonus.Height = ContentArea.Height;
                PageHolder.PickArtsBonus.Width = ContentArea.Width;
                ContentArea.Content = PageHolder.PickArtsBonus;
                LogIt.Write();
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        private void BecomeSifu_Closed(object sender, EventArgs e)
        {
            DojoState.Closed = DateTime.UtcNow;
            State.Save();
            Application.Current.Shutdown();
        }
    }
}
