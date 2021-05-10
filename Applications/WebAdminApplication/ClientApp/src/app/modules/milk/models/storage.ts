// public class StorageTank : EntityBase<int>
//     {
//         public string Name { get; set; }
//         public string Code { get; set; }
//         public string TypeMilk { get; set; }
//         public int Quantity { get; set; }
//         public int MilkCollectionStationId { get; set; }
//         public MilkCollectionStation MilkCollectionStation { get; set; }

//     }

export class StorageTank {
  id: number;
  name: string;
  code: string;
  typeMilk: string;
  quantity: number;
  milkCollectionStationId: number;

  constructor() {
   this.id =0;
   this.name ="";
   this.code = "";
   this.typeMilk = "";
   this.quantity = 0;
   this.milkCollectionStationId = 0;}
}
