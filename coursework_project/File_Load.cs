using System.Media;
using System.Security.Cryptography.X509Certificates;

namespace coursework_project
{
    internal class File_Load
    {
        public static SoundPlayer main_menu_music;

        static public void Check_files_proceedure()
        {
            try
            {
                //Sound files 
                main_menu_music = new SoundPlayer("sound_files/main_menu_music.wav");
                sound_check(main_menu_music);

                //Enviro files

                //Char files
            }
            catch 
            { 
                throw new Exception("Missing one or more files, please redownload from source"); 
            }

        }   
        static void sound_check(SoundPlayer sound_file)
        {
            sound_file.Play();
            sound_file.Stop();
        }
    }
}
