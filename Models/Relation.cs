namespace Myblog1.Models
{
    public class Relation
    {
        public int Id { get; set; }
        public Post Post { get; set; }
        public Term Term { get; set; }
    }
}
