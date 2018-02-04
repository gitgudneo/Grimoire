using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Grimoire.Game;
using Grimoire.Game.Data;

namespace Grimoire.Tools
{
    public static class Grabber
    {
        public static void GrabQuests(TreeView tree)
        {
            List<Quest> quests = Player.Quests.QuestTree?.OrderBy(q => q.Name).ToList();
            if (quests?.Count > 0)
            {
                foreach (Quest q in quests)
                {
                    TreeNode qNode = tree.Nodes.Add(q.Name);
                    qNode.Nodes.Add($"ID: {q.Id}");
                    if (q.RequiredItems?.Count > 0)
                    {
                        TreeNode reqs = qNode.Nodes.Add("Required items");
                        foreach (InventoryItem i in q.RequiredItems)
                        {
                            TreeNode req = reqs.Nodes.Add(i.Name);
                            req.Nodes.Add($"ID: {i.Id}");
                            req.Nodes.Add($"Quantity: {i.Quantity}");
                        }
                    }
                    if (q.Rewards?.Count > 0)
                    {
                        TreeNode rews = qNode.Nodes.Add("Rewards");
                        foreach (InventoryItem i in q.Rewards)
                        {
                            TreeNode rew = rews.Nodes.Add(i.Name);
                            rew.Nodes.Add($"ID: {i.Id}");
                            rew.Nodes.Add($"Quantity: {i.Quantity}");
                            rew.Nodes.Add($"Drop chance: {i.DropChance}");
                        }
                    }
                }
            }
        }

        public static void GrabShopItems(TreeView tree)
        {
            List<ShopInfo> shops = World.LoadedShops?.OrderBy(s => s.Name).ToList();
            if (shops?.Count > 0)
            {
                foreach (ShopInfo s in shops)
                {
                    TreeNode sNode = tree.Nodes.Add(s.Name);
                    sNode.Nodes.Add($"ID: {s.Id}");
                    sNode.Nodes.Add($"Location: {s.Location}");
                    if (s.Items?.Count > 0)
                    {
                        TreeNode items = sNode.Nodes.Add("Items");
                        foreach (InventoryItem i in s.Items)
                        {
                            TreeNode item = items.Nodes.Add(i.Name);
                            item.Nodes.Add($"Shop item ID: {i.ShopItemId}");
                            item.Nodes.Add($"ID: {i.Id}");
                            item.Nodes.Add($"Cost: {i.Cost} {(i.IsAcItem ? "AC" : "Gold")}");
                            item.Nodes.Add($"Category: {i.Category}");
                        }
                    }
                }
            }
        }

        public static void GrabQuestIds(TreeView tree)
        {
            List<Quest> quests = Player.Quests.QuestTree?.OrderBy(q => q.Name).ToList();
            if (quests?.Count > 0)
                foreach (Quest q in quests)
                    tree.Nodes.Add($"{q.Id} - {q.Name}");
        }

        public static void GrabInventoryItems(TreeView tree) => GrabItems(tree, true);

        public static void GrabBankItems(TreeView tree) => GrabItems(tree, false);

        private static void GrabItems(TreeView tree, bool inventory)
        {
            List<InventoryItem> items =
                (inventory ? Player.Inventory.Items : Player.Bank.Items)?.OrderBy(i => i.Name).ToList();
            if (items?.Count > 0)
            {
                foreach (InventoryItem i in items)
                {
                    TreeNode item = tree.Nodes.Add(i.Name);
                    item.Nodes.Add($"ID: {i.Id}");
                    item.Nodes.Add($"Char item id: {i.CharItemId}");
                    item.Nodes.Add($"Quantity: {i.Quantity}");
                    item.Nodes.Add($"AC tagged: {i.IsAcItem}");
                    item.Nodes.Add($"Category: {i.Category}");
                    item.Nodes.Add($"Max stack: {i.MaxStack}");
                }
            }
        }

        public static void GrabTempItems(TreeView tree)
        {
            List<TempItem> items = Player.TempInventory.Items?.OrderBy(i => i.Name).ToList();
            if (items?.Count > 0)
            {
                foreach (TempItem i in items)
                {
                    TreeNode item = tree.Nodes.Add(i.Name);
                    item.Nodes.Add($"ID: {i.Id}");
                    item.Nodes.Add($"Quantity: {i.Quantity}");
                }
            }
        }

        public static void GrabMonsters(TreeView tree)
        {
            List<Monster> mons = World.AvailableMonsters?.GroupBy(m => m.Name).Select(x => x.First()).ToList();
            if (mons?.Count > 0)
            {
                foreach (Monster mon in mons)
                {
                    TreeNode m = tree.Nodes.Add(mon.Name);
                    m.Nodes.Add($"ID: {mon.Id}");
                    m.Nodes.Add($"Race: {mon.Race}");
                    m.Nodes.Add($"Level: {mon.Level}");
                    m.Nodes.Add($"Health: {mon.Health}");
                    m.Nodes.Add($"Max health: {mon.MaxHealth}");
                }
            }
        }
    }
}
