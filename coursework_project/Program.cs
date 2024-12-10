namespace coursework_project
{
    internal class Program
    {

        static void Main(string[] args)
        {
            File_Load.Check_files_proceedure();

            Console.OutputEncoding = System.Text.Encoding.UTF8; //Allows for use of unicode chars
            Main_Menu.welcome_screen();

            List<string> main_menu_options = new List<string>();
            main_menu_options.Add("New Game");
            main_menu_options.Add("Load Game");
            main_menu_options.Add("Options");
            main_menu_options.Add("Exit Game");
            int variable = main_menu_options.Count;


            MenuCall.main_menu(main_menu_options);
        }
    }
}
