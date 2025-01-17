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

            Program.current_player.Set_Player_Location(2);
            
            
            if (Game_Saves.Goblin_Room2.Check_If_Alive() == true)
            {
                Room2_Combat();
            }

        }

        public static void Room2_Combat()
        {
            File_Load.sound_combat_music.Play();

            List<string> goblin_art = File_Load.Load_image("graphics/goblin.txt");
            Display_Text_From_File.Read_Text("char_dialogue/goblin_room2_opening.txt", goblin_art);

            List<string> combat_options = new List<string>();
            combat_options.Add("Strike With Your Sword");
            combat_options.Add("Consume Health Potion");

            while (Game_Saves.Goblin_Room2.Check_If_Alive() == true)
            {
                string health_message = ("Your current health is " + Program.current_player.Check_Health() + "/" + Program.current_player.Check_Max_Health());


                int user_choice = Menu_Call_Func.Display_Main_With_Custom_String(combat_options, health_message);

                switch (user_choice)
                {
                    case 1:
                        {
                            File_Load.sound_sword.Play();
                            Combat_Calculations.Damage_Enemy(Game_Saves.Sword1, Game_Saves.Goblin_Room2);
                            break;
                        }
                    case 2:
                        {
                            File_Load.sound_drink_potion.Play();
                            combat_options.RemoveAt(1);
                            Consume_Health_Potion();
                            break;
                        }
                }
                if (!Game_Saves.Goblin_Room2.Check_If_Alive())
                    continue;

                Combat_Calculations.Enemy_Turn(Game_Saves.Goblin_Room2);
                Program.current_player.Check_Player_Death_and_Play_Scream();




            }
            File_Load.sound_combat_music.Stop();
            Display_Text_From_File.Read_Text("enviromental_desc/ending.txt", Program.no_art_list);

        }
        public static void Consume_Health_Potion()
        {
            Program.current_player.Drop_Item(Game_Saves.Health_Potion);
            int recovery_amount = Combat_Calculations.Fluff_Health_Potion_Amount(Game_Saves.Health_Potion);
            Program.current_player.Regen_Health(recovery_amount);
            Display_text_func.Display_Text_Continued("You feel much better for drinking that.");
            Thread.Sleep(1000);
        }
    }

}