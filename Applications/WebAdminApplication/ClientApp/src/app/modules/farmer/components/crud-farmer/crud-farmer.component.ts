import { CowDashboardComponent } from './../cow-dashboard/cow-dashboard.component';
import { UpdateCowComponent } from './../update-cow/update-cow.component';
import { PersonalDashboardComponent } from './../personal-dashboard/personal-dashboard.component';
import { Notify } from './../../models/notify';
import { ViewDetailComponent } from './../view-detail/view-detail.component';
import { FeedHistoryDetail } from './../../models/feedHistoryDetail';
import { FeedHistory } from './../../models/feedHistory';
import { MatTableDataSource } from '@angular/material/table';
import { AlertComponent } from './../../../../shared/components/alert/alert.component';
import { AddFarmerToUserComponent } from './../../../user/components/add-farmer-to-user/add-farmer-to-user.component';
import { ValueObject } from './../../../../shared/models/value-object';
import { District } from './../../../../models/district';
import { Province } from './../../../../models/province';
import { ConfirmationComponent } from './../../../../shared/components/confirmation/confirmation.component';
import { StatusForm } from './../../../../shared/enum/status-form';
import { FarmerService } from './../../farmer.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Farmer } from './../../models/farmer';
import { MatPaginator } from '@angular/material/paginator';
import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { Byre } from '../../models/byre';
import { Cow } from 'src/app/modules/cow/models/cow';
import { CreateNotiComponent } from '../create-noti/create-noti.component';


