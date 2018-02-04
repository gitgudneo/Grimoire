using Grimoire.Tools;
using Newtonsoft.Json;

namespace Grimoire.Game.Data
{
    public class TempItem
    {
        private string _name;
        [JsonProperty("sName")]
        public string Name
        {
            get => _name;
            set => _name = value?.Trim();
        }

        [JsonProperty("sDesc")]
        public string Description { get; set; }

        [JsonProperty("ItemID")]
        public int Id { get; set; }

        [JsonProperty("iLvl")]
        public int Level { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        [JsonProperty("bCoins")]
        public bool IsAcItem { get; set; }

        [JsonProperty("sLink")]
        public string Link { get; set; }

        [JsonProperty("iQty")]
        public int Quantity { get; set; }

        [JsonProperty("sType")]
        public string Type { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        [JsonProperty("bUpg")]
        public bool IsMemberOnly { get; set; }

        [JsonProperty("iCost")]
        public int Cost { get; set; }

        [JsonProperty("iStk")]
        public int MaxStack { get; set; }

        #region ShouldSerialize
        public bool ShouldSerializeDescription() => false;
        public bool ShouldSerializeLevel() => false;
        public bool ShouldSerializeIsAcItem() => false;
        public bool ShouldSerializeLink() => false;
        public bool ShouldSerializeType() => false;
        public bool ShouldSerializeIsMemberOnly() => false;
        public bool ShouldSerializeCost() => false;
        public bool ShouldSerializeMaxStack() => false;
        #endregion
    }
}
