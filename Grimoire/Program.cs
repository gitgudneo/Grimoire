using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Grimoire.Networking;
using Grimoire.UI;

namespace Grimoire
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (FindAvailablePort(out int port))
                Proxy.Instance.ListenerPort = port;
            else return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Root());
        }

        private static bool FindAvailablePort(out int port)
        {
            Random random = new Random();
            IPGlobalProperties ipProps = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] conns;
            IPEndPoint[] listeners;

            try
            {
                conns = ipProps.GetActiveTcpConnections();
                listeners = ipProps.GetActiveTcpListeners();
            }
            catch (NetworkInformationException)
            {
                port = 0;
                return false;
            }

            while (true)
            {
                int randPort = random.Next(1001, 65535);

                var conn = conns.FirstOrDefault(c => c.LocalEndPoint.Port == randPort);
                var lis = listeners.FirstOrDefault(l => l.Port == randPort);

                if (conn == null && lis == null)
                {
                    port = randPort;
                    return true;
                }
            }
        }
    }
}
