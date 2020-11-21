using ApplicationDomain.Identity.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Identity.Models
{
    public class UpdatedUserRq
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
    }

    public class UpdatedUserRqMapper : Profile
    {
        public UpdatedUserRqMapper()
        {
            CreateMap<UpdatedUserRq, User>();
        }
    }

    public class UpdatedUserRqValidator : AbstractValidator<UpdatedUserRq>
    {
        public UpdatedUserRqValidator()
        {
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.PhoneNumber).NotEmpty();
        }
    }
}
