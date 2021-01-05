import { UserService } from './user.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRoutingModule } from './user-routing.module';
import { UserListComponent } from './pages/user-list/user-list.component';
import { CRUDUserComponent } from './components/cruduser/cruduser.component';
import { AddFarmerToUserComponent } from './components/add-farmer-to-user/add-farmer-to-user.component';


@NgModule({
  declarations: [
    UserListComponent,
    CRUDUserComponent,
    AddFarmerToUserComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    SharedModule.forRoot()
  ],
  entryComponents:[CRUDUserComponent],
  providers: [UserService]
})
export class UserModule {

 }
