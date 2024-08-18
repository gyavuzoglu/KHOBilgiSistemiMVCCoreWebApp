using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AskeriSinifValidator:AbstractValidator<AskeriSiniflarTbl>
    {
        public AskeriSinifValidator()
        {
            RuleFor(x => x.SinifKisa).NotEmpty().WithMessage("Kısa sınıf adı boş geçilemez.");
            RuleFor(x => x.SinifUzun).NotEmpty().WithMessage("Uzun sınıf adı boş geçilemez.");
            RuleFor(x => x.SinifKisa).MinimumLength(3).WithMessage("Kısa sınıf adı en az 3 karakter olmalıdır.");
            RuleFor(x => x.SinifUzun).MinimumLength(3).WithMessage("Uzun sınıf adı en az 3 karakter olmalıdır.");
            RuleFor(x => x.SinifKisa).MaximumLength(10).WithMessage("Kısa sınıf adı en fazla 10 karakter olmalıdır.");
            RuleFor(x => x.SinifUzun).MaximumLength(20).WithMessage("Uzun sınıf adı en fazla 20 karakter olmalıdır.");
        }
    }
}
