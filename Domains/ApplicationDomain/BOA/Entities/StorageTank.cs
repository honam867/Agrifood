using ApplicationDomain.Core.Entities;
using ApplicationDomain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class StorageTank : EntityBase<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string TypeMilk { get; set; }
        public int Quantity { get; set; }
        public int MilkCollectionStationId { get; set; }
        public MilkCollectionStation MilkCollectionStation { get; set; }

    }
}