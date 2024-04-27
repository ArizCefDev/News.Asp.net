using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MyContext
{
    public class AppDbContext:DbContext
    {
        public DbSet<Category>Categories { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Privacy> Privacies { get; set; }
        public DbSet<SiteAbout> SiteAbouts { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext>opt):base(opt) 
        {
            
        }
    }
}
