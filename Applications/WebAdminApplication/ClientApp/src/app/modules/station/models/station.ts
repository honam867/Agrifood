export class Station {
  id: number;
  name: string;
  code: string;
  address: string;
  phoneNumber: string;
  email: string;
  districtId: number;
  typeOfMilkId: number;
  provinceId: number;
  constructor() {
   this.id =0;
   this.name="";
   this.code="";
   this.address="";
   this.phoneNumber="";
   this.districtId = 0;
   this.typeOfMilkId = 0;
   this.provinceId = 0;
  }
}
