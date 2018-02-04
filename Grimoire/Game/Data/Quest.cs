using System.Collections.Generic;
using Grimoire.Tools;
using Newtonsoft.Json;

namespace Grimoire.Game.Data
{
    public class Quest
    {
        [JsonProperty("sFaction")]
        public string Faction { get; set; }

        [JsonProperty("iClass")]
        public int ClassPointsReward { get; set; }

        [JsonProperty("sDesc")]
        public string Description { get; set; }

        [JsonProperty("iReqRep")]
        public int RequiredReputation { get; set; }

        [JsonProperty("iRep")]
        public int ReputationReward { get; set; }

        [JsonProperty("iLvl")]
        public int Level { get; set; }

        public List<InventoryItem> RequiredItems { get; set; }

        [JsonProperty("iGold")]
        public int GoldReward { get; set; }

        [JsonProperty("iReqCP")]
        public int RequiredClassPoints { get; set; }

        [JsonProperty("QuestID")]
        public int Id { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        [JsonProperty("bOnce")]
        public bool IsNotRepeatable { get; set; }

        [JsonProperty("iExp")]
        public int ExperienceReward { get; set; }

        public List<InventoryItem> Rewards { get; set; }

        [JsonProperty("sName")]
        public string Name { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        [JsonProperty("bUpg")]
        public bool IsMemberOnly { get; set; }

        [JsonProperty("FactionID")]
        public int FactionId { get; set; }

        public string ItemId { get; set; }

        public string Text { get; set; }

        public void Accept() => Flash.Call("Accept", Id.ToString());

        public void Complete()
        {
            if (!string.IsNullOrEmpty(ItemId))
                Flash.Call("Complete", Id.ToString(), ItemId);
            else
                Flash.Call("Complete", Id.ToString());
        }

        public bool IsInProgress => Flash.Call<bool>("IsInProgress", Id.ToString());

        public bool CanComplete => Flash.Call<bool>("CanComplete", Id.ToString());

        #region ShouldSerialize
        public bool ShouldSerializeFaction() => false;
        public bool ShouldSerializeClassPointsReward() => false;
        public bool ShouldSerializeDescription() => false;
        public bool ShouldSerializeRequiredReputation() => false;
        public bool ShouldSerializeReputationReward() => false;
        public bool ShouldSerializeLevel() => false;
        public bool ShouldSerializeGoldReward() => false;
        public bool ShouldSerializeRequiredClassPoints() => false;
        public bool ShouldSerializeIsNotRepeatable() => false;
        public bool ShouldSerializeExperienceReward() => false;
        public bool ShouldSerializeRewards() => false;
        public bool ShouldSerializeName() => false;
        public bool ShouldSerializeIsMemberOnly() => false;
        public bool ShouldSerializeFactionId() => false;
        public bool ShouldSerializeIsInProgress() => false;
        public bool ShouldSerializeCanComplete() => false;
        #endregion
    }
}
