
using System.ComponentModel.DataAnnotations;
using System.Media;
using System.Runtime.InteropServices;

namespace coursework_project
{
    internal class Menu_Call_Func
    {
        //This file contains the sole function used to displayed menu options that can be displayed to the user. It accepts a list of strings,
        //and displays them to the user. if statements or switch cases are needed as the function outputs the intager of the option they chose 

        static public int Display_Menu(List<string> menu_to_display)
        {
            //This collects the cursor position at the beginning of where the text is getting displayed 
            (int cursor_menu_hori, int cursor_menu_vert) = Console.GetCursorPosition();

            bool selected_item = false;
            int menu_position = 1;

            ConsoleKeyInfo user_keypress;

            while (selected_item == false)
            {
                //Everytime the user selects a new option, the cursor moves to where it began so the options can be redisplayed 
                Console.SetCursorPosition(cursor_menu_hori, cursor_menu_vert);

                //This is the code that loads all of the options contained in the inputted list and displayed them to the user
                for (int i = 0;i < menu_to_display.Count;i++)
                {
                    Console.WriteLine($"{i+1}) {(menu_position == i+1 ? File_Load.red_text_colour : "")}{menu_to_display[i]}" + File_Load.default_colour_code);
                }

                user_keypress = Console.ReadKey(true);

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
                   // Console.WriteLine($"You have selected option {menu_to_display[menu_position - 1]}");
                }
            }
            return menu_position;
        }
        public static int Display_Main_with_Question(List<string> menu)
        {
            Display_text_func.Display_Menu_Guide("What would you like to do?");
            Console.WriteLine("\n");
            int choice = Display_Menu(menu);
            return choice;
        }
        public static int Display_Main_With_Custom_String(List<string> menu, string text)
        {
            Display_text_func.Display_Menu_Guide("What would you like to do?\n" + text);
            Console.WriteLine("\n");
            int choice = Display_Menu(menu);
            return choice;
        }
    }
}
