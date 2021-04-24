using ApplicationDomain.Core.Entities;
using ApplicationDomain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class MilkCoupon : EntityBase<int>
    {
        public string Code { get; set; }
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int StorageTankId { get; set; }
        public StorageTank StorageTank { get; set; }
        public string Session { get; set; }
        public int MilkCollectionStationId { get; set; }
        public MilkCollectionStation MilkCollectionStation { get; set; }

    }
}