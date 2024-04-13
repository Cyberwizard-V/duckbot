namespace DuckAPI.Models
{
    public class Duck
    {
        public int DuckID { get; set; }
        public int DuckloreID { get; set; }

        public string DuckName { get; set;}
        public string DuckColor { get; set; }
        public string DuckGender { get; set; }
        public virtual Ducklore Ducklore { get; set; }

    }
}
