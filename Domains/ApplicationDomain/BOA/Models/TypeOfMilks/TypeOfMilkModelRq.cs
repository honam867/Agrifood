using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.TypeOfMilks
{
    public class TypeOfMilkModelRq
    {
        public string Name { get; set; } //NOT NULL, LENGTH > 5, UPPER CASE
        public string Code { set; get; } //NOT NULL, LENGTH = 3, UPPER CASE, UNIQUE
        
    }

    public class TypeOfMilkModelRqMapper : Profile
    {
        public TypeOfMilkModelRqMapper()
        {
            CreateMap<TypeOfMilkModelRq, TypeOfMilk>();
            var mapers = CreateMap<TypeOfMilk, TypeOfMilkModelRq>();
        }
    }
    public class TypeOfMilkModelRqValidator : AbstractValidator<TypeOfMilkModelRq>
    {
        public TypeOfMilkModelRqValidator()
        {
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.Code).Length(3);
        }
    }
}
