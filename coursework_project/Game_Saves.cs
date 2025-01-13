using System.Text.Json;
using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class Game_Saves
    {
        public static Room Room1 = new Room();
        public static NPC Goblin_Room1 = new NPC();
        public static Storage Chest1 = new Storage();
        public static Item Sword1 = new Item();
        public static Item Health_Potion = new Item();


        static public void Create_Non_Save_Classes()
        {

            Sword1.Set_Name("Rugged Sword");
            Sword1.Set_Base_Damage(8);

            Health_Potion.Set_Name("Health Potion");
            Health_Potion.Set_Base_Health_Recovery(25);

            Chest1.Set_Name("Drawer");

            Room1.set_name("Basement");

            Goblin_Room1.Give_Name("Goblin");

        }
        static public void Create_Saveable_Classes_With_Default_Values()
        {
            Program.current_player.Set_Player_Location(1);

            Chest1.Put_Item_In(Sword1);
            Chest1.Put_Item_In(Health_Potion);

        }
        static public void commence_new_game()
        {
            File_Load.main_menu_music.Stop();
            Console.CursorVisible = false;

            Set_Player_Name();
            Save_Game();
        }

        static public void Set_Player_Name()
        {
            //Console.CursorVisible = true;
            bool name_correct = false;

            //Repeatadly asks the user to enter their char name. This is planned to also be the file name of the serialised save game file 
            while (name_correct == false)
            {

                Console.Write("\nPlease enter your character's name: ");
                string player_name = Console.ReadLine();

                if (player_name.Length < 1 || player_name.Length > 12)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter another name, it must be at least 1 character and no more than 12 characters long");
                }
                else
                {
                    Console.WriteLine("Your player name is " + player_name);
                    Program.current_player.Set_Name(player_name);
                    name_correct = true;

                }
            }
        }
        public static void Save_Game()
        {
            StreamWriter save_game_file = new StreamWriter("save_games/" + Program.current_player.Get_Name() + ".JSON");

           // Dictionary<string, string> savegame_dictionary = new Dictionary<string, string>();

            //Creates all of the string to be saved using the default values from the new game
            string player_save = JsonSerializer.Serialize(Program.current_player);
            string room1_save = JsonSerializer.Serialize(Room1);
            string chest1_save = JsonSerializer.Serialize(Chest1);

            save_game_file.WriteLine("player=" + player_save);
            save_game_file.WriteLine("room1=" + room1_save);
            save_game_file.WriteLine("chest1=" +  chest1_save);

            save_game_file.Close();
        }
        public static void Load_Game()
        {
            Console.WriteLine();

            File_Load.main_menu_music.Stop();


            string[] load_game_filenames_array = Directory.GetFiles("save_games/");
            List<string> load_game_filenames_list = new List<string>();
            load_game_filenames_list.Add("Return to Main Menu");
            
            foreach (string filename in load_game_filenames_array)
                load_game_filenames_list.Add(filename);


            Display_text_func.rollout_text("Please select a save game to load:");
            Console.WriteLine("\n");
            int user_loadgame_selection = Menu_Call_Func.Display_Menu(load_game_filenames_list);

            if (user_loadgame_selection == 1)
            {
                Console.Clear();
                Program.welcome_main_menu();
            }





        }

    }
}