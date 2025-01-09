
using System.ComponentModel.DataAnnotations;
using System.Media;
using System.Runtime.InteropServices;

namespace coursework_project
{
    internal class Display_Text_From_File
    {
        public static void read_text(string filepath, List<string> art)
        {
            bool end_of_file = false;

            StreamReader file_to_read = new StreamReader(filepath);

            string char_name = file_to_read.ReadLine();
            string reader;
            bool initial = true;

            while (!end_of_file)
            {
                reader = file_to_read.ReadLine();

                if (initial == true)
                Display_text_func.Display_text_with_art(reader, char_name, art);

                else
                Display_text_func.Display_text_continued(reader);

                initial = false;
                end_of_file = file_to_read.EndOfStream;
            }

        }
    }
}
