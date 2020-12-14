// import { Component, OnInit } from '@angular/core';
// import { Menu } from 'src/app/models/menu';

// declare const $: any;

// export const ROUTES: Menu[] = [
//   {
//     path: '#quotations', title: 'Báo giá', icon: 'dashboard', class: 'quotations', haveChild: true, child: [
//       // { path: '/survey', title: 'Phiếu tiếp nhận', icon: 'P', class: '', haveChild: true, child: [] },
//       // { path: '/surveyexpert', title: 'Chờ tư vấn', icon: 'C', class: '', haveChild: true, child: [] },
//       { path: '/quotations', title: 'Danh sách báo giá', icon: 'fact_check', class: '', haveChild: true, child: [] },
//       { path: '/termconfiguration', title: 'Điều khoản báo giá', icon: 'branding_watermark', class: '', haveChild: true, child: [] },
//       { path: '/material', title: 'Danh sách vật liệu', icon: 'category', class: '', haveChild: true, child: [] },
//       // { path: '/managerlistquotation', title: 'Kiểm tra báo giá', icon: 'K', class: '', haveChild: true, child: [] },
//       // { path: '/directorlistquotation', title: 'Ban hành báo giá', icon: 'B', class: '', haveChild: true, child: [] },
//       { path: '/library/quotation/exchangerate', title: 'Tỷ giá', icon: 'trending_up', class: '', haveChild: true, child: [] },
//       { path: '/product', title: 'Bản vẽ', icon: 'widgets', class: '', haveChild: true, child: [] },
//       { path: '/library/customer', title: 'Danh sách khách hàng', icon: 'list_alt', class: '', haveChild: true, child: [] },
//       // { path: '/repairserviceconfiguration', title: 'Bậc thợ', icon: 'B', class: '', haveChild: true, child: [] }
//     ]
//   },
//   // {
//   //   path: '#customer', title: 'Khách hàng', icon: 'person', class: 'customer', haveChild: true, child: [
//   //     { path: '/library/customer', title: 'Danh sách khách hàng', icon: 'D', class: '', haveChild: true, child: [] },
//   //     { path: '/library/customercare', title: 'Khách hàng phải chăm sóc', icon: 'C', class: '', haveChild: true, child: [] },
//   //   ]
//   // },
//   // {
//   //   path: '#contact', title: 'Hợp đồng', icon: 'content_paste', class: 'contact', haveChild: true, child: [
//   //     { path: '/contract/contractinfo', title: 'Danh sách', icon: 'D', class: '', haveChild: true, child: [] },
//   //     { path: '/contract/createcontract', title: 'Tạo hợp đồng', icon: 'T', class: '', haveChild: true, child: [] },
//   //     { path: '/contract/contractform', title: 'Hình thức hợp đồng', icon: 'H', class: '', haveChild: true, child: [] },
//   //     { path: '/contract/contractsample', title: 'Mẫu hợp đồng', icon: 'K', class: '', haveChild: true, child: [] }
//   //   ]
//   // },
//   // {
//   //   path: '#layoutWarehouse', title: 'Cấu trúc nhà kho', icon: 'library_books', class: 'layoutWarehouse', haveChild: true, child: [
//   //     { path: '/warehouse/warehousepage', title: 'Nhà kho', icon: 'N', class: '', haveChild: true, child: [] },
//   //     { path: '/warehouse/warehouselocation', title: 'Nơi để', icon: 'N', class: '', haveChild: true, child: [] },
//   //     { path: '/warehouse/warehousearea', title: 'Khu vực nhà kho', icon: 'K', class: '', haveChild: true, child: [] },
//   //     { path: '/warehouse/warehouserow', title: 'Kệ', icon: 'K', class: '', haveChild: true, child: [] },
//   //     { path: '/warehouse/warehouseshelf', title: 'Tầng', icon: 'T', class: '', haveChild: true, child: [] },
//   //     { path: '/warehouse/warehouserack', title: 'Ô', icon: 'O', class: '', haveChild: true, child: [] }
//   //   ]
//   // },
//   // {
//   //   path: '#reciept', title: 'Nhập kho', icon: 'bubble_chart', class: 'reciept', haveChild: true, child: [
//   //     { path: '/warehouse/warehousereceiptrequest', title: 'Phiếu yêu cầu nhập kho', icon: 'Y', class: '', haveChild: true, child: [] },
//   //     { path: '/warehouse/warehousereceipt', title: 'Phiếu nhập kho', icon: 'P', class: '', haveChild: true, child: [] }
//   //   ]
//   // },
//   // {
//   //   path: '#delivery', title: 'Xuất kho', icon: 'location_on', class: 'delivery', haveChild: true, child: [
//   //     { path: '/warehouse/inventorydeliveryrequest', title: 'Phiếu yêu cầu xuất kho', icon: 'Y', class: '', haveChild: true, child: [] },
//   //     { path: '/warehouse/warehousedeliverynote', title: 'Phiếu xuất kho', icon: 'P', class: '', haveChild: true, child: [] }
//   //   ]
//   // },
//   {
//     path: '#system', title: 'Hệ thống', icon: 'settings_system_daydream', class: 'system', haveChild: true, child: [
//       { path: '/user', title: 'Tài khoản', icon: 'T', class: '', haveChild: true, child: [] },
//       { path: '/system/permissiongroups', title: 'Phân quyền', icon: 'P', class: '', haveChild: true, child: [] },
//       { path: '/system/role', title: 'Vai trò', icon: 'V', class: '', haveChild: true, child: [] }
//     ]
//   },
//   {
//     path: '#employee', title: 'Nhân viên', icon: 'perm_contact_calendar', class: 'employee', haveChild: true, child: [
//       { path: '/employee/staff/listallemployee', title: 'Nhân viên', icon: 'T', class: '', haveChild: true, child: [] },
//     ]
//   },
//   {
//     path: '#structure', title: 'Cơ cấu tổ chức', icon: 'business', class: 'structure', haveChild: true, child: [
//       { path: '/system/info', title: 'Thông tin công ty', icon: 'T', class: '', haveChild: true, child: [] },
//       { path: '/system/branch', title: 'Chi nhánh', icon: 'C', class: '', haveChild: true, child: [] },
//       { path: '/system/department', title: 'Phòng ban', icon: 'P', class: '', haveChild: true, child: [] },
//       { path: '/system/group', title: 'Nhóm', icon: 'N', class: '', haveChild: true, child: [] },
//       { path: '/library/employee/position', title: 'Chức vụ', icon: 'C', class: '', haveChild: true, child: [] }
//     ]
//   },
//   {
//     path: '#library', title: 'Thư viện', icon: 'unarchive', class: 'library', haveChild: true, child: [
//       { path: '/materialtype', title: 'Khối lượng riêng', icon: 'category', class: '', haveChild: true, child: [] },
//       { path: '/library/itemtype', title: 'Chủng loại Bản vẽ', icon: 'theaters', class: '', haveChild: true, child: [] },
//       { path: '/library/productionstep', title: 'Nguyên công', icon: 'N', class: '', haveChild: true, child: [] },
//       { path: '/library/productionstepsample', title: 'Quy trình công nghệ', icon: 'Q', class: '', haveChild: true, child: [] },
//     ]
//   }
// ];

