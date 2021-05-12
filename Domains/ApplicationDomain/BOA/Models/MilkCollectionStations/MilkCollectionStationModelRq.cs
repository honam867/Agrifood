using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.MilkCollectionStations
{
    public class MilkCollectionStationModelRq
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int DistrictId { get; set; }
    }

    public class MilkCollectionStationModelRqMapper : Profile
    {
        public MilkCollectionStationModelRqMapper()
        {
            CreateMap<MilkCollectionStationModelRq, MilkCollectionStation>();
            var mapers = CreateMap<MilkCollectionStation, MilkCollectionStationModelRq>();
        }
    }
    public class MilkCollectionStationModelRqValidator : AbstractValidator<MilkCollectionStationModelRq>
    {
        public MilkCollectionStationModelRqValidator()
        {
            RuleFor(p => p.Code).NotEmpty();
        }
    }
}
