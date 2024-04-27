using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class SiteAbout : Base
    {
        public string? LogoURL { get; set; }
        public string? CopyRight { get; set; }
        public string? Text { get; set; }
        public string? Owner { get; set; }
    }
}
