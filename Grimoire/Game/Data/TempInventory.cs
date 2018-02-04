using System;
using System.Collections.Generic;
using System.Linq;
using Grimoire.Tools;

namespace Grimoire.Game.Data
{
    public class TempInventory
    {
        public List<TempItem> Items => Flash.Call<List<TempItem>>("GetTempItems");

        public bool ContainsItem(string name, string qty)
        {
            TempItem item = Items.FirstOrDefault(i => 
                i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (item == null)
                return false;

            return qty == "*" || item.Quantity >= int.Parse(qty);
        }
    }
}
