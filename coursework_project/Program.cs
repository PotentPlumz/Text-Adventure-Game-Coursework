namespace coursework_project
{
    internal class Program
    {

        static void Main(string[] args)
        {
            File_Load.Check_files_proceedure();

            //Allows for use of unicode chars
            Console.OutputEncoding = System.Text.Encoding.UTF8; 

            Console.CursorVisible = false;
            Main_Menu.welcome_screen();

            //List of all the main menu options 
            List<string> main_menu_options = new List<string>();
            main_menu_options.Add("New Game");
            main_menu_options.Add("Load Game");
            main_menu_options.Add("Options");
            main_menu_options.Add("Exit Game");

            Main_Menu.main_menu(main_menu_options);
            

            //New game 
            Game_Display.display_screen(Main_Menu.player_name);
            Main_Menu.main_menu(main_menu_options);
        }
    }
}
