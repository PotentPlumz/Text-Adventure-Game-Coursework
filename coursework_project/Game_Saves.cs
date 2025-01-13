using System.Reflection.PortableExecutable;
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
            Create_Non_Save_Classes();
            Create_Saveable_Classes_With_Default_Values();

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
            

            //This gets rid of the folder directory and .JSON from the end and just leaves the character name
            foreach (string filename in load_game_filenames_array)
            {
                string[] first_split = filename.Split("/");
                string[] second_split = first_split[1].Split('.');
                load_game_filenames_list.Add(second_split[0]);
            }
            if (load_game_filenames_list.Count < 2)
            {
                Display_text_func.rollout_text("Sorry, no save game files found.");
                Thread.Sleep(1500);
                Console.Clear();
                Program.welcome_main_menu();
            }

            Console.Clear();
            Display_text_func.rollout_text("Please select a save game to load:\n");
            Console.WriteLine("----------------------------------");
            Console.WriteLine();
    
            int user_loadgame_selection = Menu_Call_Func.Display_Menu(load_game_filenames_list);

            if (user_loadgame_selection == 1)
            {
                Console.Clear();
                Program.welcome_main_menu();
            }

            int save_list_index = user_loadgame_selection - 2;

            string filename_to_load = ("save_games/" + load_game_filenames_list[save_list_index] + ".JSON");

            Load_Game_From_File(filename_to_load);
        }

        private static void Load_Game_From_File(string filename)
        {
            StreamReader save_to_load = new StreamReader(filename);
            Dictionary<string, string> savegame_dictionary = new Dictionary<string, string>();
            string[] reader;

            while (!save_to_load.EndOfStream)
            {
                reader = save_to_load.ReadLine().Split("=");
                if (reader[0].Length == 0)
                    continue;

                savegame_dictionary.Add(reader[0], reader[1]);
            }
            Room1 = JsonSerializer.Deserialize<Room>(savegame_dictionary["room1"]);
            Program.current_player = JsonSerializer.Deserialize<Player>(savegame_dictionary["player"]);
            Chest1 = JsonSerializer.Deserialize<Storage>(savegame_dictionary["chest1"]);
        }

    }
}