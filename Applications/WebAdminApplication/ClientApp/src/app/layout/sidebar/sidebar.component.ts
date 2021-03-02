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
    icontype: 'insert_chart_outlined'
},
{
    path: '/user',
    type: 'sub',
    title: 'Quản lý người dùng',
    collapse: 'user',
    children: [
        {
            path: 'userlist',
            title: 'DANH SÁCH TÀI KHOẢN',
            type: 'link',
            ab: null
        }
    ],
    icontype: 'people_alt'
},
{
    path: '/farmer',
    type: 'sub',
    title: 'Quản lý nông dân',
    collapse: 'famer',
    children: [
        {
            path: 'farmerlist',
            title: 'DANH SÁCH NÔNG DÂN',
            type: 'link',
            ab: null
        }
    ],
    icontype: 'supervised_user_circle'
},
{
    path: '/system',
    type: 'sub',
    title: 'Hệ thống',
    collapse: 'system',
    children: [
        {
            path: 'permissionlist',
            title: 'Phân quyền',
            type: 'link',
            ab: null,
        },
    ],
    icontype: 'settings_applications'
},
{
    path: '/employee',
    type: 'sub',
    title: 'Nhân sự',
    collapse: 'employee',
    children: [
        {
            path: 'employeelist',
            title: 'Danh sách nhân viên',
            type: 'link',
            ab: null
        }
    ],
    icontype: 'work'
},
{
  path: '/province',
  type: 'sub',
  title: 'Địa điểm',
  collapse: 'province',
  children: [
      {
          path: 'provincelist',
          title: 'DANH SÁCH TỈNH THÀNH',
          type: 'link',
          ab: null
      }
  ],
  icontype: 'satellite'
},
];
@Component({
    selector: 'app-sidebar',
    templateUrl: 'sidebar.component.html',
})

export class SidebarComponent implements OnInit {
    public menuItems: any[];
    userInfo: any;
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
        this.userInfo = JSON.parse(localStorage.getItem('userinfo'));
        console.log("🚀 ~ file: sidebar.component.ts ~ line 170 ~ SidebarComponent ~ ngOnInit ~   this.userInfo", this.userInfo)
    }
    updatePS(): void {
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
