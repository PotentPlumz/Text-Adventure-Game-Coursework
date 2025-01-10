namespace coursework_project
{
    internal class Game_Display
    {

        public static void display_screen(string char_name)
        {

            //The defined paramenters of the game display box 
            int display_box_height = 16;
            int display_box_length = 120;

            Console.Clear();

            string name_with_spaces = display_spaces_after_name(char_name);

            for (int i = 0; i < display_box_height; i++)
            {
                Console.WriteLine("");
            }
            Console.WriteLine("----------------");
            Console.WriteLine("| " + name_with_spaces + """ \""");

            for (int i = 0; i < display_box_length; i++)
            {
                Console.Write("-");
            }

        }
        //This function below adds spaces at the end of the character name so the box shape never changes 
        public static string display_spaces_after_name(string name)
        {
            int spaces = 12;
            int length = name.Length;
            int difference = spaces - length;

            for (int i = 0; i <= difference; i++)
                name = name + " ";
            return name;

        }

    }
}
