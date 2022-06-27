using BecomeSifu.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BecomeSifu.Pages
{
    /// <summary>
    /// Interaction logic for MainClient.xaml
    /// </summary>
    public partial class MainClient : UserControl
    {
        public MainClient()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(View1_Loaded);
        }

        void View1_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow w = PageHolder.MainWindow;
            // w should not be Null now!
            if (null != w)
            {
                w.LocationChanged += delegate (object sender2, EventArgs args)
                {
                    var offset = MessagePopUp.HorizontalOffset;
                    // "bump" the offset to cause the popup to reposition itself
                    //   on its own
                    MessagePopUp.HorizontalOffset = offset + .01;
                    MessagePopUp.HorizontalOffset = offset;
                    NavigationPopup.HorizontalOffset = offset + .01;
                    NavigationPopup.HorizontalOffset = offset;
                };
                // Also handle the window being resized (so the popup's position stays
                //  relative to its target element if the target element moves upon 
                //  window resize)
                w.SizeChanged += delegate (object sender3, SizeChangedEventArgs e2)
                {
                    var offset = MessagePopUp.HorizontalOffset;
                    MessagePopUp.HorizontalOffset = offset + .011;
                    MessagePopUp.HorizontalOffset = offset;
                    NavigationPopup.HorizontalOffset = offset + .01;
                    NavigationPopup.HorizontalOffset = offset;
                };
            }
        }

        private void MessagePopUp_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Extensions.SendNextMessage();
        }
    }
}
