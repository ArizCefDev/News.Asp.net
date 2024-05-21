using DataAccess.Entity;
using DTO.EntityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUser : IBase<UserDTO, User, UserDTO>
    {
        UserDTO Login(UserDTO p);
    }
}
