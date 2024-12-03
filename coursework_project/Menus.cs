
using System.Media;
using System.Runtime.InteropServices;

namespace coursework_project
{
    internal class Menu
    {
        static public void welcome_screen()
        {
            SoundPlayer sound = new SoundPlayer("main_menu_music.wav");
            sound.Play();
            Console.WriteLine("""\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\""");
            string message = ("|    Welcome to Morgan's game!    |");

            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(100);
            }
            Console.WriteLine();
            Console.WriteLine("""\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\""");
        }
        static public void main_menu()
        {

            Console.WriteLine("\nPlease use the Up and Down arrows to select an option\n");
            Console.WriteLine("   \x1B[4mMain Menu\x1B[0m");

            (int cursor_menu_hori, int cursor_menu_vert) = Console.GetCursorPosition();

            bool selected_item = false;
            int menu_position = 1;

            ConsoleKeyInfo user_keypress;

            while (selected_item == false)
            {
                Console.SetCursorPosition(cursor_menu_hori, cursor_menu_vert);

                Console.WriteLine("1) New Game" + " <--");
                Console.WriteLine("2) Load Game");
                Console.WriteLine("3) Exit");

                user_keypress = Console.ReadKey();


            }
            

        }
    }
}
