namespace coursework_project
{
    internal class Game_Display
    {

        public static void display_screen(string char_name)
        {
            int name_box_length = 16;
            int display_box_length = 120;

            string name_with_spaces = display_spaces(char_name, 12);
            Console.Clear();
            for (int i = 0; i < name_box_length; i++)
            {
                Console.WriteLine("");
            }
            Console.WriteLine("----------------");
            Console.WriteLine("| " + name_with_spaces + """ \""");

            for (int i = 0; i < display_box_length; i++)
            {
                Console.Write("-");

            }
            Console.ReadKey();
        }
        public static string display_spaces(string name, int spaces)
        {
            int length = name.Length;
            int difference = spaces - length;

            for (int i = 0; i <= difference; i++)
                name = name + " ";
            return name;
                
        }
    }
}
