using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class Item
    {
        private string name;
        private int base_damage;
        private string description;
        private int base_health_recovery;
        
        public Item() 
        { }

        public void Set_Name(string name)
        {
            this.name = name;
        }

        public string Get_Name()
        {
            return this.name;
        }
        public void Set_Base_Damage(int base_damage)
        {
            this.base_damage = base_damage;
        }
        public void Set_Description(string description)
        {
            this.description = description;
        }
        public void Set_Base_Health_Recovery(int base_health_recovery)
        {
            this.base_health_recovery = base_health_recovery;
        }
    }
}
