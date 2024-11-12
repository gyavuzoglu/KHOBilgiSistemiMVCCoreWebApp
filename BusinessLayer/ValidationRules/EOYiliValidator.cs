using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class EOYiliValidator : AbstractValidator<EOYiliTbl>
    {
        public EOYiliValidator()
        {
            RuleFor(x => x.EOYili).NotEmpty().WithMessage("Eğitim-Öğretim Yılı boş geçilemez.");
            RuleFor(x => x.EOYili).MinimumLength(4).WithMessage("Eğitim-Öğretim Yılı en az 4 karakter olmalıdır.");
            RuleFor(x => x.EOYili).MaximumLength(9).WithMessage("Eğitim-Öğretim Yılı en fazla 9 karakter olmalıdır.");
        }
    }
}
