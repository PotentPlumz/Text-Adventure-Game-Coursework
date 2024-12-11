namespace coursework_project
{
    internal class Main_Menu

    {
        public static string player_name;
        static public void welcome_screen()
        {
            File_Load.main_menu_music.Play();
            Console.WriteLine("""\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\""");
            string message = ("|    Welcome to Morgan's game!    |");

            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(20);
            }
            Console.WriteLine();
            Console.WriteLine("""\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\""");
        }
        static public void call_main_menu()
        {
            Console.CursorVisible = false;
            Console.WriteLine("\nPlease use the Up and Down arrows to navigate and press Enter to select an option\n");
            Console.WriteLine("   \x1B[4mMain Menu\x1B[0m");

            List<string> main_menu_options = new List<string>();
            main_menu_options.Add("New Game");
            main_menu_options.Add("Load Game");
            main_menu_options.Add("Options");
            main_menu_options.Add("Exit Game");

            int selection = Menu_Call_Func.display_menu(main_menu_options);

            Console.CursorVisible=true;

            switch (selection)
            {
                case 1:
                    bool name_correct = false;
                    while (name_correct == false)
                    {

                        Console.Write("Please enter your character's name: ");
                        player_name = Console.ReadLine();

                        if (player_name.Length < 1 || player_name.Length > 12)
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter another name, it must be at least 1 character and no more than 12 characters long");
                        }
                        else
                        {
                            Console.WriteLine("Your player name is " + player_name);
                            name_correct = true;
                        }
                    }
                    break;
                                        
            }




        }
    }
}
