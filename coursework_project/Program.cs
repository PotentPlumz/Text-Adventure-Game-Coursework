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


            Main_Menu.call_main_menu();
            

            //New game 
            Game_Display.display_screen(Main_Menu.player_name);
            Main_Menu.call_main_menu();
        }
    }
}
