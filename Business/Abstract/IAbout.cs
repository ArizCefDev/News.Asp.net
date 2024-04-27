﻿using DataAccess.Entity;
using DTO.EntityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAbout : IBase<AboutDTO, About, AboutDTO>
    {
    }
}
