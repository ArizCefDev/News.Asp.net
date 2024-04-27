using AutoMapper;
using DataAccess.MyContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBase<Send,T,Bring> 
    {
        List<Bring> GetAll();
        Bring GetByID(int id);
        Bring Insert(Send dto);
        void Update(Send dto);
        void Delete(int id);
    }
}
