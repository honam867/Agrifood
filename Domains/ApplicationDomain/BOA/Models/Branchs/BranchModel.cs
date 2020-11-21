using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.Branchs
{
    public class BranchModel
    {
        public int Id { get; set; }
        public string Name { get; set; } //NOT NULL, LENGTH > 5, UPPER CASE
        public string ForeignName { set; get; }
        public string ShortName { set; get; }
        public string Code { set; get; } //NOT NULL, LENGTH = 3, UPPER CASE, UNIQUE
        public string Address { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Fax { set; get; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
    }
    public class BranchModelMapper : Profile
    {
        public BranchModelMapper()
        {
            CreateMap<BranchModel, Branch>();
            var mapers = CreateMap<Branch, BranchModel>();
            mapers.ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.Company.Name));
            mapers.ForMember(d => d.DistrictName, opt => opt.MapFrom(s => s.District.Name));
        }
    }
}
