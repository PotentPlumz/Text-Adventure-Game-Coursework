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

                //Enviro files
                StreamReader opening = new StreamReader("enviromental_desc/opening1.txt");
                config_file.Close();

                //Char files

                //artwork
                //goblin artwork from https://ascii.co.uk/art/goblin accessed 08/01/25
                StreamReader goblin_art = new StreamReader("graphics/goblin.txt");
                goblin_art.Close();


            }
            catch 
            { 
                throw new Exception("Missing one or more files, please redownload from source."); 
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
