using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class Room2_Program
    {
        public static void Room2_Entry()
        {
            Console.Clear();
            Game_Display.display_screen("");
            
            if (Game_Saves.Goblin_Room2.Check_If_Alive() == true)
            {
                Room2_Combat();
            }

        }
        public static void Room2_Main_Menu()
        {

        }
        public static void Room2_Combat()
        {
            List<string> combat_options = new List<string>();
            combat_options.Add("Strike With Your Sword");
            if (Program.current_player.Check_Inventory().Contains(Game_Saves.Health_Potion))
            {
                combat_options.Add("Consume Health Potion");
            }





        }
    }

}