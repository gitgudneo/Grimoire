using System;
using System.Collections.Generic;
using System.Linq;
using Grimoire.Tools;

namespace Grimoire.Game.Data
{
    public class Inventory
    {
        public List<InventoryItem> Items => Flash.Call<List<InventoryItem>>("GetInventoryItems");

        public int MaxSlots => Flash.Call<int>("InventorySlots");

        public int UsedSlots => Flash.Call<int>("UsedInventorySlots");

        public int AvailableSlots => MaxSlots - UsedSlots;

        public bool ContainsItem(string name, string quantity)
        {
            InventoryItem item =
                Items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return item != null && (quantity == "*" || item.Quantity >= int.Parse(quantity));
        }

        public bool ContainsItem(string name, int quantity)
        {
            InventoryItem item =
                Items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return item != null && item.Quantity >= quantity;
        }
    }
}
