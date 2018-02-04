using Grimoire.Game.Data;
using Grimoire.Tools;

namespace Grimoire.Game
{
    public static class Player
    {
        public enum State
        {
            Dead = 0,
            Idle = 1,
            InCombat = 2
        }

        public static Bank Bank { get; } = new Bank();
        public static Inventory Inventory { get; } = new Inventory();
        public static TempInventory TempInventory { get; } = new TempInventory();
        public static Quests Quests { get; } = new Quests();

        public static bool IsLoggedIn => Flash.Call<bool>("IsLoggedIn");
        public static string Cell => Flash.Call<string>("Cell");
        public static string Pad => Flash.Call<string>("Pad");
        public static State CurrentState => (State)Flash.Call<int>("State");
        public static int Health => Flash.Call<int>("Health");
        public static int HealthMax => Flash.Call<int>("HealthMax");
        public static bool IsAlive => Health > 0;
        public static int Mana => Flash.Call<int>("Mana");
        public static int ManaMax => Flash.Call<int>("ManaMax");
        public static string Map => Flash.Call<string>("Map");
        public static int Level => Flash.Call<int>("Level");
        public static int Gold => Flash.Call<int>("Gold");
        public static bool HasTarget => Flash.Call<bool>("HasTarget");
        public static bool AllSkillsAvailable => Flash.Call<bool>("AllSkillsAvailable");
        public static bool IsAfk => Flash.Call<bool>("IsAfk");
        public static float[] Position => Flash.Call<float[]>("Position");

        public static void WalkToPoint(string x, string y) => Flash.Call("WalkToPoint", x, y);
        public static void CancelTarget() => Flash.Call("CancelTarget");
        public static void AttackMonster(string name) => Flash.Call("AttackMonster", name);
        public static void MoveToCell(string cell, string pad = "Spawn") => Flash.Call("Jump", cell, pad);
        public static void Rest() => Flash.Call("Rest");
        public static void JoinMap(string map, string cell = "Enter", string pad = "Spawn") => Flash.Call("Join", map, cell, pad);
        public static void Equip(string id) => Flash.Call("Equip", id);
        public static void Equip(int id) => Flash.Call("Equip", id.ToString());
        public static void GotoPlayer(string name) => Flash.Call("GoTo", name);
        public static bool HasActiveBoost(string name) => Flash.Call<bool>("HasActiveBoost", name);
        public static void UseBoost(string id) => Flash.Call("UseBoost", id);
        public static void UseBoost(int id) => Flash.Call("UseBoost", id.ToString());
        public static void UseSkill(string index) => Flash.Call("UseSkill", index);
        public static void GetMapItem(string id) => Flash.Call("GetMapItem", id);
        public static void GetMapItem(int id) => Flash.Call("GetMapItem", id.ToString());
        public static void GoToPlayer(string name) => Flash.Call("GoTo", name);
        public static void Logout() => Flash.Call("Logout");
    }
}
