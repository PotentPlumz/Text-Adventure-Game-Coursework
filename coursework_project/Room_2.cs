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
            Game_Saves.Room2.get_description("enviromental_desc/room2_desc.txt");
            
            
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
            List<string> goblin_art = File_Load.Load_image("graphics/goblin.txt");
            string health_message = ("Your current health is " + Program.current_player.Check_Health() + "/" + Program.current_player.Check_Max_Health());
            Display_Text_From_File.Read_Text("char_dialogue/goblin_room2_opening.txt", goblin_art);

            List<string> combat_options = new List<string>();
            combat_options.Add("Strike With Your Sword");
            combat_options.Add("Consume Health Potion");

            while (Game_Saves.Goblin_Room2.Check_If_Alive() == true)
            {
                if (!Program.current_player.Check_Inventory().Contains(Game_Saves.Health_Potion))
                {
                    combat_options.RemoveAt(1);
                }

                int user_choice = Menu_Call_Func.Display_Main_With_Custom_String(combat_options, health_message);

                switch (user_choice)
                {
                    case 1:
                        {
                            Combat_Calculations.Damage_Enemy(Game_Saves.Sword1, Game_Saves.Goblin_Room2);
                            break;
                        }
                    case 2:
                        {
                            Consume_Health_Potion();
                            break;
                        }
                }
                Combat_Calculations.Enemy_Turn(Game_Saves.Goblin_Room2);




            }

            Display_Text_From_File.Read_Text("enviromental_desc/ending.txt", Program.no_art_list);

        }
        public static void Consume_Health_Potion()
        {
            Program.current_player.Drop_Item(Game_Saves.Health_Potion);
            float recovery_amount = Combat_Calculations.Fluff_Health_Potion_Amount(Game_Saves.Health_Potion);
            Program.current_player.Regen_Health(recovery_amount);
            Display_text_func.rollout_text("You feel much better for drinking that.");
            Thread.Sleep(1000);
        }
    }

}