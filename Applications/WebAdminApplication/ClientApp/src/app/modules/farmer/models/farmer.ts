export class Farmer {
  id: number;
  code: string;
  name: string;
  fullName: string;
  qrCode: string;
  phoneNumber: string;
  address: string;
  birthday: Date;
  gender: boolean;
  districtId: number;
  provinceId: number;
  isBlock: boolean;
  contractCreatetionDate: Date;
  userId: number;
  milkCollectionId: number;
  avatarURL: string;

  constructor() {
      this.id = 0;
      this.code = '';
      this.name = '';
      this.fullName = '';
      // this.avatarURL = '';
      // this.qrCode = '';
      this.phoneNumber = '';
      this.address = '';
      // this.districtId = 0;
      // this.provinceId = 0;
      this.isBlock = false;
      // this.userId = 0;
      // this.milkCollectionId = 0;
  }
}
