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
        public string Name { set; get; }
        public string Code { set; get; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public int? DistrictId { set; get; }
        public int? ProvinceId { get; set; }
        public bool IsBlock { get; set; }
        public DateTime ContractCreatetionDate { get; set; }
        public int? UserId { get; set; }
        public int? MilkCollectionStationId { get; set; }
        public int? WareHouseId { get; set; }
        public string IdentificationNo { get; set; }
        public DateTime IssuedOn { get; set; }
        public string IssuedBy { get; set; }
        public string AccountNumber { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
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

