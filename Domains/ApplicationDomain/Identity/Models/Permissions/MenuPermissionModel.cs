using ApplicationDomain.Identity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Identity.Models.Permissions
{
    public class MenuPermissionModel
    {
        public bool QuotationsMenu { set; get; }
        public bool CreateQuotationMenu { set; get; }
        public bool RulesQuotationMenu { set; get; }
        public bool CustomerQuotaionMenu { set; get; }
        public bool MonthlyReportQuotaionMenu { set; get; }
        public bool SummarizeReportQuotaionMenu { set; get; }
        public bool ShippingCostQuotationMenu { set; get; }
        public bool ContractsMenu { set; get; }
        public bool CreateContractMenu { set; get; }
        public bool ContractTemplateMenu { set; get; }
        public bool OrdersMenu { set; get; }
        public bool CreateOrderMenu { set; get; }
        public bool BillMenu { set; get; }
        public bool OrderReportMenu { set; get; }
        public bool LibraryMenu { get; set; }
        public bool CustomerLibraryMenu { set; get; }
        public bool DistrictLibraryMenu { set; get; }
        public bool OtherMenu { set; get; }
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

    public class MenuPermissionModelMapper : Profile
    {
        public MenuPermissionModelMapper()
        {
            CreateMap<MenuPermission, MenuPermissionModel>();
        }
    }
}
