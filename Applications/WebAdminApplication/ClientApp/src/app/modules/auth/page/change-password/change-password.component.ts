import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormControl,
  FormBuilder,
  Validators
} from '@angular/forms';
import { AuthService } from '../../auth.service';
import {
  ValidateAllFormFields,
  MustMatch
} from 'src/app/shared/validators/custom-validator';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {
  hide = false;
  hide1 = false;
  hide2 = false;
  oldPassword: FormControl;
  newPassword: FormControl;
  reNewPassword: FormControl;
  changePasswordForm: FormGroup;
  changePasswordError = 0;
  isClick = false;
  data: any;
  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.createFormControls();
    this.createForm();
    if (!this.authService.isSignin()) {
      this.router.navigate(['auth/signin']);
    }
  }

  createFormControls() {
    this.oldPassword = new FormControl('', [Validators.required]);
    this.newPassword = new FormControl('', [Validators.required]);
    this.reNewPassword = new FormControl('', [Validators.required]);
  }

  createForm() {
    this.changePasswordForm = this.formBuilder.group(
      {
        oldPassword: this.oldPassword,
        newPassword: this.newPassword,
        reNewPassword: this.reNewPassword
      },
      {
        validator: MustMatch('newPassword', 'reNewPassword')
      }
    );
  }
  get f() {
    return this.changePasswordForm.controls;
  }
  changePassword() {
    this.isClick = true;
    if (this.changePasswordForm.valid) {
      this.authService.changePassword(this.changePasswordForm.value).subscribe(
        result => {
          if (result === true) {
            this.changePasswordError = 1;
            this.data = setInterval(() => {
              this.backToIndex();
            }, 3000);
          } else {
            this.changePasswordError = 2;
          }
          this.isClick = false;
        },
        error => {
          this.isClick = false;
        }
      );
    } else {
      ValidateAllFormFields(this.changePasswordForm);
    }
  }
  backToIndex() {
    this.router.navigate(['auth/signin']);
    clearInterval(this.data);
  }
}
