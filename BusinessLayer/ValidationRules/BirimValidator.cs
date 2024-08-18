using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BirimValidator:AbstractValidator<BirimlerTbl>
    {
        public BirimValidator()
        {
            RuleFor(x => x.BirimAdi).NotEmpty().WithMessage("Birim adı boş geçilemez.");
            RuleFor(x => x.BirimAdi).MinimumLength(3).WithMessage("Birim adı en az 3 karakter olmalıdır.");
            RuleFor(x => x.BirimAdi).MaximumLength(150).WithMessage("Birim adı en fazla 150 karakter olmalıdır.");
        }
    }
}
