using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class Item
    {
        [JsonInclude]
        public string name;
        [JsonInclude]
        public int base_damage;
        [JsonInclude]
        private string description;
        [JsonInclude]
        public int base_health_recovery;
    }
}
