
using System.ComponentModel.DataAnnotations;
using System.Media;
using System.Runtime.InteropServices;

namespace coursework_project
{
    internal class Main_Menu
    {
        static public void welcome_screen()
        {

            //Make sure to follow copyright laws and credit the authors for the Asc key art and sounds/music

            File_Load.main_menu_music.Play();
            Console.WriteLine("""\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\""");
            string message = ("|    Welcome to Morgan's game!    |");

            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(20);
            }
            Console.WriteLine();
            Console.WriteLine("""\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\""");
        }
        static public void main_menu(List<string> menu_to_display)
        {
            Console.CursorVisible = false;
            Console.WriteLine("\nPlease use the Up and Down arrows to navigate and press Enter to select an option\n");
            Console.WriteLine("   \x1B[4mMain Menu\x1B[0m");

            (int cursor_menu_hori, int cursor_menu_vert) = Console.GetCursorPosition();

            bool selected_item = false;
            int menu_position = 1;

            ConsoleKeyInfo user_keypress;


            string red_text_colour = "\x1b[1;31m";
            string default_colour_code = "\u001b[0m";

            while (selected_item == false)
            {
                Console.SetCursorPosition(cursor_menu_hori, cursor_menu_vert);


                for (int i = 0;i < menu_to_display.Count;i++)
                {
                    Console.WriteLine($"{i+1}) {(menu_position == i+1 ? red_text_colour : "")}{menu_to_display[i]}" + default_colour_code);
                }

                user_keypress = Console.ReadKey();

                if (user_keypress.Key == ConsoleKey.DownArrow)
                {
                    menu_position++;
                    if (menu_position == menu_to_display.Count + 1)
                        menu_position = 1;
                }
                if (user_keypress.Key == ConsoleKey.UpArrow)
                {
                    menu_position--;
                    if (menu_position == 0)
                        menu_position = menu_to_display.Count;
                }
                if (user_keypress.Key == ConsoleKey.Enter)
                {
                    selected_item = true;
                    Console.WriteLine($"You have selected option {menu_position}");
                }


            }


        }
    }
}
