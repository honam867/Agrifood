import { PersonalInfoComponent } from './page/personal-info/personal-info.component';
import { ProfileComponent } from './page/profile/profile.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignInComponent } from './page/sign-in/sign-in.component';
import { ForgotPasswordComponent } from './page/forgot-password/forgot-password.component';
import { AuthComponent } from '../../layout/auth/auth.component';
import { NewPasswordComponent } from './page/new-password/new-password.component';
import { ChangePasswordComponent } from './page/change-password/change-password.component';

const routes: Routes = [
  {
    path: '',
    component: AuthComponent,
    children: [
      { path: 'personalinfo', component: PersonalInfoComponent },
      { path: 'signin', component: SignInComponent },
      { path: 'forgotpassword', component: ForgotPasswordComponent },
      { path: 'newpassword', component: NewPasswordComponent },
      { path: 'changepassword', component: ChangePasswordComponent },
      { path: 'profile', component: ProfileComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
