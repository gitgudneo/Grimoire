﻿using Grimoire.Game;
using Grimoire.Game.Data;

namespace Grimoire.Networking.Handlers
{
    public class HandlerQuestComplete : IJsonMessageHandler
    {
        public string[] HandledCommands { get; } = {"ccqr"};

        public void Handle(JsonMessage message)
        {
            Player.Quests.OnQuestCompleted(message.DataObject.ToObject<CompletedQuest>());
        }
    }
}
