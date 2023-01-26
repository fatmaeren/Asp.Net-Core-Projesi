using EntitiyLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ServiceValidator : AbstractValidator<Service>
    {
        public ServiceValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Proje Adı Boş Geçilemez");
            RuleFor(x => x.Title).MinimumLength(2).WithMessage("Proje Adı 2 Karekterden Az Olamaz");
        }
    }
}
