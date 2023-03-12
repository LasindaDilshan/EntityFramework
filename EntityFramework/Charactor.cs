using System.Text.Json.Serialization;

namespace EntityFramework
{
    public class Charactor
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public string RpgClass { get; set; } = "Knight";
        [JsonIgnore]
        public User? User { get; set; }

        public int UserId { get; set; }
        public Weapon Weapon { get; set; }

        public List<Skill> Skills  { get; set; }
    }
}
