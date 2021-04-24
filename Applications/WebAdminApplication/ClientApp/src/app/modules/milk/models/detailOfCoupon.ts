export class DetailOfCoupon {
  id: number;
  milkCouponId: number;
  quantity: number;
  typeMilk: number;

  constructor(milkCouponId: number = 0) {
      this.milkCouponId = milkCouponId;
      this.quantity = 0;
      this.typeMilk = 0;
  }
}
