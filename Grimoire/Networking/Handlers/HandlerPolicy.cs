using System.Xml;

namespace Grimoire.Networking.Handlers
{
    public class HandlerPolicy : IXmlMessageHandler
    {
        public string[] HandledCommands { get; } = {"policy"};

        public void Handle(XmlMessage message)
        {
            XmlAttribute ports = message.Body
                    ?["cross-domain-policy"]
                    ?["allow-access-from"]
                    ?.Attributes
                    ?["to-ports"];

            if (ports != null)
            {
                ports.Value = Proxy.Instance.ListenerPort.ToString();
            }
        }
    }
}
