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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace widget_Clock
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, (object s, EventArgs ev) =>
            {
                this.cTime.Text = DateTime.Now.ToString("T");
                this.cDate.Text = DateTime.Now.ToString("D");
            }, this.Dispatcher);
            timer.Start();

            TimeZoneInfo timeZone = TimeZoneInfo.Local;
            tz.Text = timeZone.DisplayName.ToString();

            try
            {
                ip.Text = new System.Net.WebClient().DownloadString("https://ipv4.icanhazip.com/");
            }
            catch
            {
                ip.Text = "Check your network connection";
            }
        }
    }
}
