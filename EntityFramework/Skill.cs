using System.Text.Json.Serialization;

namespace EntityFramework
{
    public class Skill
    {
        public int  Id { get; set; }    
        public string Name { get; set; } = String.Empty;

        public int Damage { get; set; }

        [JsonIgnore]
        public List<Charactor> Charactors { get; set; }

    }
}
