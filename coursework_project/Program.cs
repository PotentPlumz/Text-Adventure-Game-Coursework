namespace coursework_project
{

    internal class Program
    {
        public static Player current_player = new Player();
        public static List<string> no_art_list = new List<string>();

        //My Github URL = https://olympus.ntu.ac.uk/N0786934/Visual_Novel.git

        //This is default scroll speed if config is corrupt
        public static int scroll_speed = 20;
        static public void Main()
        {
            //Allows for use of unicode chars
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            File_Load.Check_files_proceedure();

           welcome_main_menu();
        }
        static public void welcome_main_menu()
        {
            File_Load.sound_main_menu_music.Play();
            Main_Menu.set_options_from_config();
            Main_Menu.welcome_screen();
            Main_Menu.call_main_menu();


        }
    }
}
