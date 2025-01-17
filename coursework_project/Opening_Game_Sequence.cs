using System.Text.Json;
using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class Opening_Game_Sequence
    {

        static public void Opening()
        {

            Display_Text_From_File.Read_Text("enviromental_desc/opening1.txt", Program.no_art_list);

            List<string> initial_options = new List<string>();
            initial_options.Add("Briskly try to wake him");
            initial_options.Add("Approach him cautiously");



            int Dave_Choice = Menu_Call_Func.Display_Main_with_Question(initial_options);

            switch(Dave_Choice)
            {
                case 1:
                    {
                        Display_text_func.Display_Text("Jesus!!! Don't shake me like that...", "Unknown");
                        Display_text_func.Display_Text_Continued("I'm barely hanging on here as it is.");
                        Display_text_func.Display_Text("I apologise, my bad...", "You");
                        Display_text_func.Display_Text("Anyway...", "Unknown");
                        break;
                    }
                case 2:
                    {
                        Display_text_func.Display_Text("As you approach you see the man slowly turn his head towards you.", "...");
                        break;
                    }
            }
            Display_Text_From_File.Read_Text("char_dialogue/dave_intro.txt", Program.no_art_list);

                
        }

    }
}