using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grimoire.Botting.Commands.Item;
using Grimoire.Botting.Commands.Misc;
using Grimoire.Botting.Commands.Misc.Statements;
using Grimoire.Botting.Commands.Quest;
using Grimoire.Game;

namespace Grimoire.Botting
{
    public static class BotUtilities
    {
        public static async Task WaitUntil(this IBotEngine instance, Func<bool> condition, Func<bool> prerequisite = null, int timeout = 15)
        {
            int iterations = 0;
            while ((prerequisite ?? (() => instance.IsRunning && Player.IsLoggedIn && Player.IsAlive))() 
                && !condition() && (iterations < timeout || timeout == -1))
            {
                await Task.Delay(1000);
                iterations++;
            }
        }

        public static bool RequiresDelay(this IBotCommand cmd)
        {
            return !(cmd is StatementCommand || cmd is CmdIndex || cmd is CmdLabel || cmd is CmdGotoLabel);
        }

        public static void LoadAllQuests(this IBotEngine instance)
        {
            List<int> ids = new List<int>();

            foreach (IBotCommand cmd in instance.Configuration.Commands)
            {
                switch (cmd)
                {
                    case CmdAcceptQuest _:
                        ids.Add(((CmdAcceptQuest)cmd).Quest.Id);
                        break;
                    case CmdCompleteQuest _:
                        ids.Add(((CmdCompleteQuest)cmd).Quest.Id);
                        break;
                }
            }

            ids.AddRange(instance.Configuration.Quests.Select(q => q.Id));
            
            if (ids.Count > 0)
                Player.Quests.Get(ids);
        }

        public static void LoadBankItems(this IBotEngine instance)
        {
            if (instance.Configuration.Commands.Any(c => c is CmdBankSwap || c is CmdBankTransfer))
                Player.Bank.LoadItems();
        }
    }
}
