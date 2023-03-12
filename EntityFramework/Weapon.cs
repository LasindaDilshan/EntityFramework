using System.Text.Json.Serialization;

namespace EntityFramework
{
    public class Weapon
    {
        public int Id { get; set; } 
        public string Name { get; set; }=String.Empty;
        public int Damage { get; set; } = 10;
        [JsonIgnore]
        public Charactor Charactor { get; set; }
        public int CharactorId { get; set; }
    }
}
