using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EntityDTO
{
    public class CommentDTO:BaseDTO
    {
        public string? UserName { get; set; }
        public string? Text { get; set; }
        public string? ImageURL { get; set; }
		public int PostID { get; set; }
		public PostDTO? PostDTO { get; set; }

	}
}
