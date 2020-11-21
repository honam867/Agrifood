using FluentValidation;

namespace ApplicationDomain.Identity.Models
{
    public class ResetPasswordRq
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
    }
    public class ResetPasswordRqValidator : AbstractValidator<ResetPasswordRq>
    {
        public ResetPasswordRqValidator()
        {
            RuleFor(p => p.Password).MinimumLength(8);
        }
    }
}
