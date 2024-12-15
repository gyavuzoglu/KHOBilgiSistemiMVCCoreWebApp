using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class KisimDegerlendirmeleriValidator:AbstractValidator<KisimDegerlendirmeleriTbl>
    {
        public KisimDegerlendirmeleriValidator() 
        {
            RuleFor(x => x.KisimDegerlendirme).NotEmpty().WithMessage("Değerlendirme bilgisi boş geçilemez.");
            RuleFor(x => x.KisimDegerlendirme).MinimumLength(5).WithMessage("Değerlendirme 5 karakterden az olmamalıdır.");
        }
    }
}
