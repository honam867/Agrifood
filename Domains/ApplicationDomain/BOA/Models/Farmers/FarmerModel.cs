using ApplicationDomain.BOA.Entities;
using ApplicationDomain.Identity.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.Farmers
{
    public class FarmerModel
    {
        public int Id { set; get; }
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
        public string UserUserName { get; set; }
        public string BankBranch { get; set; }
        public string Landline { get; set; }
    }

    public class FarmerModelMapper : Profile
    {
        public FarmerModelMapper()
        {
            CreateMap<Farmer, FarmerModel>();
        }
    }
}
