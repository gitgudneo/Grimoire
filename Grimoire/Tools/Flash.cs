using System;
using System.Text;
using Grimoire.UI;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using AxShockwaveFlashObjects;
using Grimoire.Game;
using Grimoire.Game.Data;
using Grimoire.Networking;
using Grimoire.UI.BotForms;
using Newtonsoft.Json;

namespace Grimoire.Tools
{
    public static class Flash
    {
        public static event Action<int> SwfLoadProgress;

        public static void ProcessFlashCall(object sender, _IShockwaveFlashEvents_FlashCallEvent e)
        {
            XElement req = XElement.Parse(e.request);
            string function = req.Attribute("name")?.Value;
            string arg = req.Element("arguments")?.Value;
            
            switch (function)
            {
                case "progress":
                    SwfLoadProgress?.Invoke(int.Parse(arg));
                    break;
                case "modifyServers":
                    Root.Instance.Client.SetReturnValue("<string>" + ModifyServerList(arg.Trim()) + "</string>");
                    break;
                case "disconnect":
                    Proxy.Instance.Stop(false);
                    World.DropStack.Clear();
                    break;
            }
        }

        public static T Call<T>(string function, params string[] args)
        {
            return TryDeserialize<T>(GetResponse(BuildRequest(function, args)));
        }

        public static void Call(string function, params string[] args)
        {
            Call<string>(function, args);
        }

        private static string BuildRequest(string method, params string[] args)
        {
            /* All arguments have to be passed as strings, apparently. Passing any other type
               causes strange, erroneous behaviour... */

            StringBuilder sb = new StringBuilder();
            sb.Append($"<invoke name=\"{method}\" returntype=\"xml\">");
            if (args?.Length > 0)
            {
                sb.Append("<arguments>");
                foreach (string arg in args)
                    sb.Append($"<string>{arg}</string>");
                sb.Append("</arguments>");
            }
            sb.Append("</invoke>");
            return sb.ToString();
        }

        private static string GetResponse(string request)
        {
            try
            {
                return 
                    HttpUtility.HtmlDecode(
                    XElement.Parse(
                    Root.Instance.Client.CallFunction(request)).FirstNode?.ToString() ?? string.Empty);
            }
            /* Catch any exceptions and ignore them to keep the bot running. If an ExternalInterface 
               call fails, nothing can be done */
            catch
            {
                return string.Empty;
            } 
        }

        private static T TryDeserialize<T>(string str)
        {
            try {return JsonConvert.DeserializeObject<T>(str);}
            catch {return default(T);}
        }

        /* The XML string received upon logging in is passed to this method. Modify this string before
         passing it back to the game client (set port to listener port and set all IP addresses 
         to 127.0.0.1, add a property "RealAddress" so that the proxy can connect to the correct 
         game server */
        private static string ModifyServerList(string xml)
        {
            if (!(xml.StartsWith("<login") && xml.EndsWith("</login>")))
                return xml;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            
            XmlElement login = doc["login"];

            Server[] servers = new Server[login.ChildNodes.Count];

            for (int i = 0; i < login.ChildNodes.Count; i++)
            {
                XmlElement a = (XmlElement) login.ChildNodes[i];
                XmlAttribute ip = a.Attributes["sIP"];
                a.Attributes.Append(doc.CreateAttribute("RealAddress")).Value = ip.Value;
                a.Attributes["iPort"].Value = Proxy.Instance.ListenerPort.ToString();
                ip.Value = "127.0.0.1";

                servers[i] = new Server
                {
                    IsChatRestricted = a.Attributes["iChat"].Value == "0",
                    PlayerCount = int.Parse(a.Attributes["iCount"].Value),
                    IsMemberOnly = a.Attributes["bUpg"].Value == "1",
                    IsOnline = a.Attributes["bOnline"].Value == "1",
                    Name = a.Attributes["sName"].Value,
                    Port = int.Parse(a.Attributes["iPort"].Value)
                };
            }

            OptionsTab.Instance.OnServersLoaded(servers);

            return doc.OuterXml;
        }
    }
}
