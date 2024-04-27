using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EntityDTO
{
    public class ContactDTO:BaseDTO
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Map { get; set; }
        public string? Adress { get; set; }
    }
}
