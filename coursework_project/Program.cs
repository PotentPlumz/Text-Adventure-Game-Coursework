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


            File_Load.main_menu_music.Play();

            //List of all the main menu options
            welcome_main_menu();

            //New game 
            Game_Display.display_screen(Main_Menu.player_name);

            Display_text_func.display_text("Hello ffgfdghfdghfdfghfdfgsfdfghsdfusdgfdfsdfhjsdfghfghfdghsfdhfsdhfsdghfgdh");
        }
        static public void welcome_main_menu()
        {
            Main_Menu.set_options_from_config();
            Main_Menu.welcome_screen();
            Main_Menu.call_main_menu();
        }
    }
}
