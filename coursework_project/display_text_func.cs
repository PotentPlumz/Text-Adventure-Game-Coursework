namespace coursework_project
{
    public class Display_text_func
    {

        public static void rollout_text(string text_to_display)
        {
            int char_length_to_wrap_to_new_line = 100;
            int scroll_speed = Program.scroll_speed;

            int new_line_counter = 0;
            for (int i = 0; i < text_to_display.Length; i++)
            {
                new_line_counter++;

                Console.Write(text_to_display[i]);

                //This effecitevly acts as a text wrapper 
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
        public static void Display_Text_Standalone(string text_to_display, string char_name)
        {
            Game_Display.display_screen(char_name);

            (int cursor_menu_hori, int cursor_menu_vert) = Console.GetCursorPosition();

            rollout_text(text_to_display);


            Console.SetCursorPosition(cursor_menu_hori, cursor_menu_vert);
        }


        public static void Display_Text(string text_to_display, string char_name)
        {
            Display_Text_Standalone(text_to_display, char_name);
            Console.ReadKey(true);
        }


        public static void Display_art(List<string> art_list)
        {
            (int inital_cursor_hori, int inital_cursor_vert) = Console.GetCursorPosition();

            int horizontal_position = 45;
            int vertical_poistion = 18;
            int num_of_lines = art_list.Count;

            Console.SetCursorPosition(horizontal_position, (vertical_poistion - num_of_lines));

            for (int i = 0; i < num_of_lines; i++)
            {
                Console.SetCursorPosition(horizontal_position, (vertical_poistion + i - num_of_lines));
                Console.WriteLine(art_list[i]);
            }
            Console.ReadKey(true);

            Console.SetCursorPosition(inital_cursor_hori, inital_cursor_vert);
        }
        static public void Display_Text_with_Art(string dialogue, string char_name, List<string> art)
        {
            //Standalone is only different from display_art by just not having a readkey so there won't be any pause.
            Display_Text_Standalone(dialogue, char_name);
            Display_art(art);
        }
        static public void Display_Text_Continued(string text_to_display)
        {//This proceedure clears all of the space ready for more text. It allows for more text to be displayed without clearing the whole console.

            Clear_Dialgoue_Box();

            rollout_text(text_to_display);
            Console.ReadKey(true);
        }
        static public void Clear_Dialgoue_Box()
        {
            //clears the dialgoue box on the screen without clearing the full console 

            Console.SetCursorPosition(0, 19);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("                                                                                                                     ");
            }
            Console.SetCursorPosition(0, 19);

        }
    }
}
