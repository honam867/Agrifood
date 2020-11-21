using ApplicationDomain.Core.Entities;

namespace ApplicationDomain.BOA.Entities
{
    public class Company : EntityBase<int>
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
        public string WebsiteURL { get; set; }
        public int? RepresentativeId { get; set; }
        public string StampURL { get; set; }
        public string FacebookName { get; set; }
    }
}
