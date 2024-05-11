using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EntityDTO
{
    public class PostDTO:BaseDTO
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

		public CategoryDTO? CategoryDTO { get; set; }
		public virtual List<CommentDTO>? CommentDTOs { get; set; }

	}
}
