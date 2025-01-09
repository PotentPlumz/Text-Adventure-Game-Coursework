using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class NPC
    {
        private string name;
        [JsonInclude]
        private bool spoken_to = false;

        public void Give_Name(string name)
        {
            this.name = name;
        }
        public void Speak_To()
        {
            this.spoken_to = true;
        }
        public bool Check_if_Spoken_To()
        {
            return this.spoken_to;
        }
        


    }

    

    

}

