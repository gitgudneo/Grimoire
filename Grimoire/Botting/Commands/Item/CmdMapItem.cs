﻿using System.Threading.Tasks;
using Grimoire.Game;

namespace Grimoire.Botting.Commands.Item
{
    public class CmdMapItem : IBotCommand
    {
        public int ItemId { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            await instance.WaitUntil(() => World.IsActionAvailable(LockActions.GetMapItem));
            Player.GetMapItem(ItemId);
            await Task.Delay(2000);
        }

        public override string ToString()
        {
            return $"Get map item: {ItemId}";
        }
    }
}
