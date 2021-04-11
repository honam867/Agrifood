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
export class Coupon {
  id: number;
  code: string;
  farmerId: number;
  scaleCode: string;
  employeeId: number;
  createdDate: Date;
  storageTankCode: string;
  session: string;
  milkCollectionStationId : number;

  constructor() {
   this.id =0;
   this.code = "";
   this.farmerId = 0;
   this.scaleCode = "";
   this.employeeId = 0;
   this.storageTankCode = "";
   this.session = "";
   this.createdDate = new Date();
   this.milkCollectionStationId = 0;
  }
}
