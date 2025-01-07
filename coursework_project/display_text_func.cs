namespace coursework_project
{
    public class Display_text_func
    {
        //This file contains two functions
        //1)  accepts text as input and will display it in the console at the scroll speed from the config file 
        //2)  Does the same thing but also takes a char name for who is talking and resets the cursor position to accomidate multiple lines of dialogue

        public static void rollout_text(string text_to_display)
        {
            int char_length_to_wrap_to_new_line = 100;
            int scroll_speed = Program.scroll_speed;

            int new_line_counter = 0;
            for (int i = 0; i < text_to_display.Length; i++)
            {
                new_line_counter++;

                Console.Write(text_to_display[i]);

                if (new_line_counter > char_length_to_wrap_to_new_line && text_to_display[i] == ' ')
                {
                    Console.WriteLine();
                    new_line_counter = 0;
                }


                Thread.Sleep(scroll_speed);

                //This code allows the player to skip the text rollout animation by seeing if a userkeypress occours 
                //and then displaying the remainder of the string 
                if (Console.KeyAvailable == true)
                { ConsoleKeyInfo user_keypress = Console.ReadKey(true);

                    if (user_keypress.Key == ConsoleKey.Enter || user_keypress.Key == ConsoleKey.Spacebar)
                    {
                        scroll_speed = 0;
                    }
                }
            }
        }
        public static void display_text(string text_to_display, string char_name)
        {
            Game_Display.display_screen(char_name);

            (int cursor_menu_hori, int cursor_menu_vert) = Console.GetCursorPosition();

            rollout_text(text_to_display);

            Console.ReadKey(true);
            Console.SetCursorPosition(cursor_menu_hori, cursor_menu_vert);
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
