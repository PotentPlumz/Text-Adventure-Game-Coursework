namespace coursework_project
{
    internal class Game_Display
    {

        public static void display_screen(string char_name)
        {

            //The defined paramenters of the game display box 
            int display_box_height = 16;
            int display_box_length = 120;

            string name_with_spaces = display_spaces_after_name(char_name);
            Console.Clear();
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
        public static void Displayart(StreamReader art_to_display)
        {
            (int inital_cursor_hori, int inital_cursor_vert) = Console.GetCursorPosition();

            int horizontal_position = 45;
            int vertical_poistion = 18;

            bool end_of_image = false;
            int num_of_lines = 0;

            List<string> lines = new List<string>();

            while (!end_of_image)
            {
                lines.Add(art_to_display.ReadLine());
                num_of_lines++;
                end_of_image = art_to_display.EndOfStream;
            }
            Console.SetCursorPosition(horizontal_position, (vertical_poistion - num_of_lines));

            for (int i = 0; i < num_of_lines; i++)
            {
                Console.SetCursorPosition(horizontal_position, (vertical_poistion + i - num_of_lines));
                Console.WriteLine(lines[i]);
            }

            Console.ReadKey();

            Console.SetCursorPosition(inital_cursor_hori, inital_cursor_vert);
        }
    }
}
