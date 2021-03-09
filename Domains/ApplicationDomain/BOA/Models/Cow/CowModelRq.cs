using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.Cows
{
    public class CowModelRq
    {
        public int ByreId { set; get; }
        public int? MotherId { set; get; }
        public int? FatherId { set; get; }
        public string Name { set; get; }
        public string QRCode { set; get; }
        public string Code { set; get; }
        public DateTime Birthday { set; get; }
        public int? AgeNumber { set; get; }
        public string Gender { set; get; }
        public DateTime WeaningDate { set; get; }
        public int FoodSuggestionId { set; get; }
    }

    public class CowModelRqMapper : Profile
    {
        public CowModelRqMapper()
        {
            CreateMap<CowModelRq, Cow>();
            var mapers = CreateMap<Cow, CowModelRq>();
        }
    }
    public class CowModelRqValidator : AbstractValidator<CowModelRq>
    {
        public CowModelRqValidator()
        {
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.Code).Length(3);
        }
    }
}
