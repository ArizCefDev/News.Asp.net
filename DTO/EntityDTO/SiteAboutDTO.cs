using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EntityDTO
{
    public class SiteAboutDTO:BaseDTO
    {
        public string? LogoURL { get; set; }
        public string? CopyRight { get; set; }
        public string? Text { get; set; }
        public string? Owner { get; set; }
    }
}
