using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class Player
    {
        [JsonInclude]
        public string name;
        [JsonInclude]
        public bool is_alive = true;
        [JsonInclude]
        private int max_health = 50;
        [JsonInclude]
        public float health = 15;
        [JsonInclude]
        public List<Item> inventory = new List<Item>();

        public void regen_health(float amount)
        {
            this.health += amount;

            if (this.health > max_health)
                this.health = max_health;
        }
        public void take_damage(float amount)
        {
            this.health -= amount;
            if (this.health <= 0)
                this.is_alive = false;
        }
    }
}

