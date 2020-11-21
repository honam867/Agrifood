using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class Branch : EntityBase<int>
    {
        public string Name { set; get; }
        public string AppelationOfForeignTrader { set; get; }
        public string ForeignName { set; get; }
        public string ShortName { set; get; }
        public string Code { set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Fax { set; get; }
        public string TaxCode { set; get; }
        public string LogoURL { set; get; }
        public int DistrictId { set; get; }
        public District District { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}