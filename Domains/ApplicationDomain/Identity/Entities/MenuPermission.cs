using ApplicationDomain.Core.Entities;
using ApplicationDomain.Identity.Models.Permissions;
using AutoMapper;

namespace ApplicationDomain.Identity.Entities
{
    public class MenuPermission : EntityBase<int>
    {
        public int PermissionGroupId { set; get; }
        public PermissionGroup PermissionGroup { set; get; }
        // Quotation
        public bool QuotationsMenu { set; get; }
        public bool CreateQuotationMenu { set; get; }
        public bool RulesQuotationMenu { set; get; }
        public bool CustomerQuotaionMenu { set; get; }
        public bool MonthlyReportQuotaionMenu { set; get; }
        public bool SummarizeReportQuotaionMenu { set; get; }
        public bool ShippingCostQuotationMenu { set; get; }
        // Contract
        public bool ContractsMenu { set; get; }
        public bool CreateContractMenu { set; get; }
        public bool ContractTemplateMenu { set; get; }
        // Order
        public bool OrdersMenu { set; get; }
        public bool CreateOrderMenu { set; get; }
        public bool BillMenu { set; get; }
        public bool OrderReportMenu { set; get; }
        // Library
        public bool LibraryMenu { get; set; }
        public bool CustomerLibraryMenu { set; get; }
        public bool DistrictLibraryMenu { set; get; }
        public bool OtherMenu { set; get; }
        // HRM
        public bool HRMMenu { get; set; }
        // User
        public bool UserMenu { get; set; }
        // Asset
        public bool AssetMenu { get; set; }
        // System
        public bool SystemMenu { get; set; }
        // Structure
        public bool StructureMenu { get; set; }
        // Inventory
        public bool InventoryMenu { get; set; }
        // Purchase
        public bool PurchaseMenu { get; set; }
        // Service
        public bool ServiceMenu { get; set; }
    }

    public class MenuPermissionMapper : Profile
    {
        public MenuPermissionMapper()
        {
            CreateMap<MenuPermissionModel, MenuPermission>();
        }
    }
}
