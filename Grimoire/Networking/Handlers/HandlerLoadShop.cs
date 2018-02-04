using Grimoire.Game;
using Grimoire.Game.Data;

namespace Grimoire.Networking.Handlers
{
    public class HandlerLoadShop : IJsonMessageHandler
    {
        public string[] HandledCommands { get; } = {"loadShop"};

        public void Handle(JsonMessage message)
        {
            var shopInfo = message.DataObject["shopinfo"];
            if (shopInfo != null)
                World.OnShopLoaded(shopInfo.ToObject<ShopInfo>());
        }
    }
}
