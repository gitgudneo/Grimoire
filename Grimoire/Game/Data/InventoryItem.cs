using System.Linq;
using Grimoire.Tools;
using Newtonsoft.Json;

namespace Grimoire.Game.Data
{
    public class InventoryItem
    {
        [JsonProperty("iQty")]
        public int Quantity { get; set; }
        
        [JsonProperty("sDesc")]
        public string Description { get; set; }

        [JsonProperty("iStk")]
        public int MaxStack { get; set; }

        [JsonProperty("iLvl")]
        public int Level { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        [JsonProperty("bCoins")]
        public bool IsAcItem { get; set; }

        public int CharItemId { get; set; }

        [JsonProperty("sLink")]
        public string Link { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        [JsonProperty("bEquip")]
        public bool IsEquipped { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        [JsonProperty("bUpg")]
        public bool IsMemberOnly { get; set; }

        [JsonProperty("iCost")]
        public int Cost { get; set; }

        [JsonProperty("sType")]
        public string Category { get; set; }

        [JsonProperty("ItemID")]
        public int Id { get; set; }

        private string _name;
        [JsonProperty("sName")]
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                    _name = World.ItemTree.FirstOrDefault(i => i.Id == Id)?.Name;
                return _name;
            }
            set => _name = value?.Trim();
        }

        [JsonProperty("ShopItemID")]
        public int ShopItemId { get; set; }

        public string DropChance { get; set; }

        public static readonly string[] EquippableCategories =
        {
            "Sword", "Axe", "Dagger", "Gun", "Bow", "Mace", "Polearm", "Staff", "Wand",
            "Class", "Armor", "Helm", "Cape"
        };

        public bool IsEquippable => EquippableCategories.Contains(Category);

        #region ShouldSerialize
        public bool ShouldSerializeDescription() => false;
        public bool ShouldSerializeMaxStack() => false;
        public bool ShouldSerializeLevel() => false;
        public bool ShouldSerializeIsAcItem() => false;
        public bool ShouldSerializeLink() => false;
        public bool ShouldSerializeIsEquipped() => false;
        public bool ShouldSerializeIsMemberOnly() => false;
        public bool ShouldSerializeCost() => false;
        public bool ShouldSerializeCategory() => false;
        public bool ShouldSerializeShopItemId() => false;
        public bool ShouldSerializeDropChance() => false;
        #endregion
    }
}
