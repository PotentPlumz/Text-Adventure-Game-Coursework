using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class Room
    {
        private string name;
        private bool entered_previously = false;
        private string entry_description;

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
            string description;
            StreamReader description_file = new StreamReader(filepath);
            
                description = description_file.ReadLine();
            
            this.entry_description = description;
        }

    }
}

