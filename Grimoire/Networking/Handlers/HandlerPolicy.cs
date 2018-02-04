namespace Grimoire.Networking.Handlers
{
    public class HandlerPolicy : IXmlMessageHandler
    {
        public string[] HandledCommands { get; } = {"policy"};

        public void Handle(XmlMessage message)
        {
            var ports = message.Body?["cross-domain-policy"]?["allow-access-from"];
            if (ports != null)
                ports.Attributes["to-ports"].Value = Proxy.Instance.ListenerPort.ToString();
        }
    }
}
