namespace DesafioChatBotAPI.Models
{
    public class Repositories
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Created_At { get; set; }

        public Repositories(string name, string description, string language, string created_At)
        {
            Name = name;
            Description = description;
            Language = language;
            Created_At = created_At;
        }
    }
}
