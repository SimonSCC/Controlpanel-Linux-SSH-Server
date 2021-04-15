using Renci.SshNet;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Diagnostics;

namespace Controlpanel
{
    public partial class MainWindow : Window
    {
        GetData getData = new GetData();
        CustomServerChecker CSC = new CustomServerChecker();

        SshClient danielClient = new SshClient("37.97.6.112", 7777, "daniel", "danielersej");
        SshClient simonClient = new SshClient("80.167.81.52", 7777, "dragonslayer420", "cooldragon"); //Extern
        //SshClient simonClient = new SshClient("192.168.0.39", 7777, "dragonslayer420", "cooldragon"); //Local

        public SshClient customClient { get; set; }
        string customServerPassword;



        public MainWindow()
        {
            InitializeComponent();
        }



        private void Window_Initialized(object sender, EventArgs e)
        {
            Task.Run(() => checkConnection(simonClient, SimonStatus, SimonMoreInfo, SimonReboot));
            Task.Run(() => checkConnection(danielClient, DanielStatus, DanielMoreInfo, DanielReboot));
        }


        public void checkConnection(SshClient client, Ellipse status, Button moreInfoButton, Button rebootButton)
        {
            while (true)
            {
                if (client != null)
                {
                    if (getData.CheckConnection(client))
                    {
                        status.Dispatcher.Invoke(() => status.Fill = Brushes.Green);
                        moreInfoButton.Dispatcher.Invoke(() => moreInfoButton.IsEnabled = true);
                        rebootButton.Dispatcher.Invoke(() => rebootButton.IsEnabled = true);
                    }
                    else
                    {
                        status.Dispatcher.Invoke(() => status.Fill = Brushes.Red);
                        moreInfoButton.Dispatcher.Invoke(() => moreInfoButton.IsEnabled = false);
                        rebootButton.Dispatcher.Invoke(() => rebootButton.IsEnabled = false);
                    }
                }
                Thread.Sleep(5000);
            }
        }


        private void SimonMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            MoreInfoWindow moreInfoSimon = new MoreInfoWindow(simonClient, "Simon - Server");
            moreInfoSimon.ShowDialog();
        }


        public void DanielMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            MoreInfoWindow moreInfoDaniel = new MoreInfoWindow(danielClient, "Daniel - Server");
            moreInfoDaniel.ShowDialog();
        }


        public void DanielReboot_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to reboot the server?", "Warning!", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    getData.RunCommand("echo 'echo danielersej | sudo -S echo && sudo -s reboot' > reboot.sh && chmod 777 reboot.sh", danielClient);
                    getData.RunCommand("sh reboot.sh", danielClient);
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }


        private void SimonReboot_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to reboot the server?", "Warning!", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    getData.RunCommand("echo 'echo cooldragon | sudo -S echo && sudo -s reboot' > reboot.sh && chmod 777 reboot.sh", simonClient);
                    getData.RunCommand("sh reboot.sh", simonClient);
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            foreach (Process proc in Process.GetProcessesByName("Controlpanel"))
            {
                proc.Kill();
            }
        }



        private void CustomReboot_Click(object sender, RoutedEventArgs e) //need variable as password
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to reboot the server?", "Warning!", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    getData.RunCommand("echo 'echo " + customServerPassword + " | sudo -S echo && sudo -s reboot' > reboot.sh && chmod 777 reboot.sh", customClient);
                    getData.RunCommand("sh reboot.sh", customClient);
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }


        private void CustomMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            MoreInfoWindow moreInfoCustom = new MoreInfoWindow(customClient, "Custom - Server");
            moreInfoCustom.ShowDialog();
        }


        private void CustomEdit_Click(object sender, RoutedEventArgs e)
        {
            EditWindow CustomEdit = new EditWindow(CSC);
            CustomEdit.Show();
            CustomEdit.Closing += CustomEdit_Closing;
        }


        private void CustomEdit_Closing(object sender, EventArgs e)
        {

            customClient = CSC.customClient;
            if (CSC.customIP != null)
            {
                DynamicCustomIp.Text = CSC.customIP;
            }
            if (CSC.customPassword != null)
            {
                customServerPassword = CSC.customPassword;
            }

            Task.Run(() => checkConnection(customClient, CustomStatus, CustomMoreInfo, CustomReboot));
        }
    }
}
