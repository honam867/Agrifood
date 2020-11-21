import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormControl,
  FormBuilder,
  Validators
} from '@angular/forms';
import { ValidateAllFormFields } from 'src/app/shared/validators/custom-validator';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../auth.service';
@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {
  recoveryForm: FormGroup;
  email: FormControl;
  isChecked = false;
  password: FormControl;
  recoveryFail = 0;
  isClick = false;
  confirmationToken: string;
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit() {
    this.createFormControls();
    this.createForm();
  }

  createFormControls() {
    this.email = new FormControl('', [Validators.required , Validators.email]  );
  }

  createForm() {
    this.recoveryForm = this.formBuilder.group({
      email: this.email
    });
  }
  recovery() {
    this.isClick = true;

    if (this.recoveryForm.valid) {
      this.authService.forgotPassword(this.recoveryForm.value).subscribe(
        res => {
          // tslint:disable-next-line: no-unused-expression
          // tslint:disable-next-line: triple-equals
          if (res === true) {
            this.isChecked = true;
            this.recoveryFail = 1;
          } else {
            this.recoveryFail = 2;
          }
          this.isClick = false;
        },
        error => {
          this.recoveryFail = 2;
          this.isClick = false;
        }
      );
    } else {
      ValidateAllFormFields(this.recoveryForm);
    }
  }
}
