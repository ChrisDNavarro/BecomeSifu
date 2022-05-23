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
using BecomeSifu.Objects;
using BecomeSifu.Pages;

namespace BecomeSifu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static BecomeSifuClient Client;
        public MainWindow()
        {
            InitializeComponent();
            PageHolder.MainWindow = this;
            PageHolder.MainClient = new MainClient();
            PageHolder.DojoPicker = new DojoPicker();
            PageHolder.MessagePopUp = new MessagePopUp();

            ContentArea.Content = PageHolder.DojoPicker;
        }
        private void OnExitMenuItemClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void Start()
        {
            ContentArea.Content = PageHolder.MainClient;
            PageHolder.MainClient.Height = ContentArea.Height;
            PageHolder.MainClient.Width = ContentArea.Width;
            Client = new BecomeSifuClient();
        }

    }
}
