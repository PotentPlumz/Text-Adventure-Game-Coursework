using System.Text.Json.Serialization;

namespace coursework_project
{
    internal class Storage
    {
        private string name;
        private string description;
        [JsonInclude]
        private List<Item> contents = new List<Item>();
        [JsonInclude]
        private bool opened_previously;

        public Storage()
        { }
        public void Set_Name(string name)
        {
            this.name = name;
        }
        public void Set_Description(string description)
        {
            this.description = description;
        }

        public void Put_Item_In(Item itemtobeputin)
        {
            this.contents.Add(itemtobeputin);
            Program.current_player.Drop_Item(itemtobeputin);
        }
        public void Take_Item_Out(Item itemtotakenout)
        {
            this.contents.Remove(itemtotakenout);
            Program.current_player.Pickup_Item(itemtotakenout);
        }
        public bool Check_If_Opened()
        {
            return opened_previously;
        }
        public void Mark_As_Opened()
        {
            this.opened_previously = true;
        }
        public List<Item> Get_Contents()
        {
            return contents;
        }
    }

}

