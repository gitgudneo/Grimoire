using System;
using System.Collections.Generic;
using System.Linq;
using Grimoire.Tools;

namespace Grimoire.Game.Data
{
    public class Bank
    {
        public List<InventoryItem> Items => Flash.Call<List<InventoryItem>>("GetBankItems");

        public int AvailableSlots => TotalSlots - UsedSlots;

        public int UsedSlots => Flash.Call<int>("UsedSlots");

        public int TotalSlots => Flash.Call<int>("BankSlots");

        public void TransferToBank(string itemName) => Flash.Call("TransferToBank", itemName);

        public void TransferFromBank(string itemName) => Flash.Call("TransferToInventory", itemName);

        public void Swap(string invItemName, string bankItemName) => Flash.Call("BankSwap", invItemName, bankItemName);

        public bool ContainsItem(string itemName, string quantity = "*")
        {
            InventoryItem item = 
                Items.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            return item != null && (quantity == "*" || item.Quantity >= int.Parse(quantity));
        }

        public void Show() => Flash.Call("ShowBank");

        public void LoadItems() => Flash.Call("LoadBankItems");
    }
}
