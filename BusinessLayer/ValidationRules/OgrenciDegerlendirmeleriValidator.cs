using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class OgrenciDegerlendirmeleriValidator:AbstractValidator<OgrenciDegerlendirmeleriTbl>
    {
        public OgrenciDegerlendirmeleriValidator() 
        {
            RuleFor(x => x.Degerlendirme).NotEmpty().WithMessage("Değerlendirme bilgisi boş geçilemez.");
            RuleFor(x => x.Degerlendirme).MinimumLength(5).WithMessage("Değerlendirme 5 karakterden az olmamalıdır.");
        }
    }
}
