using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.FirstName).Must(IsLetter).WithMessage(Messages.FirstNameMustContainOnlyLetter);

            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.LastName).Must(IsLetter).WithMessage(Messages.LastNameMustContainOnlyLetter);

            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();

            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(6);
            RuleFor(u => u.Password).Must(IsContainLetter).Must(IsContainDigit).Must(IsContainSpecialCharacter).WithMessage(Messages.PasswordRequirements);
        }

        private bool IsLetter(string arg)
        {
            Regex regex = new Regex(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ]+$");
            return regex.IsMatch(arg);
        }

        private bool IsContainLetter(string arg)
        {
            return arg.Any(char.IsLetter);
        }
        private bool IsContainDigit(string arg)
        {
            return arg.Any(char.IsDigit);
        }
        private bool IsContainSpecialCharacter(string arg)
        {
            char[] specialCharacters = new char[] { '@', '#', '$', '!', '.', ',', '*', '-', '_', ';', '+', '-', '<', '>' };

            return arg.Any(char.IsLetter);
        }
    }
}
