using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Identity.Models.Permissions
{
    public class GrantedPermission
    {
        public bool IsManagerOrDirector { get; set; }
        // Quotation
        public bool CanAccessQuotationsMenu { set; get; }
        public bool CreateQuotationMenu { set; get; }
        public bool RulesQuotationMenu { set; get; }
        public bool CustomerQuotaionMenu { set; get; }
        public bool MonthlyReportQuotaionMenu { set; get; }
        public bool SummarizeReportQuotaionMenu { set; get; }
        public bool ShippingCostQuotationMenu { set; get; }
        public bool CanViewQuotationService { get; set; }
        public bool CanViewQuotationCommerce { get; set; }
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
        public bool CanAccessLibraryMenu { get; set; }
        public bool CustomerLibraryMenu { set; get; }
        public bool DistrictLibraryMenu { set; get; }
        public bool OtherMenu { set; get; }
        // HRM
        public bool CanAccessHRMMenu { get; set; }
        // User
        public bool CanAccessUserMenu { get; set; }
        // Asset
        public bool CanAccessAssetMenu { get; set; }
        // System
        public bool CanAccessSystemMenu { get; set; }
        // Structure
        public bool CanAccessStructureMenu { get; set; }
        // Inventory
        public bool CanAccessInventoryMenu { get; set; }
        // Purchase
        public bool CanAccessPurchaseMenu { get; set; }
        // Service
        public bool CanAccessServiceMenu { get; set; }    
    }
}
