namespace DuckAPI.Models
{
    public class Ducklore
    {
        public int ID { get; set; }
        public string Lore { get; set; }
        public virtual ICollection<Duck> Ducks { get; set; }
    }
}
