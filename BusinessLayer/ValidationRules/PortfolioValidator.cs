using EntitiyLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator: AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Proje Adı Boş Geçilemez");
            RuleFor(x=>x.ImageUrl).NotEmpty().WithMessage("Resim Alanı Boş Geçilemez");
            RuleFor(x=>x.ImageUrl2).NotEmpty().WithMessage("Resim Alanı 2 Boş Geçilemez");
            RuleFor(x=>x.Price).NotEmpty().WithMessage("Fiyat Alanı Boş Geçilemez");
            RuleFor(x=>x.Value).NotEmpty().WithMessage("Değer Alanı Boş Geçilemez");
            RuleFor(x=>x.Name).MinimumLength(2).WithMessage("Proje Adı 2 Karekterden Az Olamaz");

        }
    }
}