// @Component({
//   selector: 'app-sidebar',
//   templateUrl: './sidebar.component.html',
//   styleUrls: ['./sidebar.component.scss']
// })
// export class SidebarComponent implements OnInit {
//   menuItems: any[];

//   constructor() { }

//   ngOnInit() {
//     this.menuItems = ROUTES.filter(menuItem => menuItem);
//   }
//   isMobileMenu() {
//     if ($(window).width() > 991) {
//       return true;
//     }
//     return true;
//   }
// }
import { Component, OnInit } from '@angular/core';
import PerfectScrollbar from 'perfect-scrollbar';

declare const $: any;

//Metadata
export interface RouteInfo {
    path: string;
    title: string;
    type: string;
    icontype: string;
    collapse?: string;
    children?: ChildrenItems[];
}

export interface ChildrenItems {
    path: string;
    title: string;
    ab: string;
    type?: string;
}

//Menu Items
export const ROUTES: RouteInfo[] = [{
        path: '/dashboard',
        title: 'Thống kê',
        type: 'link',
        icontype: 'dashboard'
    },{
        path: '/components',
        title: 'Components',
        type: 'sub',
        icontype: 'apps',
        collapse: 'components',
        children: [
            {path: 'buttons', title: 'Buttons', ab:'B'},
            {path: 'grid', title: 'Grid System', ab:'GS'},
            {path: 'panels', title: 'Panels', ab:'P'},
            {path: 'sweet-alert', title: 'Sweet Alert', ab:'SA'},
            {path: 'notifications', title: 'Notifications', ab:'N'},
            {path: 'icons', title: 'Icons', ab:'I'},
            {path: 'typography', title: 'Typography', ab:'T'}
        ]
    },{
        path: '/forms',
        title: 'Forms',
        type: 'sub',
        icontype: 'content_paste',
        collapse: 'forms',
        children: [
            {path: 'regular', title: 'Regular Forms', ab:'RF'},
            {path: 'extended', title: 'Extended Forms', ab:'EF'},
            {path: 'validation', title: 'Validation Forms', ab:'VF'},
            {path: 'wizard', title: 'Wizard', ab:'W'}
        ]
    },{
        path: '/tables',
        title: 'Tables',
        type: 'sub',
        icontype: 'grid_on',
        collapse: 'tables',
        children: [
            {path: 'regular', title: 'Regular Tables', ab:'RT'},
            {path: 'extended', title: 'Extended Tables', ab:'ET'},
            {path: 'datatables.net', title: 'Datatables.net', ab:'DT'}
        ]
    },{
        path: '/maps',
        title: 'Maps',
        type: 'sub',
        icontype: 'place',
        collapse: 'maps',
        children: [
            {path: 'google', title: 'Google Maps', ab:'GM'},
            {path: 'fullscreen', title: 'Full Screen Map', ab:'FSM'},
            {path: 'vector', title: 'Vector Map', ab:'VM'}
        ]
    },{
        path: '/widgets',
        title: 'Widgets',
        type: 'link',
        icontype: 'widgets'

    },{
        path: '/charts',
        title: 'Charts',
        type: 'link',
        icontype: 'timeline'

    },{
        path: '/calendar',
        title: 'Calendar',
        type: 'link',
        icontype: 'date_range'
    },{
        path: '/pages',
        title: 'Pages',
        type: 'sub',
        icontype: 'image',
        collapse: 'pages',
        children: [
            {path: 'pricing', title: 'Pricing', ab:'P'},
            {path: 'timeline', title: 'Timeline Page', ab:'TP'},
            {path: 'login', title: 'Login Page', ab:'LP'},
            {path: 'register', title: 'Register Page', ab:'RP'},
            {path: 'lock', title: 'Lock Screen Page', ab:'LSP'},
            {path: 'user', title: 'User Page', ab:'UP'}
        ]
    }
];
@Component({
    selector: 'app-sidebar',
    templateUrl: 'sidebar.component.html',
})

export class SidebarComponent implements OnInit {
    public menuItems: any[];
    ps: any;
    isMobileMenu() {
        if ($(window).width() > 991) {
            return false;
        }
        return true;
    };

    ngOnInit() {
        this.menuItems = ROUTES.filter(menuItem => menuItem);
        if (window.matchMedia(`(min-width: 960px)`).matches && !this.isMac()) {
            const elemSidebar = <HTMLElement>document.querySelector('.sidebar .sidebar-wrapper');
            this.ps = new PerfectScrollbar(elemSidebar);
        }
    }
    updatePS(): void  {
        if (window.matchMedia(`(min-width: 960px)`).matches && !this.isMac()) {
            this.ps.update();
        }
    }
    isMac(): boolean {
        let bool = false;
        if (navigator.platform.toUpperCase().indexOf('MAC') >= 0 || navigator.platform.toUpperCase().indexOf('IPAD') >= 0) {
            bool = true;
        }
        return bool;
    }
}
