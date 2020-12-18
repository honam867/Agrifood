import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../auth.service';
import { ValidateAllFormFields } from 'src/app/shared/validators/custom-validator';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})

export class SignInComponent implements OnInit {
  showLoading: boolean;
  hide = false;
  signInForm: FormGroup;
  userName: FormControl;
  password: FormControl;
  loginFail = false;
  confirmationToken: string;
  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService,
  ) {
  }


  ngOnInit() {
    this.createFormControls();
    this.createForm();
    this.authService.test().subscribe(result => {
      console.log(result);
    });
  }

  createFormControls() {
    this.userName = new FormControl('', [
      Validators.required,
    ]);
    this.password = new FormControl('', [
      Validators.required,
    ]);
  }

  createForm() {
    this.signInForm = this.formBuilder.group({
      userName: this.userName,
      password: this.password,
    });
  }

  signIn() {
    this.loginFail = false;
    this.showLoading = true;
    if (this.signInForm.valid) {
      this.authService.signIn(this.signInForm.value).subscribe(
        result => {
          localStorage.setItem(environment.tokenKey, JSON.stringify(result));
          this.authService.storagePermission();

          this.router.navigate(['']);
          this.showLoading = false;
        }, error => {
          this.loginFail = true;
          this.showLoading = false;
        }
      );
    } else {
      ValidateAllFormFields(this.signInForm);
    }
  }
}
