export class Order {
  id: number;
  code: string;
  employeeId: number;
  foodId: number;
  quantity: number;
  farmerId: number
  employeeName: string;
  farmerName: string;
  foodName: string;

  constructor() {
   this.id =0;
   this.code = "";
   this.employeeId = 0;
   this.foodId = 0;
   this.quantity = 0;
   this.farmerId = 0;
  }
}
