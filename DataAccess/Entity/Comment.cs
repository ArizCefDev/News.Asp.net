using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Comment:Base
    {
        public string? UserName { get; set; }
        public string? Text { get; set; }
        public string? ImageURL { get; set; }
        public int? PostID { get; set; }
        public Post? Post { get; set; }
    }
}
