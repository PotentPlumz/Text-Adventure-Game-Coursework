namespace coursework_project
{
    internal class Program
    {
        //This is default scroll speed if config is corrupt
        public static int scroll_speed = 20;
        static public void Main()
        {
            File_Load.Check_files_proceedure();

            //Allows for use of unicode chars
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            Main_Menu.set_options_from_config();
            Main_Menu.welcome_screen();

            //List of all the main menu options 


            Main_Menu.call_main_menu();
            
            //New game 
            Game_Display.display_screen(Main_Menu.player_name);


        }
    }
}
