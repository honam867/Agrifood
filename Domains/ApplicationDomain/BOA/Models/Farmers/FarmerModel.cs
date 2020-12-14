using ApplicationDomain.BOA.Entities;
using ApplicationDomain.Identity.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.Farmers
{
    public class FarmerModel
    {
        public string Name { set; get; }
        public string Code { set; get; }
        public string FullName { get; set; }
        public string QrCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public int? DistrictId { set; get; }
        public District District { get; set; }
        public int? ProvinceId { get; set; }
        public Province Province { get; set; }
        public bool isBlock { get; set; }
        public DateTime ContractCreatetionDate { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public string AvatarURL { set; get; }
        public int? MilkCollectionStationId { get; set; }
    }

    public class InventoryLineModelMapper : Profile
    {
        public InventoryLineModelMapper()
        {
            CreateMap<Farmer, FarmerModel>();
        }
    }
}
