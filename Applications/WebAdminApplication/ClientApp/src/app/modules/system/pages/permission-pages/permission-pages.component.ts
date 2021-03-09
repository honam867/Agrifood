import { ConfirmationComponent } from './../../../../shared/components/confirmation/confirmation.component';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { PermissionGroupService } from './../../services/permission-group.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { PermissionGroup } from './../../models/permission-group';
import { MatTableDataSource } from '@angular/material/table';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-permission-pages',
  templateUrl: './permission-pages.component.html',
  styleUrls: ['./permission-pages.component.scss']
})
export class PermissionPagesComponent implements OnInit {
  value = '';
  showLoading: boolean;
  dataSource: MatTableDataSource<PermissionGroup>;
  permissionGroups: PermissionGroup[] = [];
  displayedColumns: string[] = ['id', 'name', 'description', 'action'];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(
    private permissionGroupService: PermissionGroupService,
    public dialog: MatDialog,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.fetchPermissionGroup();
  }

  fetchPermissionGroup() {
    this.showLoading = true;
    this.permissionGroupService.getPermissionGroup().subscribe(
      res => {
        this.permissionGroups = res;
        this.dataSource = new MatTableDataSource(this.permissionGroups);
        this.showLoading = false;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  create() {
    this.router.navigate(
      ['system/permissiongroup/0'],
      { queryParams: { action: 'create' } }
    );
  }

  deletePermission(value) {

  }

  viewDetail(id) {
    this.router.navigate(
      [`system/permissiongroup/${id}`],
      { queryParams: { action: 'view' } }
    );
  }

  edit(id) {
    this.router.navigate(
      [`system/permissiongroup/${id}`],
      { queryParams: { action: 'edit' } }
    );
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  delete(id: number) {
    const deleteDialog = this.dialog.open(ConfirmationComponent, {
      data: {
        message: 'Toàn bộ dữ liệu của bạn sẽ bị mất. Bạn có muốn xóa?'
      },
      disableClose: true
    });

    deleteDialog.afterClosed().subscribe(result => {
      if (result.confirmed) {
        this.permissionGroupService.delete(id).subscribe(
          deleteResult => {
            if (deleteResult.value) {
              const index = this.permissionGroups.map(p => p.id).indexOf(id);
              this.permissionGroups.splice(index, 1);
              this.dataSource.data = this.permissionGroups;
            }
          }
        );
      }
    });
  }


}
