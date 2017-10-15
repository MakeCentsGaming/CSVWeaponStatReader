using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CSVWeaponStatReader
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void APP_LINK_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://philmaher.me/CSVWeaponStatReader");
        }

        private void DONATE_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.me/scobalula");
        }

        private void WEBSITE_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://philmaher.me/");
        }

        private void WEAP_STATS_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://denkirson.proboards.com/thread/4943/call-duty-weapon-attachment-stats");
        }
    }
}
