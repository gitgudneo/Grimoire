using System;
using System.Collections.Generic;
using Grimoire.Game.Data;
using Grimoire.Tools;

namespace Grimoire.Game
{
    public enum LockActions
    {
        LoadShop,
        LoadEnhShop,
        LoadHairShop,
        EquipItem,
        UnequipItem,
        BuyItem,
        SellItem,
        GetMapItem,
        TryQuestComplete,
        AcceptQuest,
        DoIA,
        Rest,
        Who,
        Transfer
    }

    public static class World
    {
        public static event Action<InventoryItem> ItemDropped;
        public static event Action<ShopInfo> ShopLoaded;

        public static List<ShopInfo> LoadedShops = new List<ShopInfo>();
        public static DropStack DropStack = new DropStack();

        public static void OnItemDropped(InventoryItem drop) => ItemDropped?.Invoke(drop);

        public static void OnShopLoaded(ShopInfo shopInfo)
        {
            ShopLoaded?.Invoke(shopInfo);
            LoadedShops.Add(shopInfo);
        }

        private static readonly Dictionary<LockActions, string> LockedActions = new Dictionary<LockActions, string>(14)
        {
            {LockActions.LoadShop, "loadShop"},
            {LockActions.LoadEnhShop, "loadEnhShop"},
            {LockActions.LoadHairShop, "loadHairShop"},
            {LockActions.EquipItem, "equipItem"},
            {LockActions.UnequipItem, "unequipItem"},
            {LockActions.BuyItem, "buyItem"},
            {LockActions.SellItem, "sellItem"},
            {LockActions.GetMapItem, "getMapItem"},
            {LockActions.TryQuestComplete, "tryQuestComplete"},
            {LockActions.AcceptQuest, "acceptQuest"},
            {LockActions.DoIA, "doIA"},
            {LockActions.Rest, "rest"},
            {LockActions.Who, "who"},
            {LockActions.Transfer, "tfer"}
        };

        public static List<Monster> AvailableMonsters => Flash.Call<List<Monster>>("GetMonstersInCell");

        public static List<Monster> VisibleMonsters = Flash.Call<List<Monster>>("GetVisibleMonstersInCell");

        public static bool IsMapLoading => !Flash.Call<bool>("MapLoadComplete");

        public static List<string> PlayersInMap => Flash.Call<List<string>>("PlayersInMap");

        public static List<InventoryItem> ItemTree => Flash.Call<List<InventoryItem>>("GetItemTree");

        public static bool IsActionAvailable(LockActions action) => Flash.Call<bool>("IsActionAvailable", LockedActions[action]);

        public static void SetSpawnPoint() => Flash.Call("SetSpawnPoint");

        public static bool IsMonsterAvailable(string name) => Flash.Call<bool>("IsMonsterAvailable", name);

        public static string[] Cells => Flash.Call<string[]>("GetCells");

        public static int RoomId => Flash.Call<int>("RoomId");
    }
}
