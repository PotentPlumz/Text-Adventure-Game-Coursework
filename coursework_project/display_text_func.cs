namespace coursework_project
{
    public class Display_text_func
    {

        public static void display_title_menu(string text_to_display)
        {

            for (int i = 0; i < text_to_display.Length; i++)
            {
                Console.Write(text_to_display[i]);
                Thread.Sleep(Program.scroll_speed);

                //This code allows the player to skip the text rollout animation by seeing if a userkeypress occours 
                //and then displaying the remainder of the string 
                if (Console.KeyAvailable == true)
                { ConsoleKeyInfo user_keypress = Console.ReadKey(true);

                    if (user_keypress.Key == ConsoleKey.Enter || user_keypress.Key == ConsoleKey.Spacebar)
                    {
                        Console.Write(text_to_display.Substring(i + 1));
                        break;
                    }
                }
            }
        }
        public static void display_text(string text_to_display, string char_name)
        {
            Game_Display.display_screen(char_name);

            (int cursor_menu_hori, int cursor_menu_vert) = Console.GetCursorPosition();

            //This needs fixing
            display_title_menu(text_to_display);


            Console.ReadKey(true);
            Console.SetCursorPosition(cursor_menu_hori, cursor_menu_vert);
        }


    }
}
