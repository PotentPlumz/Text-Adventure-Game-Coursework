using System.Media;
using System.Security.Cryptography.X509Certificates;

namespace coursework_project
{
    internal class File_Load
    {
        public static string red_text_colour = "\x1b[1;31m";
        public static string default_colour_code = "\u001b[0m";

        public static int scroll_speed = 0;

        public static SoundPlayer sound_main_menu_music;
        public static SoundPlayer sound_death_scream;
        public static SoundPlayer sound_combat_music;
        public static SoundPlayer sound_sword;
        public static SoundPlayer sound_drink_potion;
        public static SoundPlayer sound_player_take_damage;

        static public void Check_files_proceedure()
        {


            /* This will attempt to load all of the dependency files at the beginning of the game and throw
            an exception if any are missing. */
            try
            {
                //Config file
                StreamReader config_file = new StreamReader("config.txt");
                config_file.Close();

                //Sound files
                //Main menu music = Kevin Macloed - Impact Prelude accessed 16/01 https://incompetech.com/music/royalty-free/index.html?isrc=USUAN1100617&Search=Search
                sound_main_menu_music = new SoundPlayer("sound_files/main_menu_music.wav");
                sound_check(sound_main_menu_music);

                //combat music = Kevin Macloed - Burn the World Waltz accessed 17/01 https://incompetech.com/music/royalty-free/music.html
                sound_combat_music = new SoundPlayer("sound_files/combat_music.wav");
                sound_check(sound_combat_music);

                sound_death_scream = new SoundPlayer("sound_files/wilhelm_scream.wav");
                sound_check(sound_death_scream);

                //Sword sound effect from Pixabay (Cyberware-Orchestra) accessed 17/01 https://pixabay.com/sound-effects/search/sword/
                sound_sword = new SoundPlayer("sound_files/sword_strike.wav");
                sound_check(sound_sword);

                //drink sound effect from Pixabay (freesound_community) accessed 17/01 https://pixabay.com/sound-effects/search/drinking/
                sound_drink_potion = new SoundPlayer("sound_files/drink_potion.wav");
                sound_check(sound_drink_potion);

                //player take damage origional Minecraft take dagame sound effect accessed 17/01 - taken from https://www.myinstants.com/en/instant/minecraft-hurt/
                sound_player_take_damage = new SoundPlayer("sound_files/take_damage.wav");
                sound_check(sound_player_take_damage);

                //Enviro files
                StreamReader opening = new StreamReader("enviromental_desc/opening1.txt");
                config_file.Close();

                StreamReader ending = new StreamReader("enviromental_desc/ending.txt");
                ending.Close();

                StreamReader room1_desc = new StreamReader("enviromental_desc/room1_desc.txt");
                room1_desc.Close();

                StreamReader room2_desc = new StreamReader("enviromental_desc/room2_desc.txt");
                room2_desc.Close();

                //Char files
                StreamReader dave_intro = new StreamReader("char_dialogue/dave_intro.txt");
                dave_intro.Close();

                StreamReader goblin_room1_approach = new StreamReader("char_dialogue/goblin_room1_approach.txt");
                goblin_room1_approach.Close();

                StreamReader goblin_room1_intro = new StreamReader("char_dialogue/goblin_room1_intro.txt");
                goblin_room1_intro.Close();

                StreamReader goblin_room1_move = new StreamReader("char_dialogue/goblin_room1_move.txt");
                goblin_room1_move.Close();

                StreamReader goblin_room2_opening = new StreamReader("char_dialogue/goblin_room2_opening.txt");
                goblin_room2_opening.Close();

                //artwork
                //goblin artwork from https://ascii.co.uk/art/goblin accessed 08/01/25
                StreamReader goblin_art = new StreamReader("graphics/goblin.txt");
                goblin_art.Close();

                StreamReader deathbox = new StreamReader("graphics/deathbox.txt");
                deathbox.Close();

                //chest artwork from https://emojicombos.com/locked-chest accessed 11/01/25
                StreamReader chest = new StreamReader("graphics/chest.txt");
                chest.Close();

                //sword artwork from https://www.asciiart.eu/weapons/swords accessed 11/01/25
                StreamReader sword = new StreamReader("graphics/sword.txt");
                sword.Close();
            }
            catch 
            {
                Console.WriteLine("Exception detected!");
                Console.WriteLine("One or more files missing. Please redownload from source.");
                Environment.Exit(0);
            }

        }   
        static void sound_check(SoundPlayer sound_file)
        {
            sound_file.Play();
            sound_file.Stop();
        }


        static public List<string> Load_image(string filename)
        {
            StreamReader art_to_display = new StreamReader(filename);

            bool end_of_image = false;

            List<string> lines = new List<string>();

            while (!end_of_image)
            {
                lines.Add(art_to_display.ReadLine());
                end_of_image = art_to_display.EndOfStream;
            }

            art_to_display.Close();


            return lines;
            
        }
    }
}
