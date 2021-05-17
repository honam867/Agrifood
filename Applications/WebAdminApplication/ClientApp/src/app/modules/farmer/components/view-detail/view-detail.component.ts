import { FarmerService } from './../../farmer.service';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { FeedHistoryDetail } from './../../models/feedHistoryDetail';
import { MatTableDataSource } from '@angular/material/table';
import { Component, OnInit, ViewChild, Inject } from '@angular/core';

@Component({
  selector: 'app-view-detail',
  templateUrl: './view-detail.component.html',
  styleUrls: ['./view-detail.component.scss']
})
export class ViewDetailComponent implements OnInit {
  value = '';
  page = 1;
  showLoad = false;
  displayedColumns: string[] = ['foodName', 'foodType', 'quantity'];
  dataSource: MatTableDataSource<FeedHistoryDetail>;
  details: FeedHistoryDetail[] = [];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(
    public dialog: MatDialog,
    public farmerService: FarmerService,
    public dialogRef: MatDialogRef<ViewDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) { }

  ngOnInit(): void {
    this.fetchDetails();
  }

  fetchDetails(){
    this.farmerService.getFeedHistoryDetailsByFeedHistoryId(this.data.detail.id).subscribe(
      res => {
        this.details = res;
        this.dataSource = new MatTableDataSource(this.details);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  close() {
    this.dialogRef.close()
  }
}
