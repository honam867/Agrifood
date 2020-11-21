import { environment } from 'src/environments/environment';
import decode from 'jwt-decode';

export class Permission {

    static canAccessQuotationsMenu = false;
    static createQuotationMenu = false;
    static rulesQuotationMenu = false;
    static customerQuotaionMenu = false;
    static monthlyReportQuotaionMenu = false;
    static summarizeReportQuotaionMenu = false;
    static shippingCostQuotationMenu = false;
    static contractsMenu = false;
    static createContractMenu = false;
    static contractTemplateMenu = false;
    static ordersMenu = false;
    static createOrderMenu = false;
    static billMenu = false;
    static orderReportMenu = false;
    static customerLibraryMenu = false;
    static districtLibraryMenu = false;
    static otherMenu = false;

    public static LoadPermission() {
        const token = localStorage.getItem(environment.tokenKey);
        if (token) {
            const permission = decode(token).permission;
            this.canAccessQuotationsMenu = permission.canAccessQuotationsMenu;
            this.createQuotationMenu = permission.createQuotationMenu;
            this.rulesQuotationMenu = permission.rulesQuotationMenu;
            this.customerQuotaionMenu = permission.customerQuotaionMenu;
            this.monthlyReportQuotaionMenu = permission.monthlyReportQuotaionMenu;
            this.summarizeReportQuotaionMenu = permission.summarizeReportQuotaionMenu;
            this.shippingCostQuotationMenu = permission.shippingCostQuotationMenu;
            this.contractsMenu = permission.contractsMenu;
            this.createContractMenu = permission.createContractMenu;
            this.contractTemplateMenu = permission.contractTemplateMenu;
            this.ordersMenu = permission.ordersMenu;
            this.createOrderMenu = permission.createOrderMenu;
            this.billMenu = permission.billMenu;
            this.orderReportMenu = permission.orderReportMenu;
            this.customerLibraryMenu = permission.customerLibraryMenu;
            this.districtLibraryMenu = permission.districtLibraryMenu;
            this.otherMenu = permission.otherMenu;
        }
    }
}
