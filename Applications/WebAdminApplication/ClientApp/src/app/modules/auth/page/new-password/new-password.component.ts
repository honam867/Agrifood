import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormControl,
  FormBuilder,
  Validators
} from '@angular/forms';
import { AuthService } from '../../auth.service';
import { ValidateAllFormFields } from 'src/app/shared/validators/custom-validator';

@Component({
  selector: 'app-new-password',
  templateUrl: './new-password.component.html',
  styleUrls: ['./new-password.component.scss']
})
export class NewPasswordComponent implements OnInit {
  email: FormControl;
  code: FormControl;
  password: FormControl;
  newPasswordFail = 0;
  resetPasswordForm: FormGroup;
  confirmationToken: string;
  isClick = false;
  data: any;
  // email: string;
  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.route.queryParams.subscribe(queryParams => {
      this.code = queryParams.code;
      this.email = queryParams.email;
    });

    this.createFormControls();
    this.createForm();
  }
  createFormControls() {
    this.password = new FormControl('', [Validators.required]);
  }

  createForm() {
    this.resetPasswordForm = this.formBuilder.group({
      email: this.email,
      code: this.code,
      password: this.password
    });
  }
  newPass() {
    this.isClick = true;
    if (this.resetPasswordForm.valid) {
      this.authService.resetPassword(this.resetPasswordForm.value).subscribe(
        result => {
          if (result === true) {
            this.newPasswordFail = 1;
            this.data = setInterval(() => {

              this.backToIndex();
            }, 3000);
          } else {
            this.newPasswordFail = 2;
          }
          this.isClick = false;
        },
        error => {
          this.isClick = false;
        }
      );
    } else {
      ValidateAllFormFields(this.resetPasswordForm);
    }
  }
  backToIndex() {
    this.router.navigate(['auth/signin']);
    clearInterval(this.data);
  }
}
