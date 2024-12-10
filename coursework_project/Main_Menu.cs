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
        static public void main_menu(List<string> menu_to_display)
        {
            Console.CursorVisible = false;
            Console.WriteLine("\nPlease use the Up and Down arrows to navigate and press Enter to select an option\n");
            Console.WriteLine("   \x1B[4mMain Menu\x1B[0m");

            int selection = Menu_Call_Func.display_menu(menu_to_display);

            Console.Clear();

            switch (selection)
            {
                case 1:
                    bool name_correct = false;
                    while (name_correct == false)
                    {
                        Console.Write("Please enter your characters name: ");
                        player_name = Console.ReadLine();

                        if (player_name.Length < 1 || player_name.Length > 12)
                            Console.WriteLine("Please enter another name, it must be at least 1 character and no more than 12 characters long");
                        else
                            Console.WriteLine("Your player name is " + player_name);
                        name_correct = true;
                    }
                    break;



            }



        }
    }
}
