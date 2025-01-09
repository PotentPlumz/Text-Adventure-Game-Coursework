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

    }
}

