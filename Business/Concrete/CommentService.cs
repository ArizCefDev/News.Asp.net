using AutoMapper;
using Business.Abstract;
using DataAccess.Entity;
using DataAccess.MyContext;
using DTO.EntityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentService : BaseSevice<CommentDTO, Comment, CommentDTO>, IComment
    {
        public CommentService(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }
}
