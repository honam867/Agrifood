// {
//   public string Code { get; set; }
//   public int FarmerId { get; set; }
//   public Farmer Farmer { get; set; }
//   public string ScaleCode { get; set; }
//   public int EmployeeId { get; set; }
//   public Employee Employee { get; set; }
//   public DateTime CreatedDate { get; set; }
//   public string StorageTankCode { get; set; }
//   public string Session { get; set; }
//   public int MilkCollectionStationId { get; set; }
//   public MilkCollectionStation MilkCollectionStation { get; set; }

// }
export class Detail {
  id: number;
  milkCouponId: number;
  quantity: number;
  typeMilk: number;

  constructor() {
   this.id =0;
   this.milkCouponId = 0;
   this.quantity = 0;
   this.typeMilk = 0;
  }
}
