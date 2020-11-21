using AspNetCore.FluentValidation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Identity.Models
{
    public class UserChangePasswordRq
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ReNewPassword { get; set; }
    }

    public class ChangePasswordModelValidator : AbstractValidator<UserChangePasswordRq>
    {
        public ChangePasswordModelValidator()
        {
            RuleFor(p => p.ReNewPassword).Equal(p => p.NewPassword).WithMessage("Password and Re-password are not match");
            RuleFor(p => p.NewPassword).MinimumLength(8);
        }
    }
}
