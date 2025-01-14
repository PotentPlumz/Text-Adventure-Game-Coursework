namespace coursework_project
{
    internal class Main_Menu

    {//This file contains all logic associated with the main menu. 


        public static string config_file_path = "config.txt";
        static public void welcome_screen()
        {
            Console.WriteLine("""/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\""");
            Display_text_func.rollout_text("|     Welcome to Morgan's Mansion Escape!    |");
            Console.WriteLine();
            Console.WriteLine("""/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\""");
        }

        static public void call_main_menu()
        {
            Console.CursorVisible = false;


            //List of menu options 
            List<string> main_menu_options = new List<string>();
            main_menu_options.Add("New Game");
            main_menu_options.Add("Load Game");
            main_menu_options.Add("Options");
            main_menu_options.Add("Exit Game");

            //Options menu
            List<string> options_menu = new List<string>();
            options_menu.Add("Text Scroll Speed");
            options_menu.Add("Return to Main Menu");

            //text scroll speeds
            List<string> scroll_speeds = new List<string>();
            scroll_speeds.Add("Slow");
            scroll_speeds.Add("Medium");
            scroll_speeds.Add("Fast");
            scroll_speeds.Add("Return to Main Menu");

            //Load game menu
            List<string> load_game_menu = new List<string>();
            load_game_menu.Add("Return to Main Menu");

            //Displays to the user
            Console.WriteLine("\nPlease use the Up and Down arrows to navigate and press Enter to select an option\n");
            Console.WriteLine("   \x1B[4mMain Menu\x1B[0m");


            int main_selection = Menu_Call_Func.Display_Menu(main_menu_options);

            //Main menu optons list
            switch (main_selection)
            {
                case 1:
                    Game_Saves.Commence_New_Game();
                    break;
                case 2:
                    Game_Saves.Load_Game();
                    break;
                case 3:
                    options_function(options_menu, scroll_speeds);
                    break;
                case 4:
                    Console.WriteLine("Thank you for playing, play again soon!");
                    Environment.Exit(0);
                    break;
            }
        }
        static public void options_function(List<string> options, List<string> scroll_speeds)
        {
            //Displays the list of options in the options menu
            Console.Clear();
            Console.WriteLine("Options menu");
            int options_selection = Menu_Call_Func.Display_Menu(options);
            if (options_selection == 2)
            {
                Console.Clear();
                Program.welcome_main_menu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Scroll Speeds");
                scroll_speed_function(scroll_speeds);
            }
        }
        static public void scroll_speed_function(List<string> scoll_menu)
        {
            //has three preset scroll speeds
            int slow = 50;
            int medium = 20;
            int fast = 5;


            int scroll_selection = Menu_Call_Func.Display_Menu(scoll_menu);

            if (scroll_selection == 1)
            {
                set_options_to_config("slow");
                scroll_speed_display();
            }
            if (scroll_selection == 2)
            {
                set_options_to_config("medium");
                scroll_speed_display();
            }
            if (scroll_selection == 3)
            {
                set_options_to_config("fast");
                scroll_speed_display();
            }
            if (scroll_selection == 4)
            {
                Console.Clear();
                Program.welcome_main_menu();
            }
        }
        static void scroll_speed_display()
        {
            Console.WriteLine("Scroll speed sucessfully updated.");
            Thread.Sleep(1500);
            Console.Clear();
            Program.welcome_main_menu();
        }
        static public void set_options_from_config()
        {
            //Everytime the main menu is called, the options selected in the config file are loaded.
            StreamReader config_file = new StreamReader(config_file_path);
            Dictionary<string, string> config_dictionary = new Dictionary<string, string>();
            bool end_of_config_file = false;

            string[] reader;


            //Allows the config file order to be changed and extra lines added, just as long as the dictionary key doesn't change
            while (!end_of_config_file)
            {
                reader = config_file.ReadLine().Split("=");
                if (reader[0].Length == 0)
                    continue;

                config_dictionary[reader[0]] = reader[1];
                end_of_config_file = config_file.EndOfStream;
            }

            if (config_dictionary["Text_Scroll_Speed"] == "slow")
                Program.scroll_speed = 50;
            else if (config_dictionary["Text_Scroll_Speed"] == "medium")
                Program.scroll_speed = 20;
            else if (config_dictionary["Text_Scroll_Speed"] == "fast")
                Program.scroll_speed = 5;
           
            config_file.Close();
        }
        static public void set_options_to_config(string scroll_speed)
        {
            //Generates new config file each time to mitigate issues with user tampering with the file
            File.Create(config_file_path).Close();

            StreamWriter config_file = new StreamWriter(config_file_path);

            config_file.WriteLine("Text_Scroll_Speed=" + scroll_speed);
            config_file.Close();

        }
    }
    
    
}
