using DTOLayer.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserUpdateValidator:AbstractValidator<AppUserUpdateDTOs>
    {
        public AppUserUpdateValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("ad alanı boş geçilemez");
            RuleFor(x => x.surname).NotEmpty().WithMessage("soyad alanı boş geçilemez");
            RuleFor(x => x.password).NotEmpty().WithMessage("şifre alanı boş geçilemez");
            RuleFor(x => x.confirmpassword).NotEmpty().WithMessage("şifre tekrar alanı boş geçilemez");
            RuleFor(x => x.password).Equal(y => y.confirmpassword).WithMessage("şifreler birbiriyle uyuşmuyor");
            RuleFor(x => x.mail)
                .NotEmpty().WithMessage("Mail alanı boş geçilemez.")
                .EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.")
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("Mail adresi uygun formatta olmalıdır.");
        }
    }
}
