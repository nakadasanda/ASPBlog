using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myblog1.Models
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime PostDate { get; set; }
        public StatusEnum Status { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string URL { get; set; }
        public virtual ICollection<Relation> Relations { get; set; }
    }
}
