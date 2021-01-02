import { SharedModule } from 'src/app/shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRoutingModule } from './user-routing.module';
import { UserListComponent } from './pages/user-list/user-list.component';
import { CRUDUserComponent } from './components/cruduser/cruduser.component';


@NgModule({
  declarations: [
    UserListComponent,
    CRUDUserComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    SharedModule.forRoot()
  ],
  entryComponents:[CRUDUserComponent]
})
export class UserModule {

 }
