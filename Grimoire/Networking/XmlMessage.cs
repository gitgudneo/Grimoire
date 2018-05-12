using System.Xml;

namespace Grimoire.Networking
{
    public class XmlMessage : Message
    {
        public XmlDocument Body { get; }

        public XmlMessage(string raw)
        {
            try
            {
                RawContent = raw;
                Body = new XmlDocument();
                Body.LoadXml(raw);

                if (raw.Contains("cross-domain-policy"))
                    Command = "policy";
                else if (raw.Contains("policy-file-request"))
                    Command = "policyRequest";
                else
                    Command = Body.DocumentElement?["body"]?.Attributes["action"]?.Value;
            }
            catch (XmlException)
            {

            }
        }

        public override string ToString()
        {
            return Body.OuterXml;
        }
    }
}
