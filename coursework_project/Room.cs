using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class Room
    {
        private string name;
        [JsonInclude]
        private bool entered_previously = false;
        private string entry_description;

        public Room()
        { }

        public void enter_room()
        {
            this.entered_previously = true;
        }
        public void set_name(string name)
        {
            this.name = name;
        }
        public void get_description(string filepath)
        {

            Display_Text_From_File.Read_Text(filepath, Program.no_art_list);
        }

    }
}

