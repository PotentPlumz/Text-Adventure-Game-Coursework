using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class Player
    {
        [JsonInclude]
        private string name;
        [JsonInclude]
        private bool is_alive = true;
        [JsonInclude]
        private int max_health = 50;
        [JsonInclude]
        private float health = 15;
        [JsonInclude]
        private List<Item> inventory = new List<Item>();
        [JsonIgnore]
        private int occupying_room_number;
        

        public void Regen_Health(float amount)
        {
            this.health += amount;

            if (this.health > max_health)
                this.health = max_health;
        }
        public void Set_Player_Location(int room_number)
        {
            this.occupying_room_number = room_number;
        }

        public void Take_Damage(float amount)
        {
            this.health -= amount;
            if (this.health <= 0)
                this.is_alive = false;
        }

        public void Set_Name(string name)
        {
            this.name = name;
        }
        public string Get_Name()
        {
            return this.name;
        }

        public bool Check_Health()
        {
            if (this.health <= 0)
            {
                this.is_alive = false;
            }
            return this.is_alive;
        }

        public void Pickup_Item(Item item)
        {
            this.inventory.Add(item);
        }

        public void Drop_Item(Item item)
        {
            this.inventory.Remove(item);
        }
    }
}

