import { StatusForm } from 'src/app/shared/enum/status-form';
import { FarmerService } from './../../farmer.service';
import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Cow } from 'src/app/modules/cow/models/cow';

@Component({
  selector: 'app-update-cow',
  templateUrl: './update-cow.component.html',
  styleUrls: ['./update-cow.component.scss']
})
export class UpdateCowComponent implements OnInit {
  page = 1;
  displayedColumns: string[] = [
    'name',
    'action'];
  statusArray: string[] = [
    'Bò cai sữa', 'Bò cho sữa', 'Bò giống', 'Bò mang thai'
  ]
  loading: boolean;
  sourceView: Cow = new Cow();
  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<UpdateCowComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public farmerService: FarmerService
  ) { }


  ngOnInit(): void {
    this.sourceView = this.data.cow;
  }
  updateCow(){
    this.farmerService.updateCow(this.sourceView.id, this.sourceView).subscribe(
      result => {
        this.dialogRef.close({
          data: result,
        });
      }
    );
  }

  close() {
    this.dialogRef.close({
      action: StatusForm.VIEW
    });
  }
}
