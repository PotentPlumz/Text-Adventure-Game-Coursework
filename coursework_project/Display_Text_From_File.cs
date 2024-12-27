
using System.ComponentModel.DataAnnotations;
using System.Media;
using System.Runtime.InteropServices;

namespace coursework_project
{
    internal class Display_Text_From_File
    {
        public static void read_text(string filepath)
        {
            bool end_of_file = false;

            StreamReader file_to_read = new StreamReader(filepath);

            string char_name = file_to_read.ReadLine();
            string reader;

            while (!end_of_file)
            {
                reader = file_to_read.ReadLine();
                Display_text_func.display_text(reader, char_name);
                end_of_file = file_to_read.EndOfStream;
            }





        }
        

    }
}
