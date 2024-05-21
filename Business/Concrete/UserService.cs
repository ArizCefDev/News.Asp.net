using AutoMapper;
using Business.Abstract;
using DataAccess.Entity;
using DataAccess.MyContext;
using DTO.EntityDTO;
using Helper.Constants;
using Helper.CookieCrypto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : BaseSevice<UserDTO, User, UserDTO>, IUser
    {
        public UserService(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }

        public UserDTO Login(UserDTO p)
        {

            var res = _context.Users
            .Where(x => x.UserName == p.UserName)
             .Include(u => u.Role);

            if (res.Count() == 1)
            {
                var user = res.FirstOrDefault();

                var hash = Crypto.GenerateSHA256Hash(p.Password, user.Salt);

                if (hash == user.PasswordHash)
                {
                    var dto = _mapper.Map<User, UserDTO>(res.First());
                    return dto;
                }
                else
                {
                    throw new Exception("Şifrə yalnışdır!");
                }
            }
            else
            {
                throw new Exception("Hesab mövcud deyil");
            }
        }

        public override UserDTO Insert(UserDTO dto)
        {
            var res = _context.Users.Where(x => x.UserName == dto.UserName);

            var role = _context.Roles.Where(x => x.Name == RoleKeywords.UserRole)?.First();
            dto.RoleId = role.ID;

            if (res.Any())
            {
                throw new Exception("Bu istifadəçi adı mövcuddur!");
            }

            dto.Salt = Crypto.GenerateSalt();
            dto.PasswordHash = Crypto.GenerateSHA256Hash(dto.Password, dto.Salt);
            return base.Insert(dto);
        }
    }
}
