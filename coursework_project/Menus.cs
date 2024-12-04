
using System.Media;
using System.Runtime.InteropServices;

namespace coursework_project
{
    internal class Menu
    {
        static public void welcome_screen()
        {

            //Make sure to follow copyright laws and credit the authors for the Asc key art and sounds/music
            SoundPlayer sound = new SoundPlayer("main_menu_music.wav");
            sound.Play();
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
        static public void main_menu()
        {
            Console.CursorVisible = false;
            Console.WriteLine("\nPlease use the Up and Down arrows to select an option\n");
            Console.WriteLine("   \x1B[4mMain Menu\x1B[0m");

            (int cursor_menu_hori, int cursor_menu_vert) = Console.GetCursorPosition();

            bool selected_item = false;
            int menu_position = 1;

            ConsoleKeyInfo user_keypress;


            string red_text_colour = "\x1b[1;31m";
            string default_colour_code = "\u001b[0m";
            string black_text_colour = "\x1b[1; 31m";

            while (selected_item == false)
            {
                Console.SetCursorPosition(cursor_menu_hori, cursor_menu_vert);

                Console.WriteLine($"1) {(menu_position == 1 ? red_text_colour : "")}New Game" + default_colour_code);
                Console.WriteLine($"2) {(menu_position == 2 ? red_text_colour : "")}Load Game"+ default_colour_code);
                Console.WriteLine($"3) {(menu_position == 3 ? red_text_colour : "")}Options" + default_colour_code);
                Console.WriteLine($"4) {(menu_position == 4 ? red_text_colour : "")}Exit" + default_colour_code);

                user_keypress = Console.ReadKey();

                if (user_keypress.Key == ConsoleKey.DownArrow)
                {
                    menu_position++;
                    if (menu_position == 5)
                        menu_position = 1;
                }
                if (user_keypress.Key == ConsoleKey.UpArrow)
                {
                    menu_position--;
                    if (menu_position == 0)
                        menu_position = 4;
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
