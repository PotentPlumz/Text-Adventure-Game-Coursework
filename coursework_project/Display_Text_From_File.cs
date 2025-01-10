
using System.ComponentModel.DataAnnotations;
using System.Media;
using System.Runtime.InteropServices;

namespace coursework_project
{
    internal class Display_Text_From_File
    {
        public static void Read_Text(string filepath, List<string> art)
        {
            bool end_of_file = false;

            StreamReader file_to_read = new StreamReader(filepath);

            string char_name = file_to_read.ReadLine();
            string reader;
            bool name_needs_refresh = false;
            bool initial = true;

            while (!end_of_file)
            {
                reader = file_to_read.ReadLine();


                if (reader == "change")
                {
                    char_name = file_to_read.ReadLine();
                    name_needs_refresh = true;
                    //continue;
                }

                if (initial == true)
                Display_text_func.Display_Text_with_Art(reader, char_name, art);

                else if (name_needs_refresh == true)
                Display_text_func.Update_Char_Name(char_name);
                
                else
                Display_text_func.Display_Text_Continued(reader);

                name_needs_refresh = false;
                initial = false;
                end_of_file = file_to_read.EndOfStream;
            }
            file_to_read.Close();
        }
    }
}
