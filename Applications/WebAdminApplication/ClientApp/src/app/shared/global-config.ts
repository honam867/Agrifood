
import { PERMISSION } from './constant';

export class GlobalConfig {
    public static permission = JSON.parse(localStorage.getItem(PERMISSION));
    public static canAccessQuotationsMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.CanAccessQuotationsMenu;
    public static createQuotationMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.CreateQuotationMenu;
    public static rulesQuotationMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.RulesQuotationMenu;
    public static customerQuotaionMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.CstomerQuotaionMenu;
    public static monthlyReportQuotaionMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.MonthlyReportQuotaionMenu;
    public static summarizeReportQuotaionMenu =
        GlobalConfig.permission == null ? false : GlobalConfig.permission.SummarizeReportQuotaionMenu;
    public static shippingCostQuotationMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.ShippingCostQuotationMenu;
    public static contractsMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.ContractsMenu;
    public static createContractMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.CreateContractMenu;
    public static contractTemplateMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.ContractTemplateMenu;
    public static ordersMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.OrdersMenu;
    public static createOrderMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.CreateOrderMenu;
    public static billMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.BillMenu;
    public static orderReportMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.OrderReportMenu;
    public static customerLibraryMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.CustomerLibraryMenu;
    public static districtLibraryMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.DistrictLibraryMenu;
    public static otherMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.OtherMenu;
    // more
    public static canAccessStructureMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.CanAccessStructureMenu;
    public static canAccessLibraryMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.CanAccessLibraryMenu;
    public static canAccessHRMMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.CanAccessHRMMenu;
    public static canAccessUserMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.CanAccessUserMenu;
    public static canAccessAssetMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.CanAccessAssetMenu;
    public static canAccessSystemMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.CanAccessSystemMenu;
    public static canAccessInventoryMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.CanAccessInventoryMenu;
    public static canAccessPurchaseMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.CanAccessPurchaseMenu;
    public static canAccessServiceMenu = GlobalConfig.permission == null ? false : GlobalConfig.permission.CanAccessServiceMenu;
}
