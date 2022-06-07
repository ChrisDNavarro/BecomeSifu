using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BecomeSifu.Controls;
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

        public List<int> ActivePerks = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
            Setup();
        }

        public void BonusesCollection(int bonus, bool keep)
        {
            if (keep)
            {
                Bonuses.Add((int)bonus);
            }
            else
            {
                Bonuses.Clear();
                Bonuses.Add((int)bonus);
            }
        }

        public void Setup()
        {
            if (ActivePerks.Count > 0)
            {
                foreach (int perkID in PageHolder.MainWindow.ActivePerks)
                {
                    if (!Dojos.Dojo[0].Perks[perkID].Stored)
                    {
                        PageHolder.MainWindow.ActivePerks.RemoveAt(PageHolder.MainWindow.ActivePerks.IndexOf(perkID));
                    }
                }
            }

            Dojos.CleanOut();

            PageHolder.MainWindow = this;
            PageHolder.MainClient = new MainClient();
            PageHolder.DojoPicker = new DojoPicker();
            PageHolder.MessagePopUp = new MessagePopUp();


            PageHolder.DojoPicker.Height = ContentArea.Height;
            PageHolder.DojoPicker.Width = ContentArea.Width;
            ContentArea.Content = PageHolder.DojoPicker;
        }

        public void Start()
        {
            
            PageHolder.MainClient.Height = ContentArea.Height;
            PageHolder.MainClient.Width = ContentArea.Width;
            ContentArea.Content = PageHolder.MainClient;
            Client = new BecomeSifuClient(Bonuses);
        }

        public void StorePerk()
        {
            PageHolder.PickArtsBonus = new PickArtsBonus();
            PageHolder.PickArtsBonus.Height = ContentArea.Height;
            PageHolder.PickArtsBonus.Width = ContentArea.Width;
            ContentArea.Content = PageHolder.PickArtsBonus;
        }

        private void BecomeSifu_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
