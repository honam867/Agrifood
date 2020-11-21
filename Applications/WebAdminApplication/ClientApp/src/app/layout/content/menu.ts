// import { Menu } from 'src/app/models/menu';

// export const MENU: Menu[] = [
//   {
//     name: 'Quotation',
//     title: 'Báo giá',
//     url: '',
//     icon: 'assets/images/tags.svg',
//     haveChild: true,
//     isExpand: false,
//     isChecked: false,
//     child: [
//       {
//         title: 'Danh sách',
//         url: '/quotations',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       // {
//       //   title: 'Tạo báo giá',
//       //   url: '',
//       //   haveChild: false,
//       //   isExpand: false,
//       //   child: []
//       // },
//       {
//         title: 'Điều khoản',
//         url: '/quotationterms',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Gói bảo dưỡng',
//         url: '/assetservicepackage',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Khách hàng',
//         url: '/library/customer',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Tỉ giá',
//         url: '/library/quotation/exchangerate',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Đo lường báo giá',
//         url: '',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Báo cáo',
//         url: '',
//         haveChild: true,
//         isExpand: false,
//         child: [
//           {
//             title: 'Báo cáo tổng hợp',
//             url: '/term',
//             haveChild: false,
//             isExpand: false,
//             child: []
//           },
//           {
//             title: 'Báo cáo tháng',
//             url: '/term',
//             haveChild: false,
//             isExpand: false,
//             child: []
//           }
//         ]
//       },
//       {
//         title: 'Chi phí vận chuyển',
//         url: '/shippingcost',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Chính sách bán hàng',
//         url: '/promotioninfo',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Đơn vị tính',
//         url: '/unit',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//     ]
//   },
//   {
//     name: 'Contract',
//     title: 'Hợp đồng',
//     url: '',
//     icon: 'assets/images/contract.svg',
//     haveChild: true,
//     isChecked: false,
//     isExpand: false,
//     child: [
//       {
//         title: 'Danh sách',
//         url: '/contract/contractinfo',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Tạo hợp đồng',
//         url: '/contract/createcontract',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Loại hợp đồng',
//         url: '/contract/typecontract',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Hình thức hợp đồng',
//         url: '/contract/contractform',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Mẫu hợp đồng',
//         url: '/contract/contractsample',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//     ]
//   },
//   {
//     name: 'Order',
//     title: 'Đơn hàng',
//     url: '',
//     icon: 'assets/images/box.svg',
//     haveChild: true,
//     isChecked: false,
//     isExpand: false,
//     child: [
//       {
//         title: 'Danh sách',
//         url: '',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Tạo đơn hàng',
//         url: '',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Hóa đơn',
//         url: '',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Báo cáo',
//         url: '',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       }
//     ]
//   },
//   {
//     name: 'Service',
//     title: 'Dịch vụ bảo trì',
//     url: '',
//     icon: 'assets/images/maintenance.svg',
//     haveChild: true,
//     isChecked: false,
//     isExpand: false,
//     child: [
//       {
//         title: 'Các yêu cầu',
//         url: '',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Các công việc',
//         url: '',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Sơ đồ thiết bị',
//         url: '',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       }
//     ]
//   },
//   {
//     name: 'Shopping',
//     title: 'Mua hàng',
//     url: '',
//     icon: 'assets/images/goods.svg',
//     haveChild: false,
//     isChecked: false,
//     isExpand: false,
//     child: []
//   },
//   {
//     name: 'Inventory',
//     title: 'Kho',
//     url: '',
//     icon: 'assets/images/warehouse.svg',
//     haveChild: false,
//     isChecked: false,
//     isExpand: false,
//     child: []
//   },
//   {
//     name: 'Hrm',
//     title: 'Nhân sự',
//     url: ' ',
//     icon: 'assets/images/image.svg',
//     haveChild: true,
//     isChecked: false,
//     isExpand: false,
//     child: [
//       {
//         title: 'Danh sách nhân viên',
//         url: '/employee/staff/listallemployee',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       }
//     ]
//   },
//   {
//     name: 'User',
//     title: 'Người dùng',
//     url: '/user',
//     icon: 'assets/images/account.svg',
//     haveChild: false,
//     isChecked: false,
//     isExpand: false,
//     child: []
//   },
//   {
//     name: 'Asset',
//     title: 'Máy',
//     url: '',
//     icon: 'assets/images/icon/saw-machine.svg',
//     haveChild: true,
//     isChecked: false,
//     isExpand: false,
//     child: [
//       {
//         title: 'Danh sách',
//         url: '/asset/machine',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Loại máy',
//         url: '/asset/assetcategory',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Bộ phận',
//         url: '/asset/assetpart',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Chi tiết bộ phận',
//         url: '/asset/assetsparepart',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Hãng sản xuất',
//         url: '/library/engine/manufacturer',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//     ]
//   },
//   {
//     name: 'System',
//     title: 'Hệ thống',
//     url: '',
//     icon: 'assets/images/networking.svg',
//     haveChild: true,
//     isChecked: false,
//     isExpand: false,
//     child: [
//       {
//         title: 'Phân quyền',
//         url: '/system/permissiongroups',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Vai trò',
//         url: '/system/role',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Chức năng',
//         url: '/system/function',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//     ]
//   },
//   {
//     name: 'Structure',
//     title: 'Cơ cấu tổ chức',
//     url: '',
//     icon: 'assets/images/order.svg',
//     haveChild: true,
//     isChecked: false,
//     isExpand: false,
//     child: [
//       {
//         title: 'Thông tin công ty',
//         url: '/system/info',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Chi nhánh',
//         url: '/system/branch',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Phòng ban',
//         url: '/system/department',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Nhóm',
//         url: '/system/group',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Chức vụ',
//         url: '/library/employee/position',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       }
//     ]
//   },

//   {
//     name: 'Library',
//     title: 'Thư Viện',
//     url: '',
//     icon: 'assets/images/library.svg',
//     haveChild: true,
//     isChecked: false,
//     isExpand: false,
//     child: [
//       {
//         title: 'Khách hàng',
//         url: '/library/customer',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Nhà máy',
//         url: '/library/engine/factory',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Tỉnh/Thành phố',
//         url: '/library/province',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Khu Vực',
//         url: '/library/district',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       },
//       {
//         title: 'Khác',
//         url: '/library/other',
//         haveChild: false,
//         isExpand: false,
//         child: []
//       }
//     ]
//   }
// ];
