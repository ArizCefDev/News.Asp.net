﻿using DataAccess.Entity;
using DTO.EntityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPost : IBase<PostDTO, Post, PostDTO>
    {
        IEnumerable<PostDTO> GetCategoryPostId(int id);
        IEnumerable<PostDTO> GetAllInclude();
    }
}
