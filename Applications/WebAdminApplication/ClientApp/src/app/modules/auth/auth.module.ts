import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SignInComponent } from './page/sign-in/sign-in.component';
import { ForgotPasswordComponent } from './page/forgot-password/forgot-password.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { AuthRoutingModule } from './auth-routing.module';
import { AuthComponent } from 'src/app/layout/auth/auth.component';
import { AuthService } from './auth.service';
import { NewPasswordComponent } from './page/new-password/new-password.component';
import { HttpService } from 'src/app/shared/services/http.service';
import { ChangePasswordComponent } from './page/change-password/change-password.component';
import { ProfileComponent } from './page/profile/profile.component';

@NgModule({
  declarations: [
    SignInComponent,
    ForgotPasswordComponent,
    AuthComponent,
    NewPasswordComponent,
    ChangePasswordComponent,
    ProfileComponent
  ],
  imports: [CommonModule, AuthRoutingModule, SharedModule.forRoot()],
  providers: [AuthService, HttpService]
})
export class AuthModule { }
