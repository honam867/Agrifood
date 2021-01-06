export class Employee {
  id: number;
  userId: number;
  name: string;
  code:string;
  fullName: string;
  // userUserName: string;
  email: string;
  phoneNumber: string;
  address: string;
  birthday: Date;
  identificationNo: string;
  issuedOn: Date;
  issuedBy: string;
  accountNumber: string;
  bank: string;
  bankBranch: string;
  permissionGroup: string;

  constructor() {
    this.id = 0;
    this.name = '';
    this.fullName = '';
    this.phoneNumber = '';
    this.address = '';
  }
}
