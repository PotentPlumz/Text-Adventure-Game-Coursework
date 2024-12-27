using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class Enemy
    {
        [JsonInclude]
        public string name;
        [JsonInclude]
        public float damage1;
        [JsonInclude]
        public float damage2;
        [JsonInclude]
        public bool is_alive = true;
        [JsonInclude]
        public float health;

        public void regen_health(float amount)
        {
            this.health += amount;

        }
        public void take_damage(float amount)
        {
            this.health -= amount;
            if (this.health <= 0)
                this.is_alive = false;
        }
    }
}

