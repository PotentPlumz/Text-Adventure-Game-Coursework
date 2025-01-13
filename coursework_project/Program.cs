namespace coursework_project
{

    internal class Program
    {
        public static Player current_player = new Player();
        public static List<string> no_art_list = new List<string>();

        //This is default scroll speed if config is corrupt
        public static int scroll_speed = 20;
        static public void Main()
        {
            //Allows for use of unicode chars
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            File_Load.Check_files_proceedure();


   

            //List of all the main menu options
            welcome_main_menu();


            //New game starts here 
            Opening_Game_Sequence.Opening();
            Room1_Program.Room1_Entry();

            Display_text_func.Display_Text("Hello ffgfdghfdghfdfghfdfgsfdfghsdfusdgfdfsdfhjsdfghfghfdghsfdhfsdhfsdghfgdh", Program.current_player.Get_Name());
        }
        static public void welcome_main_menu()
        {
            File_Load.main_menu_music.Play();
            Main_Menu.set_options_from_config();
            Main_Menu.welcome_screen();
            Main_Menu.call_main_menu();


        }
    }
}
