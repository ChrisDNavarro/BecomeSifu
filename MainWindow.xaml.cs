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
        public Dojos State { get; set; }
        public bool Saved { get; set; }

        public List<int> ActivePerks = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
            State = new Dojos();
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
                        if (!PageHolder.MainWindow.State.Dojo[0].Perks[perkID].Stored)
                        {
                            PageHolder.MainWindow.ActivePerks.RemoveAt(PageHolder.MainWindow.ActivePerks.IndexOf(perkID));
                        }
                    }
                }

                State.CleanOut();

                PageHolder.MainWindow = this;
                PageHolder.MainClient = new MainClient();
                PageHolder.DojoPicker = new DojoPicker();
                PageHolder.MessagePopUp = new MessagePopUp();


                PageHolder.DojoPicker.Height = ContentArea.Height;
                PageHolder.DojoPicker.Width = ContentArea.Width;
                ContentArea.Content = PageHolder.DojoPicker;
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
                
                Client = new BecomeSifuClient(Bonuses);
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
            string[] files = Directory.GetFiles(@$"c:\Program Files (x86)\BecomeSifu\save", $@".bsifu");
            if (files != null)
            {
                foreach (string file in files)
                {
                    XmlSerializer loader = new XmlSerializer(typeof(Dojos));
                    FileStream f = File.Open(file, FileMode.Open);
                    State = (Dojos)loader.Deserialize(f);
                }
            }
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
            State.Closed = DateTime.UtcNow;
            _ = new SaveState();
            Application.Current.Shutdown();
        }
    }
}
