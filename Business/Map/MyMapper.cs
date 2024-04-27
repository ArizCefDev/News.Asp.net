using AutoMapper;
using DataAccess.Entity;
using DTO.EntityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Map
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            CreateMap<AboutDTO, About>();
            CreateMap<About, AboutDTO>();

            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();

            CreateMap<CommentDTO, Comment>();
            CreateMap<Comment, CommentDTO>();

            CreateMap<ContactDTO, Contact>();
            CreateMap<Contact, ContactDTO>();

            CreateMap<MessageDTO, Message>();
            CreateMap<Message, MessageDTO>();

            CreateMap<PostDTO, Post>();
            CreateMap<Post, PostDTO>();

            CreateMap<PrivacyDTO, Privacy>();
            CreateMap<Privacy, PrivacyDTO>();

            CreateMap<SiteAboutDTO, SiteAbout>();
            CreateMap<SiteAbout, SiteAboutDTO>();

            CreateMap<SocialMediaDTO, SocialMedia>();
            CreateMap<SocialMedia, SocialMediaDTO>();



        }
    }
}
