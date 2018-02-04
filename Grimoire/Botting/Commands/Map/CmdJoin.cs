using System;
using System.Threading.Tasks;
using Grimoire.Game;

namespace Grimoire.Botting.Commands.Map
{
    public class CmdJoin : IBotCommand
    {
        public string Map { get; set; }
        public string Cell { get; set; }
        public string Pad { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            await instance.WaitUntil(() => World.IsActionAvailable(LockActions.Transfer));
            string cmdMap = Map.Contains("-") ? Map.Split('-')[0] : Map;
            string curMap = Player.Map;

            if (!cmdMap.Equals(curMap, StringComparison.OrdinalIgnoreCase))
            {
                await instance.WaitUntil(() => World.IsActionAvailable(LockActions.Transfer));

                if (Player.CurrentState == Player.State.InCombat)
                {
                    Player.MoveToCell(Player.Cell, Player.Pad);
                    await instance.WaitUntil(() => Player.CurrentState == Player.State.InCombat);
                }

                Player.JoinMap(Map, Cell, Pad);
                await instance.WaitUntil(() => Player.Map.Equals(cmdMap, StringComparison.OrdinalIgnoreCase));
                await instance.WaitUntil(() => !World.IsMapLoading, null, 40);

                if (!Player.Cell.Equals(Cell, StringComparison.OrdinalIgnoreCase))
                {
                    Player.MoveToCell(Cell, Pad);
                    await Task.Delay(500);
                }
            }
        }

        public override string ToString()
        {
            return $"Join: {Map}, {Cell}, {Pad}";
        }
    }
}
