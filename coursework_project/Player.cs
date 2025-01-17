using System.Data;
using System.Media;
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
        private int max_health;
        [JsonInclude]
        private int health;
        [JsonInclude]
        private List<Item> inventory = new List<Item>();
        [JsonInclude]
        private int occupying_room_number;

        public Player()
        {       
        }

        public void Clear_Inventory()
        {
            this.inventory.Clear();
        }
        public void Regen_Health(int amount)
        {
            this.health += amount;

            if (this.health > max_health)
                this.health = max_health;
        }
        public int Get_Player_Location()
        {
            return this.occupying_room_number;
        }
        public void Set_Player_Location(int room_number)
        {
            this.occupying_room_number = room_number;
        }

        public void Take_Damage(int amount)
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
        public int Check_Health()
        {
            return this.health;
        }
        public void Set_Health(int health)
        {
            this.health = health;
        }
        public bool Check_If_Alive()
        {
            if (this.health <= 0)
            {
                this.is_alive = false;
            }
            return this.is_alive;
        }
        public int Check_Max_Health()
        {
            return this.max_health;
        }
        public void Set_Max_Health(int max_health)
        {
            this.max_health = max_health;
        }

        public void Pickup_Item(Item item)
        {
            this.inventory.Add(item);
        }

        public void Drop_Item(Item item)
        {
            this.inventory.Remove(item);
        }
        public List<Item> Check_Inventory()
        {
            return this.inventory;
        }
        public void Check_Player_Death_and_Play_Scream()
        {
            if (!this.is_alive)
            {
                this.Death_Screen();

            }
        }
        public void Death_Screen()
        {
            File_Load.sound_death_scream.Play();

            List<string> death_options = new List<string>();
            death_options.Add("New Game");
            death_options.Add("Load Game");
            death_options.Add("Return to Main Menu");

            Console.Clear();


            Console.WriteLine("GAME OVER");


            Console.WriteLine("---------");

            int death_choice = Menu_Call_Func.Display_Menu(death_options);

            switch (death_choice)
            {
                case 1:
                    {
                        Game_Saves.Commence_New_Game();
                        break;
                    }
                case 2:
                    {
                        Game_Saves.Load_Game();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        Program.welcome_main_menu();
                        break;
                    }

            }
        }
    }
}


