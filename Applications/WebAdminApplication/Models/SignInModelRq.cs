using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdminApplication.Models
{
    public class SignInModelRq
    {
        public string UserName { set; get; }
        public string Password { set; get; }
    }

    public class SignInModelRqValidator : AbstractValidator<SignInModelRq>
    {
        public SignInModelRqValidator()
        {
            RuleFor(p => p.UserName).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
        }
    }
}
