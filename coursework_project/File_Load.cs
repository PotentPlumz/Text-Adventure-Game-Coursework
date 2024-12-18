using System.Media;
using System.Security.Cryptography.X509Certificates;

namespace coursework_project
{
    internal class File_Load
    {
        public static string red_text_colour = "\x1b[1;31m";
        public static string default_colour_code = "\u001b[0m";

        public static int scroll_speed = 0;

        public static SoundPlayer main_menu_music;

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
                //Make sure to follow copyright laws and credit the authors for the Asc key art and sounds/music
                main_menu_music = new SoundPlayer("sound_files/main_menu_music.wav");
                sound_check(main_menu_music);

                //Enviro files

                //Char files
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
    }
}
