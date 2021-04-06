using ApplicationDomain.Core.Entities;
using ApplicationDomain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class Farmer : EntityBase<int>
    {
        public string Name { set; get; }
        public string Code { set; get; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public int? DistrictId { set; get; }
        public District District { get; set; }
        public int? ProvinceId { get; set; }
        public Province Province { get; set; }
        public bool IsBlock { get; set; }
        public DateTime ContractCreatetionDate { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? MilkCollectionStationId { get; set; }
        public MilkCollectionStation MilkCollectionStation { get; set; }
        public int? WareHouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public string IdentificationNo { get; set; }
        public DateTime IssuedOn { get; set; }
        public string IssuedBy { get; set; }
        public string AccountNumber { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set;  }
    }
}