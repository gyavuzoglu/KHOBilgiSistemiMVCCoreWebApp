using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PersonelValidator : AbstractValidator<PersonelTbl>
    {
        public PersonelValidator()
        {
            RuleFor(x => x.PersonelTC).NotEmpty().WithMessage("TC kimlik numarası boş geçilemez.");
            RuleFor(x => x.PersonelTC).MinimumLength(11).WithMessage("TC kimlik numarası 11 karakterden az olmamalıdır.");
            RuleFor(x => x.PersonelTC).MaximumLength(11).WithMessage("TC kimlik numarası 11 karakterden fazla olmamalıdır.");

            RuleFor(x => x.Adi).NotEmpty().WithMessage("Adı boş geçilemez.");
            RuleFor(x => x.Adi).MinimumLength(3).WithMessage("Adı 3 karakterden az olmamalıdır.");
            RuleFor(x => x.Adi).MaximumLength(50).WithMessage("Adı 50 karakterden fazla olmamalıdır.");

            RuleFor(x => x.Soyadi).NotEmpty().WithMessage("Soyadı boş geçilemez.");
            RuleFor(x => x.Soyadi).MinimumLength(3).WithMessage("Soyadı 3 karakterden az olmamalıdır.");
            RuleFor(x => x.Soyadi).MaximumLength(50).WithMessage("Soyadı 50 karakterden fazla olmamalıdır.");

            
        }
    }
}

