using DTO.EntityDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class CategoryValidator : AbstractValidator<CategoryDTO>
    {
        public CategoryValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad bos ola bilmez");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Simvol sayi minumum 2 olmalidir");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Simvol sayi maksimum 20 olmalidir");
        }
    }
}
