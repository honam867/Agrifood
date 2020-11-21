namespace ApplicationDomain.Identity.Models
{
    public class RoleQuotationPermissionModel
    {
        public bool IsQuotationEmployee { get; set; }
        public bool IsQuotationManager { get; set; }
        public bool IsQuotationDirector { get; set; }
        public bool IsQuotationService { get; set; }
        public bool IsQuotationCommercial { get; set; }
    }
}
