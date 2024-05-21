using DTO.EntityDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class PostValidator : AbstractValidator<PostDTO>
    {
        public PostValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bos ola bilmez");
            RuleFor(x => x.Title).MinimumLength(2).WithMessage("Simvol sayi minumum 2 olmalidir");
            
            RuleFor(x => x.Text).NotEmpty().WithMessage("Bos ola bilmez");
            RuleFor(x => x.Text).MinimumLength(2).WithMessage("Simvol sayi minumum 2 olmalidir");
        }
    }
}
