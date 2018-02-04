using System.Threading.Tasks;
using Grimoire.Networking;

namespace Grimoire.Botting.Commands.Misc
{
    public class CmdPacket : IBotCommand
    {
        public string Packet { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            await Proxy.Instance.SendToServer(Packet);
            await Task.Delay(2000);
        }

        public override string ToString()
        {
            return $"Send packet: {Packet}";
        }
    }
}
