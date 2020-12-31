using ApplicationDomain.BOA.Entities;
using ApplicationDomain.Identity.Entities;
using AutoMapper;
using FluentValidation;

namespace ApplicationDomain.Identity.Models
{
    public class CreatedUserRq
    {
        public int CustomerId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }
    }

    public class CreatedUserRqMapper : Profile
    {
        public CreatedUserRqMapper()
        {
            CreateMap<CreatedUserRq, User>();
        }
    }

    public class CreatedUserRqValidator : AbstractValidator<CreatedUserRq>
    {
        public CreatedUserRqValidator()
        {
            RuleFor(p => p.UserName).NotEmpty();
            RuleFor(p => p.UserName).MinimumLength(3);
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.Role).NotEmpty();
        }
    }
}
