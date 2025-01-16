using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class Enemy
    {
        [JsonInclude]
        private string name;
        [JsonInclude]
        private float damage1;
        [JsonInclude]
        private float damage2;
        [JsonInclude]
        private bool is_alive = true;
        [JsonInclude]
        private float health;

        public Enemy()
        { }

        public void Regen_Health(float amount)
        {
            this.health += amount;

        }
        public void Take_Damage(float amount)
        {
            this.health -= amount;
            if (this.health <= 0)
                this.is_alive = false;
        }
        public void Set_Max_Health(float amount)
        {
            this.health = amount;
        }
        public bool Check_If_Alive()
        {
            return this.is_alive;
        }
        public void Commence_Attack()
        {

        }
    }
}

