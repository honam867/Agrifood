using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.Companys
{
    public class CompanyModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string ForeignName { set; get; }
        public string ShortName { set; get; }
        public string Code { set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Fax { set; get; }
        public string TaxCode { set; get; }
        public string LogoURL { set; get; }
        public string WebsiteURL { get; set; }
        public int? RepresentativeId { get; set; }
        public string FacebookName { get; set; }
        public string StampURL { get; set; }
        public CompanyModel()
        {
            Id = 1;
            Name = "";
            ForeignName = "";
            ShortName = "";
            Code = "";
            Address = "";
            Email = "";
            PhoneNumber = "";
            Fax = "";
            TaxCode = "";
            LogoURL = "";
            WebsiteURL = "";
            RepresentativeId = -1;
        }
    }
    public class CompanyModelMapper : Profile
    {
        public CompanyModelMapper()
        {
            CreateMap<Company, CompanyModel>();
            CreateMap<CompanyModel, Company>();
        }
    }
}
