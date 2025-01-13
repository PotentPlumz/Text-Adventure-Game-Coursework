using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class Room1_Program
    {
        public static void Room1_Entry()
        {
            Console.Clear();
            Game_Display.display_screen("");
            Room1_Main_Menu();
        }
        private static void Room1_Main_Menu()
        {
            string room1_desc_filepath = "enviromental_desc/room1_desc.txt";

            List<String> Room1_options = new List<string>();
            Room1_options.Add("Speak to Dave");
            Room1_options.Add("Approch the figure");
            Room1_options.Add("Visually inspect the room");
            Room1_options.Add("Search the room");

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
                case 3:
                    {
                        Visually_Inspect_Room(room1_desc_filepath);
                        break;
                    }
                case 4:
                    {
                        Search_The_Room();
                        break;
                    }
            }
    }

        private static void Talk_to_Room1_Goblin()
        {
            List<string> goblin_art = File_Load.Load_image("graphics/goblin.txt");
            
            List<string> goblin_options = new List<string>();
            goblin_options.Add("Return to Dave");


            if (Game_Saves.Goblin_Room1.Check_if_Spoken_To() == false)
            {
                Display_Text_From_File.Read_Text("char_dialogue/goblin_room1_approach.txt", Program.no_art_list);
                Display_Text_From_File.Read_Text("char_dialogue/goblin_room1_intro.txt", goblin_art);
                Game_Saves.Goblin_Room1.Speak_To();
            }
            else
            {
                Display_text_func.Display_Text_with_Art("What do you want now?", "goblin", goblin_art);
                Menu_Call_Func.Display_Main_with_Question(goblin_options);

            }
            Game_Display.display_screen("");
            Room1_Entry();
        }

        private static void Visually_Inspect_Room(string filepath)
        {
            Game_Saves.Save_Game();
            Game_Saves.Room1.get_description(filepath);
            Game_Display.display_screen("");
            Room1_Entry();

        }
        private static void Search_The_Room()
        {
            List<string> search_room_options = new List<string>();
            search_room_options.Add("try to open it");
            search_room_options.Add("Return to Dave");

            //artwork from https://emojicombos.com/locked-chest accessed 11/01/25
            List<string> chest_art = File_Load.Load_image("graphics/chest.txt");

            //artwork from https://www.asciiart.eu/weapons/swords accessed 11/01/25
            List<string> sword_art = File_Load.Load_image("graphics/sword.txt");

            Display_text_func.Display_Text_with_Art("There isn't much of note in the room, however you do notice a rather old looking chest.", "", chest_art);

            int search_choice = Menu_Call_Func.Display_Main_with_Question(search_room_options);

            switch (search_choice)
            {
                case 1:
                    {
                        if (Game_Saves.Chest1.Check_If_Opened() == false)
                        {
                            Display_text_func.Display_Text_with_Art("A sword! Maybe this will show the goblin what's up. and some kind of weird red liquid in a bottle. Hopefully it will make me feel better if I drink it...", "" , sword_art);
                        }
                        Game_Saves.Chest1.Mark_As_Opened();
                        Interact_With_Chest();
                        break;
                    }
                case 2:
                    {
                        Game_Display.display_screen("");
                        Room1_Main_Menu();
                        break;

                    }
            }
        }
        private static void Interact_With_Chest()
        {
            List<Item> chest_contents = Game_Saves.Chest1.Get_Contents();

            List<string> chest_options = new List<string>();
            chest_options.Add("Return to Dave");

            foreach (Item item in chest_contents)
            {
                chest_options.Add("Pick up: " + item.Get_Name());
            }

            int chest_choice = Menu_Call_Func.Display_Main_with_Question(chest_options);

            switch (chest_choice)
            {
                case 1:
                    {
                        Game_Display.display_screen("");
                        Room1_Main_Menu();
                        break;
                    }
                case 2:
                    {
                        if (Game_Saves.Chest1.Get_Contents().Count == 2)
                            Item_Transfer(Game_Saves.Sword1, Game_Saves.Chest1);

                        if (Game_Saves.Chest1.Get_Contents().Count == 1)
                            Item_Transfer(Game_Saves.Health_Potion, Game_Saves.Chest1);
                        break;
                    }
                case 3:
                    {
                        Item_Transfer(Game_Saves.Health_Potion, Game_Saves.Chest1);
                        break;
                    }
            }
        }
        public static void Item_Transfer(Item item, Storage container)
        {
            Program.current_player.Pickup_Item(item);
            container.Take_Item_Out(item);
            Game_Display.display_screen("");
            Display_text_func.rollout_text("You just picked up " + item.Get_Name() + ".");
            Thread.Sleep(1000);
            Game_Display.display_screen("");
            Interact_With_Chest();
        }

    }
}