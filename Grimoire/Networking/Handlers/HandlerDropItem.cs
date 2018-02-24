using System;
using System.Collections.Generic;
using System.Linq;
using Grimoire.Game;
using Grimoire.Game.Data;
using Grimoire.UI;
using Newtonsoft.Json.Linq;

namespace Grimoire.Networking.Handlers
{
    public class HandlerDropItem : IJsonMessageHandler
    {
        public string[] HandledCommands { get; } = {"dropItem"};

        public void Handle(JsonMessage message)
        {
            JToken j = message.DataObject?["items"];

            if (j != null)
            {
                InventoryItem item = j.ToObject<Dictionary<int, InventoryItem>>().First().Value;

                if (BotManagerForm.Instance.ActiveBotEngine.IsRunning)
                {
                    var config = BotManagerForm.Instance.ActiveBotEngine.Configuration;

                    message.Send = !(config.EnableRejection && config.Drops.All(
                                                  d => !d.Equals(item.Name, StringComparison.OrdinalIgnoreCase)));
                }

                World.OnItemDropped(item);
            }
        }
    }
}
