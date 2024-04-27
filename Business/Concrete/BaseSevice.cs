using AutoMapper;
using Business.Abstract;
using DataAccess.MyContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BaseSevice<Send,T,Bring>:IBase<Send,T,Bring> where T : class
    {
        protected readonly IMapper _mapper;
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseSevice(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _dbSet=_context.Set<T>();
        }

        public void Delete(int id)
        {
            var ent=_dbSet.Find(id);
            _dbSet.Remove(ent);
            _context.SaveChanges();
        }

        public List<Bring> GetAll()
        {
            var ent = _dbSet.ToList();
            var BringDto=_mapper.Map<List<Bring>>(ent);
            return BringDto;
        }

        public Bring GetByID(int id)
        {
            var ent = _dbSet.Find(id);
            var BringDto=_mapper.Map<Bring>(ent);   
            return BringDto;
        }

        public Bring Insert(Send dto)
        {
           var ent=_mapper.Map<T>(dto);
            _dbSet.Add(ent);
            _context.SaveChanges();
            var BringDto=_mapper.Map<Bring>(ent);
            return BringDto;
        }

        public void Update(Send dto)
        {
            var ent = _mapper.Map<T>(dto);
            _dbSet.Update(ent);
            _context.SaveChanges();
        }
    }
}
