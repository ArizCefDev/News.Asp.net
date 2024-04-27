using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EntityDTO
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public BaseDTO()
        {
            Time = DateTime.Now;
        }
    }
}
