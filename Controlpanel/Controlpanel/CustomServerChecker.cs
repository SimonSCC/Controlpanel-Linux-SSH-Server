using Renci.SshNet;

namespace Controlpanel
{
    public class CustomServerChecker
    {
        public SshClient customClient { get; set; }
        public string customIP { get; set; }
        public string customPassword { get; set; }


        public void CreateClient(string ip, int port, string username, string password)
        {
            customIP = ip;
            customPassword = password;
            customClient = new SshClient(ip, port, username, password);
        }
    }
}
