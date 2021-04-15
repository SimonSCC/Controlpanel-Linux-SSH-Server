using Renci.SshNet;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Controlpanel
{
    public partial class MoreInfoWindow : Window
    {
        SshClient currentClient;
        string pcName;
        GetData getData = new GetData();
        bool shouldRun = true;


        public MoreInfoWindow(SshClient client, string computerName)
        {
            currentClient = client;
            pcName = computerName;

            InitializeComponent();
        }


        public void GetServerInformation()
        {
            // Commands:
            string uptimeCmd = "uptime -p | sed \"s/up //\"";
            string cpuUsageCmd = "top -bn 2 -d 0.01 | grep '^%Cpu' | tail -n 1 | gawk '{print $2}' | sed 's/$/ %/'";

            string diskAvaliableCmd = "df -h | grep '/dev/sd' | awk '{print $2}' | sed 's/G/ GB/' | sed 's/M/ MB/'";
            string diskUsedCmd = "df -h | grep '/dev/sd' | awk '{print $3}' | sed 's/G/ GB/' | sed 's/M/ MB/'";

            string secondDiskAvailableCmd = "df -h | grep '/dev/vd' | awk '{print $2}' | sed 's/G/ GB/' | sed 's/M/ MB/'";
            string seconddiskUsedCmd = "df -h | grep '/dev/vd' | awk '{print $3}' | sed 's/G/ GB/' | sed 's/M/ MB/'";

            string ramTotalCmd = "free -m | grep \"Mem:\" | awk '{print $2}' | sed 's/$/ MB/'";
            string ramUsageCmd = "free -m | grep \"Mem:\" | awk '{print $3}' | sed 's/$/ MB/'";

            string processesCmd = "ps aux | awk '{print $1 \"\\t\" $2 \"\\t\" $3 \"\\t\" $4 \"\\t\" $9 \"\\t\" $10 \"\\t\" $11}'";

            string uptime = null;
            string cpuUsage = null;
            string diskAvaliable = null;
            string diskUsed = null;
            string ramTotal = null;
            string ramUsage = null;
            string processes = null;


            // Run Commands:
            while (uptime == null || uptime == "Error")
            {
                uptime = getData.RunCommand(uptimeCmd, currentClient).Replace("\n", "");
            }

            while (cpuUsage == null || cpuUsage == "Error")
            {
                cpuUsage = getData.RunCommand(cpuUsageCmd, currentClient).Replace("\n", "");

            }

            while (diskAvaliable == null || diskAvaliable == "Error")
            {
                diskAvaliable = getData.RunCommand(diskAvaliableCmd, currentClient);

                if (diskAvaliable == null || diskAvaliable == "Error" || diskAvaliable == "")
                {
                    diskAvaliable = getData.RunCommand(secondDiskAvailableCmd, currentClient);
                }

            }

            while (diskUsed == null || diskUsed == "Error")
            {
                diskUsed = getData.RunCommand(diskUsedCmd, currentClient);
                if (diskUsed == null || diskUsed == "Error" || diskUsed == "")
                {
                    diskUsed = getData.RunCommand(seconddiskUsedCmd, currentClient);
                }

            }

            while (ramTotal == null || ramTotal == "Error")
            {
                ramTotal = getData.RunCommand(ramTotalCmd, currentClient);
            }

            while (ramUsage == null || ramUsage == "Error")
            {
                ramUsage = getData.RunCommand(ramUsageCmd, currentClient);
            }

            while (processes == null || processes == "Error")
            {
                processes = getData.RunCommand(processesCmd, currentClient);
            }


            // Format:
            string disk = diskUsed.Replace("\n", "") + " used of " + diskAvaliable.Replace("\n", "");
            string ram = ramUsage.Replace("\n", "") + " used of " + ramTotal.Replace("\n", "");
            if (cpuUsage == "us, %") cpuUsage = "100.0 %";


            // Place values:
            computer.Dispatcher.Invoke(() => computer.Content = pcName);
            Uptime.Dispatcher.Invoke(() => Uptime.Text = uptime);
            Disk.Dispatcher.Invoke(() => Disk.Text = disk);
            RAM.Dispatcher.Invoke(() => RAM.Text = ram);
            CPU.Dispatcher.Invoke(() => CPU.Text = cpuUsage);

            Processes.Dispatcher.Invoke(() => Processes.Text = processes);
        }


        private async void Window_Initialized(object sender, EventArgs e)
        {
            shouldRun = true;
            Title = pcName;

            while (shouldRun)
            {
                await Task.Run(() => GetServerInformation());
            }
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            shouldRun = false;
        }
    }
}
