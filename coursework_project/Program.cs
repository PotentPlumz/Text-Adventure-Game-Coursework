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
            File_Load.main_menu_music.Play();


            //List of all the main menu options
            welcome_main_menu();






             List<string> goblin_art = File_Load.Load_image("graphics/goblin.txt");

            Display_Text_From_File.read_text("enviromental_desc/opening.txt", no_art_list);

            Display_text_func.Display_text_with_art("I am goblin!!!", "goblin", goblin_art);
            Display_text_func.Display_text_continued("What bobbbbbbbbbb");
            Display_text_func.Display_text_continued("ffgfhfh dgfhgfhghgh");
            Display_text_func.Display_text_continued("Whafghgfhgfhgfhgfhle one");
            Display_text_func.Display_text_continued("What hgfhgfhgfhgfhgfhfghfghgfone");







            Display_text_func.display_text("Hello ffgfdghfdghfdfghfdfgsfdfghsdfusdgfdfsdfhjsdfghfghfdghsfdhfsdhfsdghfgdh", current_player.name);
            Display_text_func.display_text("goodbye ffgfdghfdghfdfghfdfgsfdfghsdfusdgfdsssdhwwwete", "Dave");
            Display_text_func.display_text("help ffgfdghfdghfdfghfdfgsfdfggfdyrtuytjhjsfdhfsdhfsdghfgdh", current_player.name);


            Display_text_func.display_text("Hello old friend", "Geoff");
        }
        static public void welcome_main_menu()
        {
            Main_Menu.set_options_from_config();
            Main_Menu.welcome_screen();
            Main_Menu.call_main_menu();
        }
    }
}
