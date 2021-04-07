export class Cow {
  id: number;
  byreId: number;
  code: string;
  name: string;
  motherId: number;
  fatherId: number;
  qrCode: string;
  status: string;
  tinhCode: string;
  birthDay: Date;
  ageNumber: number;
  gender: string;
  weaningDay: Date;
  foodSuggestionId: number;

  constructor() {
    this.id = 0;
    this.byreId = 0;
    this.code = '';
    this.name = '';
    this.motherId = 0;
    this.fatherId = 0;
    this.qrCode = '';
    this.status = '';
    this.tinhCode= '';
    this.birthDay = new Date('02/02/2020');
    this.ageNumber=0;
    this.gender='';
    this.weaningDay= new Date('02/02/2020');
    this.foodSuggestionId = 0;
  }
}
