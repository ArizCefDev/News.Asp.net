using DataAccess.Entity;
using Helper.CookieCrypto;
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
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext>opt):base(opt) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    ID = 1,
                    Name = "Admin",
                });

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    ID = 2,
                    Name = "Redaktor",
                }
                );
            modelBuilder.Entity<Role>().HasData(
               new Role
               {
                   ID = 3,
                   Name = "User",
               }
               );

            var salt = Crypto.GenerateSalt();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    ID = 1,
                    ImageURL = "men.png",
                    UserName = "admin",
                    Salt = salt,
                    PasswordHash = Crypto.GenerateSHA256Hash("admin123", salt),
                    RoleId = 1
                }
                );
        }
    }
}
