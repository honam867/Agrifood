export class FeedHistory {
  id: number;
  code: string;
  cowId: number;
  createdDate: Date;

  constructor() {
   this.id =0;
   this.code="";
   this.cowId=0;
   this.createdDate = new Date();
  }
}
