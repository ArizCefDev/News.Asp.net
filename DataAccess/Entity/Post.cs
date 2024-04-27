using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Post:Base
    {
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public string? FbURL { get; set; }
        public string? WpURL { get; set; }
        public string? TwtURL { get; set; }
        public string? TlgURL { get; set; }
        public string? PostURL { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        public virtual List<Comment>? Comments { get; set; }

    }
}
