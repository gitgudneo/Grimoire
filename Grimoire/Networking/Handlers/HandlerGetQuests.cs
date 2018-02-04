using System.Collections.Generic;
using System.Linq;
using Grimoire.Game;
using Grimoire.Game.Data;

namespace Grimoire.Networking.Handlers
{
    public class HandlerGetQuests : IJsonMessageHandler
    {
        public string[] HandledCommands { get; } = {"getQuests"};

        public void Handle(JsonMessage message)
        {
            var quests = message.DataObject?["quests"]?.ToObject<Dictionary<int, Quest>>();
            if (quests?.Count > 0)
                Player.Quests.OnQuestsLoaded(quests.Select(q => q.Value).ToList());
        }
    }
}
