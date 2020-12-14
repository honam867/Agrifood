using ApplicationDomain.Identity.Entities;
using AutoMapper;
using FluentValidation;

namespace ApplicationDomain.Identity.Models
{
    public class CreatedFarmerRq
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }
    }

    public class CreatedFarmerRqMapper : Profile
    {
        public CreatedFarmerRqMapper()
        {
            CreateMap<CreatedFarmerRq, User>();
        }
    }

    public class CreatedFarmerRqValidator : AbstractValidator<CreatedFarmerRq>
    {
        public CreatedFarmerRqValidator()
        {
            RuleFor(p => p.UserName).NotEmpty();
            RuleFor(p => p.UserName).MinimumLength(3);
            RuleFor(p => p.PhoneNumber).NotEmpty();
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
        }
    }
}
