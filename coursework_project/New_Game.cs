using System.Text.Json;
using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class New_Game
    {

        static public void commence_new_game()
        {
            File_Load.main_menu_music.Stop();
            Console.CursorVisible = false;

            set_player_name();
            create_new_save_game_file();
        }



        static public void set_player_name()
        {
            Console.CursorVisible = true;
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
                    Program.current_player.name = player_name;
                    name_correct = true;

                }
            }
            

        }
        public static void create_new_save_game_file()
        {
            StreamWriter save_game_file = new StreamWriter(Program.current_player.name + ".JSON");

            Dictionary<string, string> savegame_dictionary = new Dictionary<string, string>();

            string player_save = JsonSerializer.Serialize(Program.current_player); 
            save_game_file.WriteLine("player=" + player_save);














            save_game_file.Close();
        }


    }
}