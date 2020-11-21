import { ProfileUser } from './../../models/profile-user';
import { Component, OnInit } from '@angular/core';
import { StatusForm } from 'src/app/shared/enum/status-form';
import {
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialog
} from '@angular/material/dialog';
import { AuthService } from '../../auth.service';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  profileUser = new ProfileUser();
  avatarURL: string;

  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<ProfileComponent>,

    private authService: AuthService
  ) { }

  ngOnInit() {
    this.avatarURL = this.authService.getAvatarUrl();

  }



  close() {
    this.dialogRef.close({
      action: StatusForm.VIEW,
    });
  }
}
