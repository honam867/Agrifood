import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit } from '@angular/core';
import { StatusForm } from 'src/app/shared/enum/status-form';
import { CRUDUserComponent } from '../../components/cruduser/cruduser.component';
import { User } from '../../models/user';
export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Hydro', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},
  {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
  {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
];
@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {

  displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  dataSource = ELEMENT_DATA;
  constructor(
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
  }
  createUser() {
    const createDialog = this.dialog.open(CRUDUserComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.CREATE,
        user: new User(),
      },
      disableClose: true,
    });

    // createDialog.afterClosed().subscribe(
    //   result => {
    //     this.userService.getUserById(result.data).subscribe(
    //       createdUser => {
    //         if (createdUser !== null) {
    //           this.users.push(createdUser);
    //           this.dataSource.data = this.users;
    //         }
    //       }
    //     );
    //   }
    // );
  }

}
