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
        private int max_health = 50;
        [JsonInclude]
        private float health = 15;
        [JsonInclude]
        private List<Item> inventory = new List<Item>();
        [JsonInclude]
        private int occupying_room_number;

        public Player()
        { }

        public void Regen_Health(float amount)
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
                        Program.welcome_main_menu();
                        break;
                    }

            }
        }
    }
}


