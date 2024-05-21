using AutoMapper;
using Business.Abstract;
using DataAccess.Entity;
using DataAccess.MyContext;
using DTO.EntityDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostService : BaseSevice<PostDTO, Post, PostDTO>, IPost
    {
        public PostService(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }

        public IEnumerable<PostDTO> GetAllInclude()
        {
            var post = _dbSet.Include(x => x.Category).ToList();
            var rsdto = _mapper.Map<IEnumerable<PostDTO>>(post);
            return rsdto;
        }

        public IEnumerable<PostDTO> GetCategoryPostId(int id)
        {
            var post = _dbSet.Where(x => x.CategoryID == id).ToList();
            var rsdto=_mapper.Map<IEnumerable<PostDTO>>(post);
            return rsdto;
        }
    }
}
