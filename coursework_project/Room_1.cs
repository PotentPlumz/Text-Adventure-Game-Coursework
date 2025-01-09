using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class Room1_Program
    {
        public static Room Room1 = new Room();


        public static void Room1_Entry()
        {


            string room1_desc_filepath = "enviromental_desc/room1_desc.txt"; 
            Room1.set_name("Room1");
            Room1.get_description(room1_desc_filepath);


            List<String> Room1_options = new List<string>();
            Room1_options.Add("Speak to Dave");
            Room1_options.Add("Approch the figure");
            Room1_options.Add("Look around the room");
            Room1_options.Add("Search the room.");

            int main_choice = Menu_Call_Func.Display_Main_with_Question(Room1_options);

            switch(main_choice)
            {
                case 1:
                    {
                        Display_text_func.Clear_Dialgoue_Box();
                        Display_text_func.Display_Text("Go on. Take a look around, see if you can do what I could not and get the hell out of here.", "Dave");
                        main_choice = Menu_Call_Func.Display_Main_with_Question(Room1_options);
                        break;
                    }
            }
            


            


        }



    }
}