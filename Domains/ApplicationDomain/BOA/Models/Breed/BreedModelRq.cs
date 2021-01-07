using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.Breeds
{
    public class BreedModelRq
    {
        public int Id { get; set; }
        public string Name { get; set; } //NOT NULL, LENGTH > 5, UPPER CASE
        public string Code { set; get; } //NOT NULL, LENGTH = 3, UPPER CASE, UNIQUE
    }

    public class BreedModelRqMapper : Profile
    {
        public BreedModelRqMapper()
        {
            CreateMap<BreedModelRq, Breed>();
            var mapers = CreateMap<Breed, BreedModelRq>();
        }
    }
    public class BreedModelRqValidator : AbstractValidator<BreedModelRq>
    {
        public BreedModelRqValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MinimumLength(3);
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.Code).Length(3);
        }
    }
}
