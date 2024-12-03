namespace coursework_project
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //Allows for use of unicode chars
            Menu.welcome_screen();

            Menu.main_menu();
        }
    }
}
