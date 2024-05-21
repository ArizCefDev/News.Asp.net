using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EntityDTO
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string? Image { get; set; }
        public string? ImageURL { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Salt { get; set; }
        public string? Password { get; set; }
        public string? ConfimPassword { get; set; }
        public string? PasswordHash { get; set; }
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        //public Role? Role { get; set; }
    }
}
