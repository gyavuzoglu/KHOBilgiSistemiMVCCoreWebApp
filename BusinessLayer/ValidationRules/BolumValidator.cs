using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BolumValidator : AbstractValidator<BolumTbl>
    {
        public BolumValidator()
        {
            RuleFor(x => x.BolumAdi).NotEmpty().WithMessage("Bölüm adı boş geçilemez.");
            RuleFor(x => x.BolumAdi).MinimumLength(3).WithMessage("Bölüm adı en az 3 karakter olmalıdır.");
            RuleFor(x => x.BolumAdi).MaximumLength(150).WithMessage("Bölüm adı en fazla 150 karakter olmalıdır.");
        }
    }
}
