using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Net.Sockets;

namespace Controlpanel
{
    class GetData
    {
        public string RunCommand(string command, SshClient client)
        {

            try
            {

                // Establish Connection to server:
                while (!isEstablishConnection(client))
                {
                    isEstablishConnection(client);
                }
             

                // Get Information:
                var cmd = client.CreateCommand(command);
                var result = cmd.Execute();

                // Disconnect
                client.Disconnect();

                return result;
            }
            catch (SshConnectionException) { return "Error"; }
        }


        public bool CheckConnection(SshClient client)
        {
            client.ConnectionInfo.Timeout = TimeSpan.FromSeconds(5);

            try
            {
                if (!client.IsConnected)
                {
                    client.Connect();
                    client.Disconnect();
                    return true;
                }
                else //client.IsConnected
                {
                    return true;
                }
            }
            catch (SocketException) { return false; }
            catch (SshOperationTimeoutException) { return false; }
        }


        public bool isEstablishConnection(SshClient client)
        {
            client.ConnectionInfo.Timeout = TimeSpan.FromSeconds(5);
            client.HostKeyReceived += delegate (object sender, HostKeyEventArgs e)
            {
                e.CanTrust = true;
            };
            try
            {
                if (!client.IsConnected)
                {
                    client.Connect();

                }
                else //client.IsConnected
                {
                    client.Disconnect();
                    client.Connect();
                    return true;
                }
            }
            catch (SocketException) { return false; }
            catch (SshOperationTimeoutException) { return false; }
            catch (SshConnectionException) { return false; }
            catch (NullReferenceException) { return false; }
            catch (ArgumentException) { return false; }

            return true;
        }
    }
}
