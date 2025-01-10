using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class Room1_Program
    {
        public static Room Room1 = new Room();
        public static NPC Goblin_Room1 = new NPC();


        public static void Room1_Entry()
        {


            string room1_desc_filepath = "enviromental_desc/room1_desc.txt"; 
            Room1.set_name("Room1");
            Room1.get_description(room1_desc_filepath);

            Goblin_Room1.Give_Name("Goblin");


            Room1_Main_Menu();
    
        }
        private static void Room1_Main_Menu()
        {
            List<String> Room1_options = new List<string>();
            Room1_options.Add("Speak to Dave");
            Room1_options.Add("Approch the figure");
            Room1_options.Add("Look around the room");
            Room1_options.Add("Search the room.");

            int main_choice = Menu_Call_Func.Display_Main_with_Question(Room1_options);

            switch (main_choice)
            {
                case 1:
                    {
                        Display_text_func.Clear_Dialgoue_Box();
                        Display_text_func.Display_Text("Go on. Take a look around, see if you can do what I could not and get the hell out of here.", "Dave");
                        Room1_Main_Menu();
                        break;
                    }
                case 2:
                    {
                        Talk_to_Room1_Goblin();

                        break;
                    }
            }

        
    }

        private static void Talk_to_Room1_Goblin()
        {
            List<string> goblin_art = File_Load.Load_image("graphics/goblin.txt");
            
            List<string> goblin_options = new List<string>();
            goblin_options.Add("Return to Dave");



            if (Goblin_Room1.Check_if_Spoken_To() == false)
            {
                Display_Text_From_File.Read_Text("char_dialogue/goblin_room1_approach.txt", Program.no_art_list);
                Display_Text_From_File.Read_Text("char_dialogue/goblin_room1_intro.txt", goblin_art);
                Goblin_Room1.Speak_To();
            }
            else
            {
                Display_text_func.Display_Text_with_Art("What do you want now?", "goblin", goblin_art);
                Menu_Call_Func.Display_Main_with_Question(goblin_options);

            }
            Game_Display.display_screen("");
            Room1_Entry();
        }

    }
}