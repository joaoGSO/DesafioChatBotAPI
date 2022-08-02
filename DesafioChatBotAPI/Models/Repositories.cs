namespace DesafioChatBotAPI.Models
{
    public class Repositories
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String Language { get; set; }
        public String Creation_Date { get; set; }

        public Repositories(string name, string description, string language, string creation_date)
        {
            Name = name;
            Description = description;
            Language = language;
            Creation_Date = creation_date;
        }
    }
}
