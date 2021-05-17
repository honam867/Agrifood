export class FeedHistoryDetail {
  id: number;
  code: string;
  foodId: number;
  quantity: number;
  foodType: string;
  foodName: string;

  constructor() {
   this.id =0;
   this.code="";
   this.foodId=0;
   this.quantity = 0;
  }
}
