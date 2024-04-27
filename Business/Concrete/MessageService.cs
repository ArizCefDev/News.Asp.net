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
    public class MessageService : BaseSevice<MessageDTO, Message, MessageDTO>, IMessage
    {
        public MessageService(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }
}
