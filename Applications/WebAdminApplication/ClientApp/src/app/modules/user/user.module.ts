import { CrudRolesUserComponent } from './components/crud-roles-user/crud-roles-user.component';
import { UserService } from './user.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRoutingModule } from './user-routing.module';
import { UserListComponent } from './pages/user-list/user-list.component';
import { CRUDUserComponent } from './components/cruduser/cruduser.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    UserListComponent,
    CRUDUserComponent,
    CrudRolesUserComponent
  ],
  imports: [
    CommonModule, UserRoutingModule, FormsModule, ReactiveFormsModule, SharedModule.forRoot()
  ],
  entryComponents: [CRUDUserComponent, CrudRolesUserComponent],
  providers: [UserService]
})
export class UserModule {

}
