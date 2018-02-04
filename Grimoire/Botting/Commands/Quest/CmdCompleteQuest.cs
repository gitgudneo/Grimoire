using System.Threading.Tasks;
using Grimoire.Game;

namespace Grimoire.Botting.Commands.Quest
{
    public class CmdCompleteQuest : IBotCommand
    {
        public Game.Data.Quest Quest { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            await instance.WaitUntil(() => World.IsActionAvailable(LockActions.TryQuestComplete));

            if (Player.Quests.CanComplete(Quest.Id))
            {
                if (instance.Configuration.ExitCombatBeforeQuest)
                {
                    Player.MoveToCell(Player.Cell, Player.Pad);
                    await instance.WaitUntil(() => Player.CurrentState != Player.State.InCombat);
                }

                Quest.Complete();
                await instance.WaitUntil(() => !Player.Quests.IsInProgress(Quest.Id));
            }
        }

        public override string ToString()
        {
            return $"Complete quest: {(Quest.ItemId != null && Quest.ItemId != "0" ? $"{Quest.Id}:{Quest.ItemId}" : Quest.Id.ToString())}";
        }
    }
}
