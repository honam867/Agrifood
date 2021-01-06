import { Farmer } from './../../../farmer/models/farmer';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Component, OnInit, Inject } from '@angular/core';

@Component({
  selector: 'app-add-farmer-to-user',
  templateUrl: './add-farmer-to-user.component.html',
  styleUrls: ['./add-farmer-to-user.component.scss']
})
export class AddFarmerToUserComponent implements OnInit {
  farmer: Farmer = new Farmer();

  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<AddFarmerToUserComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) { }

  ngOnInit(): void {
    this.farmer = this.data.farmer;
    // console.log(this.farmer);
  }

}
