using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class Enemy
    {
        [JsonInclude]
        private string name;
        [JsonInclude]
        private int damage1;
        [JsonInclude]
        private int damage2;
        [JsonInclude]
        private bool is_alive = true;
        [JsonInclude]
        private float health;

        public Enemy()
        { }

        public string Get_Name()
        {
            return name;
        }
        public void Set_Name(string name)
        {
            this.name = name;
        }
        public void Set_Damages(int  damage1, int damage2)
        {
            this.damage1 = damage1;
            this.damage2 = damage2;
        }
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
        public int Get_Damage_1_type()
        {
            return this.damage1;
        }
        public int Get_Damage_2_type()
        {
            return this.damage2;
        }
    }
}

