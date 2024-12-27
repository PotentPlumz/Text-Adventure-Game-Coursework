using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class Storage
    {
        public string name;
        public string description;
        [JsonInclude]
        public List<Item> contents = new List<Item>();

        public void putitemin(Item itemtobeputin)
        {
            this.contents.Add(itemtobeputin);
            Program.current_player.inventory.Remove(itemtobeputin);
        }
        public void takeitemout(Item itemtotakenout)
        {
            this.contents.Remove(itemtotakenout);
            Program.current_player.inventory.Add(itemtotakenout);
        }
    }

}

