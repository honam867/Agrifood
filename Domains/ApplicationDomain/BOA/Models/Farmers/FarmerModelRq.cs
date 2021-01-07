using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.Models.Farmers;
using ApplicationDomain.Identity.Entities;
using AutoMapper;
using FluentValidation;
using System;

namespace ApplicationDomain.BOA.Models.Farmers
{
    public class FarmerModelRq
    {
        public string Id { get; set; }
        public string Name { set; get; }
        public string Code { set; get; }
        public string FullName { get; set; }
        public string QrCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public int? DistrictId { set; get; }
        public int? ProvinceId { get; set; }
        public bool IsBlock { get; set; }
        public DateTime ContractCreatetionDate { get; set; }
        public int? UserId { get; set; }
        public string AvatarURL { set; get; }
        public int? MilkCollectionStationId { get; set; }
    }
}

public class FarmerModelRqMapper : Profile
{
    public FarmerModelRqMapper()
    {
        CreateMap<FarmerModelRq, Farmer>();
        var mapers = CreateMap<Farmer, FarmerModelRq>();
    }
}

public class FarmerModelRqValidator : AbstractValidator<FarmerModelRq>
{
    public FarmerModelRqValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Code).NotEmpty();
    }
}

