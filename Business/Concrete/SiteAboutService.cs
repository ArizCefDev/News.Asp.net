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
    public class SiteAboutService : BaseSevice<SiteAboutDTO, SiteAbout, SiteAboutDTO>, ISiteAbout
    {
        public SiteAboutService(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }
}
