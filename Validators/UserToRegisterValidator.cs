using FluentValidation;
using SehirRehberi.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaksiDuragi.API.Validators
{
    public class UserToRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserToRegisterValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull().WithMessage("Bu alan boş olamaz.")
                .EmailAddress().WithMessage("Bu alan e-posta formatına uygun olmalıdır.");

            RuleFor(x => x.TaxiStationName)
                .MinimumLength(2).WithMessage("Bu alan en az 2 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Bu alan boş olamaz")
                .Matches(regex: new Regex(@"(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"))
                .WithMessage("Parola minimum 8 karakter olmalı ve en az 1 büyük harf, 1 küçük harf, 1 sayı ve 1 özel karakter içermelidir.");
        }
    }
}
