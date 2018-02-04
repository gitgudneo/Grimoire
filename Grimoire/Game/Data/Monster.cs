using Newtonsoft.Json;

namespace Grimoire.Game.Data
{
    public class Monster
    {
        [JsonProperty("sRace")]
        public string Race { get; set; }

        private string _name;
        [JsonProperty("strMonName")]
        public string Name
        {
            get => _name;
            set => _name = value?.Trim();
        }

        [JsonProperty("MonID")]
        public int Id { get; set; }

        [JsonProperty("iLvl")]
        public int Level { get; set; }

        [JsonProperty("intState")]
        public int State { get; set; }

        [JsonProperty("intHP")]
        public int Health { get; set; }

        [JsonProperty("intHPMax")]
        public int MaxHealth { get; set; }
    }
}
