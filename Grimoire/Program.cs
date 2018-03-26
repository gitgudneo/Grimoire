using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Grimoire.Networking;
using Grimoire.Tools;
using Grimoire.Tools.Plugins;
using Grimoire.UI;

namespace Grimoire
{
    static class Program
    {
        public static string BotsPath { get; private set; }

        public static string PluginsPath { get; private set; }

        public static HotkeyManager HotkeysManager { get; private set; }
        public static PluginManager PluginsManager { get; private set; }

        [STAThread]
        static void Main()
        {
            TryCreateDirectory(BotsPath = Path.Combine(Application.StartupPath, "Bots"));
            TryCreateDirectory(PluginsPath = Path.Combine(Application.StartupPath, "Plugins"));

            if (FindAvailablePort(out int port))
                Proxy.Instance.ListenerPort = port;
            else return;

            HotkeysManager = new HotkeyManager(new KeyboardHook());
            HotkeysManager.LoadHotkeys();

            PluginsManager = new PluginManager();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /* Plugins most likely add an item to the MainForm menustrip,
             let the form load before loading any plugins */
            MainForm.Instance.Load += OnMainFormLoaded;
            Application.Run(MainForm.Instance);
            
            HotkeysManager.Dispose();
            PluginsManager.UnloadAll();
            Proxy.Instance.Stop(true);
        }

        private static void OnMainFormLoaded(object sender, EventArgs e)
        {
            ((Form) sender).Load -= OnMainFormLoaded;
            PluginsManager.LoadRange(Directory.GetFiles(PluginsPath));
        }

        private static void TryCreateDirectory(string dir)
        {
            try
            {
                Directory.CreateDirectory(dir);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show($"Failed to create directory: {dir}\nAccess denied");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show($"Failed to create directory: {dir}\nThe specified path is too long." +
                                "Try moving the Grimoire directory out of the current directory");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create directory {dir}\n{ex.Message}");
            }
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