@Component({
  selector: 'app-crud-farmer',
  templateUrl: './crud-farmer.component.html',
  styleUrls: ['./crud-farmer.component.scss']
})
export class CrudFarmerComponent implements OnInit {
  page = 1;
  displayedColumns: string[] = [
    'name',
    'action'];
  status: string;
  farmer: Farmer = new Farmer();
  isView = true;
  isCreate = true;
  districts: District[] = [];
  // roles: Role[] = [];
  // roleOfUsers: RoleOfUser[] = [];
  rolesOfUser: any[];
  removeRole: any = {
    userId: 0,
    roleName: '',
  };
  provinces: Province[] = [];
  filteredProvinces: Province[] = [];
  filteredDistricts: District[] = [];
  byreSource: MatTableDataSource<Byre>;
  byres: Byre[] = [];
  histories: FeedHistory[] = [];
  cows: Cow[] = [];
  notifications: Notify[] = [];
  notificationSource: MatTableDataSource<Notify>;
  cowsInByre: Cow[] = [];
  cowSource: MatTableDataSource<Cow>;
  farmerByres: Byre[] = [];
  valueObject: ValueObject = new ValueObject();
  alert: any;
  displayedColumnsByre: string[] = ['name', 'code', 'action'];
  displayedColumnsCow: string[] = ['name', 'code', 'gender', 'birthday', 'status', 'action'];
  historySource: MatTableDataSource<FeedHistory>;
  displayedColumnsHistory: string[] = ['cowId', 'createdDate', 'action'];
  displayedColumnsNotification: string[] = ['name', 'content', 'status', 'action'];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  sourceView: Farmer = new Farmer();
  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<CrudFarmerComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public farmerService: FarmerService
    // private roleService: RoleService,
    // private systemService: SystemService,
  ) { }

  ngOnInit(): void {
    this.farmer = this.data.farmer;
    if (this.data.action === StatusForm.DETELE) {
      this.delete();
    }
    this.isView = this.data.action === StatusForm.VIEW;
    this.isCreate = this.data.action === StatusForm.CREATE;
    this.sourceView = Object.assign({}, this.farmer);
    this.fetchProvince();
    if (this.isView) {
      this.fetchDistrict(this.sourceView.provinceId);
      this.fetchByre();
      this.fetchHistory();
      this.fetchNotifications();
    } else {
      this.fetchNewcode();
    }
  }

  fetchNewcode() {
    this.farmerService.newCode().subscribe(result => {
      this.valueObject = result;
      this.sourceView.code = this.valueObject.value;
    });
  }

  getDistrict(provinceId) {
    this.farmerService.getDistrictByProvinceId(provinceId).subscribe(result => {
      this.districts = result;
      this.filteredDistricts = this.districts;
    });
  }

  popUpCowDashboard(cow: Cow) {
    const viewDialog = this.dialog.open(CowDashboardComponent, {
      height: '90%',
      width: '90%',
      data: {
        action: StatusForm.VIEW,
        cow
      },
      disableClose: true,
    });
  }

  popUpPersonalDashboard(farmer: Farmer) {
    const viewDialog = this.dialog.open(PersonalDashboardComponent, {
      height: '90%',
      width: '90%',
      data: {
        action: StatusForm.VIEW,
        farmer:farmer
      },
      disableClose: true,
    });
  }

  popUpUpdateCow(cow) {
    const viewDialog = this.dialog.open(UpdateCowComponent, {
      height: '35%',
      width: '30%',
      data: {
        action: StatusForm.VIEW,
        cow: cow
      },
      disableClose: true,
    });
    console.log(cow);

    // viewDialog.afterClosed().subscribe(
    //   result => {
    //     this.farmerService.getNotificationById(result.data).subscribe(
    //       createdNoti => {
    //         if (createdNoti !== null) {
    //           this.notifications.push(createdNoti);
    //           this.notificationSource.data = this.notifications;
    //         }
    //       }
    //     );
    //   }
    // );

  }

  popUpCreateNotification() {
    const createDialog = this.dialog.open(CreateNotiComponent, {
      height: '55%',
      width: '60%',
      data: {
        action: StatusForm.CREATE,
        data:this.farmer.id
      },
      disableClose: true,
    });

    createDialog.afterClosed().subscribe(
      result => {
        this.farmerService.getNotificationById(result.data).subscribe(
          createdNoti => {
            if (createdNoti !== null) {
              this.notifications.push(createdNoti);
              this.notificationSource.data = this.notifications;
            }
          }
        );
      }
    );

  }


  viewFeedHistoryDetail(detail: FeedHistoryDetail) {
    this.dialog.open(ViewDetailComponent, {
      height: '55%',
      width: '65%',
      data: {
        action: StatusForm.VIEW,
        detail,
      },
      disableClose: true,
    });
  }

  fetchProvince() {
    this.farmerService.getProvince().subscribe(result => {
      this.provinces = result;
    });
  }

  fetchByre() {
    this.farmerService.getByres().subscribe(result => {
      this.byres = result;
      this.farmerByres = this.byres.filter(byre => byre.farmerId == this.sourceView.id);
      if (this.farmerByres.length > 0) {
        this.byreSource = new MatTableDataSource(this.farmerByres);
      }

    });
  }

  fetchHistory() {
    this.farmerService.getFeedHistoriesByFarmerId(this.sourceView.id).subscribe(result => {
      this.histories = result;
      this.historySource = new MatTableDataSource(this.histories);
    });
  }
  fetchNotifications() {
    this.farmerService.getNotificationsByFarmerId(this.sourceView.id).subscribe(result => {
      this.notifications = result;
      this.notificationSource = new MatTableDataSource(this.notifications);
    });
  }

  deleteNotification(noti: Notify) {
    const deleteDialog = this.dialog.open(ConfirmationComponent, {
      data: {
        message: 'Bạn có muốn xóa?',
      },
      disableClose: true,
    });

    deleteDialog.afterClosed().subscribe(
      result => {
        if (result.confirmed) {
          this.farmerService.deleteNotification(noti.id).subscribe(
            success => {
              this.dialog.open(AlertComponent, {
                data: {
                  message: "Xóa thành công"
                }
              });
              const notiIndex = this.notifications.indexOf(noti);
              if (notiIndex !== -1) {
                this.notifications.splice(notiIndex, 1);
                this.notificationSource.data = this.notifications;
              }
            }
          );
        }
      }
    );
  }

  fetchDistrict(proviceId: number) {
    this.farmerService.getDistrictByProvinceId(proviceId).subscribe(result => {
      this.districts = result;
    });
  }

  addFarmerAccount(farmer: Farmer) {
    if (!farmer.userId) {
      const addUserDialog = this.dialog.open(AddFarmerToUserComponent, {
        width: '80%',
        data: {
          fromFarmerList: true,
          farmer
        },
        disableClose: true,
      });
      addUserDialog.afterClosed().subscribe(
        result => {

        }
      );
    } else {
      this.dialog.open(AlertComponent, {
        data: {
          message: "Nông dân này đã có tài khoản"
        }
      });
    }

  }

  edit() {
    this.isView = false;
  }

  save() {
    this.farmerService.updateFarmer(this.farmer.id, this.sourceView).subscribe(
      result => {
        this.isView = true;
        this.farmer = this.sourceView;
      }
    );
  }

  discard() {
    this.isView = true;
    this.sourceView = this.farmer;
  }


  delete() {
    const deleteDialog = this.dialog.open(ConfirmationComponent, {
      data: {
        message: 'Bạn có muốn xóa?',
      },
      disableClose: true,
    });

    deleteDialog.afterClosed().subscribe(
      result => {
        if (result.confirmed) {
          this.farmerService.deleteFarmer(this.farmer.id).subscribe(
            success => {
              this.dialogRef.close({
                action: StatusForm.DETELE,
                data: this.farmer,
              });

            }
          );
        }
      }
    );
  }

  create() {
    this.farmerService.createFarmer(this.sourceView).subscribe(
      result => {
        this.dialogRef.close({
          data: result,
        });
      }
    );
  }

  close() {
    this.dialogRef.close({
      action: StatusForm.VIEW,
      data: this.farmer,
    });
  }

  viewCows(byre: Byre) {
    // console.log(byre);
    this.farmerService.getCows().subscribe(result => {
      this.cows = result;
      // console.log(this.cows, "default");
      this.cowsInByre = this.cows.filter(cow => cow.byreId == byre.id);
      if (this.cowsInByre.length > 0) {
        this.cowSource = new MatTableDataSource(this.cowsInByre);
        this.alert = "";
      } else {
        this.dialog.open(AlertComponent, {
          data: {
            message: "Nông dân chưa tạo bò trong chuồng này!"
          }
        });
      }
    });
  }

  afterClose(result: any) {
    const noti = result.data;
    if (result.action === StatusForm.VIEW) {
      const userIndex = this.notifications.map(p => p.id).indexOf(noti.id);
      this.notifications[userIndex] = noti;
      this.notificationSource.data = this.notifications;
    }
  }
}
